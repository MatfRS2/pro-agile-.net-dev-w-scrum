using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition;

namespace KojackGames.Blackjack.Domain.GamePlay.Model.Dealer.Actions
{
    public class CardDealer
    {
        public void deal_two_cards_to_each_hand_in(IPlayingPositions hands, ICardShoe card_shoe)
        {
            int no_of_cards_to_deal = 2;

            while (no_of_cards_to_deal > 0)
            {
                hands.players_active_hand.add(card_shoe.take_card());
                hands.dealers_hand.add(card_shoe.take_card());

                no_of_cards_to_deal--;
            };
        }
    }
}