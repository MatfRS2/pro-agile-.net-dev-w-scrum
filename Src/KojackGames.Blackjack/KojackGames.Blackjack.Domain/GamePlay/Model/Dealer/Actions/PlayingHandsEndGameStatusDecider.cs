using KojackGames.Blackjack.Domain.GamePlay.Model.Dealer.Observations;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition.Hands.Player;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition.Hands.Status;
using KojackGames.Blackjack.Domain.Membership.Events;
using KojackGames.Blackjack.Domain.Membership.Model;
using KojackGames.Blackjack.Infrastructure.Domain;

namespace KojackGames.Blackjack.Domain.GamePlay.Model.Dealer.Actions
{
    public class PlayingHandsEndGameStatusDecider : IPlayingHandsEndGameStatusDecider
    {
        private readonly IHandScorer _hand_scorer;

        public PlayingHandsEndGameStatusDecider(IHandScorer hand_scorer)
        {
            _hand_scorer = hand_scorer;
        }

        public void decide_end_game_status_for_hands_in(IPlayingPositions playing_positions)
        {
            var dealers_hand = playing_positions.dealers_hand;
            
            dealers_hand.show_card_in_hole();

            foreach (var players_hand in playing_positions.players_hands())
            {
                if (players_hand.has_status_of(HandStatus.blackjack) && dealers_hand.has_status_of(HandStatus.blackjack))
                {
                    players_hand.change_state_to(HandStatus.push);
                }
                else if (players_hand.has_status_of(HandStatus.blackjack))
                {
                    players_hand.change_state_to(HandStatus.won);
                }
                else if (dealers_hand.has_status_of(HandStatus.blackjack))
                {
                    players_hand.change_state_to(HandStatus.lost);
                }
                else if (players_hand.has_status_of(HandStatus.soft_blackjack) &&
                         dealers_hand.has_status_of(HandStatus.soft_blackjack))
                {
                    players_hand.change_state_to(HandStatus.push);
                }
                else if (players_hand.has_status_of(HandStatus.soft_blackjack))
                {
                    players_hand.change_state_to(HandStatus.won);
                }
                else if (dealers_hand.has_status_of(HandStatus.soft_blackjack))
                {
                    players_hand.change_state_to(HandStatus.lost);
                }
                else if (players_hand.has_status_of(HandStatus.bust) && dealers_hand.has_status_of(HandStatus.bust))
                {
                    players_hand.change_state_to(HandStatus.push);
                }
                else if (players_hand.has_status_of(HandStatus.bust))
                {
                    players_hand.change_state_to(HandStatus.lost);
                }
                else if (dealers_hand.has_status_of(HandStatus.bust))
                {
                    players_hand.change_state_to(HandStatus.won);
                }
                else if (players_hand.has_status_of(HandStatus.stick))
                {
                    var player_score = _hand_scorer.calculate_score_for(players_hand);
                    var dealers_score = _hand_scorer.calculate_score_for(dealers_hand);

                    if (player_score > dealers_score)
                    {
                        players_hand.change_state_to(HandStatus.won);
                    }
                    else if (player_score < dealers_score)
                    {
                        players_hand.change_state_to(HandStatus.lost);
                    }
                    else if (player_score == dealers_score)
                    {
                        players_hand.change_state_to(HandStatus.push);
                    }
                }                
            }
        }       
    }
}
