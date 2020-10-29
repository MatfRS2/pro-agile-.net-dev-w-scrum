using System.Collections.Generic;
using KojackGames.Blackjack.Domain.GamePlay.Model;
using KojackGames.Blackjack.Domain.GamePlay.Model.CardDeck;
using KojackGames.Blackjack.Domain.GamePlay.Model.Dealer.Actions;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition.Hands;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition.Hands.Dealer;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition.Hands.Player;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition.Hands.Status;
using Machine.Specifications;
using Rhino.Mocks;

namespace KojackGames.Blackjack.Core.Tests.Domain_Specs.DealerAction_Specs.DealCardsIn
{
    [Subject(typeof(CardDealer))]
    public class when_dealing_in_the_hands
    {        
        private Establish context = () =>
        {
            SUT = new CardDealer();
            playing_positions = MockRepository.GenerateStub<IPlayingPositions>();
            card_shoe = MockRepository.GenerateStub<ICardShoe>();

            players_hand = MockRepository.GenerateStub<IPlayersHand>();
            playing_positions.Stub(x => x.players_active_hand).Return(players_hand);
            dealers_hand = MockRepository.GenerateStub<IDealersHand>();
            playing_positions.Stub(x => x.dealers_hand).Return(dealers_hand);

            hand = MockRepository.GenerateStub<IHand>();
            hands = new List<IHand>() { hand };
            playing_positions.Stub(x => x.all_hands).Return(hands);
        };

        private Because of = () => SUT.deal_two_cards_to_each_hand_in(playing_positions, card_shoe);

        It should_take_take_four_cards_from_the_card_shoe =
            () => card_shoe.AssertWasCalled(x => x.take_card(), o => o.Repeat.Times(4));

        It should_give_two_cards_to_the_player =
            () => players_hand.AssertWasCalled(x => x.add(Arg<Card>.Is.Anything), o => o.Repeat.Times(2));

        It should_give_two_cards_to_the_dealer =
            () => dealers_hand.AssertWasCalled(x => x.add(Arg<Card>.Is.Anything), o => o.Repeat.Times(2));                        

        protected static HandStatus hand_status;
        protected static CardDealer SUT;
        protected static IPlayingPositions playing_positions;
        protected static ICardShoe card_shoe;        
        protected static IPlayersHand players_hand;
        protected static IDealersHand dealers_hand;
        protected static List<IHand> hands;
        protected static IHand hand;
    }
}
