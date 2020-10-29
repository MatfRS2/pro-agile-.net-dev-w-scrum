using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition.Hands.Player;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition.Hands.Status;
using KojackGames.Blackjack.Domain.Membership.Events;
using KojackGames.Blackjack.Domain.Membership.Model;
using KojackGames.Blackjack.Infrastructure.Domain;

namespace KojackGames.Blackjack.Domain.GamePlay.Model.Dealer.Actions
{
    public class ChipAllocator : IChipAllocator
    {
        public void allocate_chips_to_player_for_winnings_hands_in(IPlayingPositions positions, IPlayer player)
        {
            foreach (var players_hand in positions.players_hands())
            {
                var chips_to_give_to_player = new Chips(0m);

                if (players_hand.has_taken_insurance() && positions.dealers_hand.has_status_of(HandStatus.blackjack))
                {
                    var original_insurance_amount = players_hand.wager.halved();

                    var winnings = original_insurance_amount.mulitple_by_odds_of(2, 1);

                    chips_to_give_to_player = chips_to_give_to_player.add(original_insurance_amount.add(winnings));
                }

                if (players_hand.has_status_of(HandStatus.won))
                {
                    chips_to_give_to_player = chips_to_give_to_player.add(players_hand.wager.mulitple_by_odds_of(3, 2).add(players_hand.wager));
                    DomainEvents.raise(new HandResultEvent(string.Format("Hand {0} Won - you win {1}", players_hand.get_hand_letter(), chips_to_give_to_player.ToString())));
                    player.increase_pot_by(chips_to_give_to_player);
                }

                if (players_hand.has_status_of(HandStatus.push))
                {
                    chips_to_give_to_player = chips_to_give_to_player.add(players_hand.wager);
                    player.increase_pot_by(chips_to_give_to_player);

                    DomainEvents.raise(new HandResultEvent(string.Format("Hand {0} tied with the dealer, you get {1}", players_hand.get_hand_letter(), chips_to_give_to_player.ToString())));
                }

                if (players_hand.has_status_of(HandStatus.lost))
                {
                    if (chips_to_give_to_player.contains_chips())
                    {
                         player.increase_pot_by(chips_to_give_to_player);
                        DomainEvents.raise(new HandResultEvent(string.Format("Hand {0} lost, but you won insurance bet of {1}", players_hand.get_hand_letter(), chips_to_give_to_player.ToString())));
                    }
                    else
                    {
                        DomainEvents.raise(new HandResultEvent(string.Format("Hand {0} lost", players_hand.get_hand_letter())));
                    }
                }
            }
        }
    }
}