using System.Collections.Generic;
using KojackGames.Blackjack.Domain.GamePlay.Model.Dealer.Observations;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition.Hands.Dealer;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition.Hands.Player;
using Machine.Specifications;
using Rhino.Mocks;

namespace KojackGames.Blackjack.Core.Tests.Domain_Specs.DealerAction_Specs.DealCardsIn
{
    [Subject(typeof(OptionsAvailableToPlayerAfterDealing))]
    public class when_a_players_hand_meets_the_criteria_to_take_insurance_after_dealing : with_OptionsAvailableToPlayerAfterDealing
    {
        private Establish context = () =>
        {
            playing_positions = MockRepository.GenerateStub<IPlayingPositions>();
            playing_hand = MockRepository.GenerateStub<IPlayersHand>();
            playing_positions.Stub(x => x.players_active_hand).Return(playing_hand);

            dealers_hand = MockRepository.GenerateStub<IDealersHand>();
            playing_positions.Stub(x => x.dealers_hand).Return(dealers_hand);

            insurance_spec.Stub(x => x.is_satisfied_by(dealers_hand)).Return(true);
        };

        private Because of = () => SUT.set_for_hands_in(playing_positions);

        It should_check_the_dealers_hand_for_the_offer_for_insurance = () =>
        {
            insurance_spec.AssertWasCalled(x => x.is_satisfied_by(dealers_hand));
        };

        It should_mark_the_players_hand_as_being_able_to_take_insurance = () =>
        {
            playing_hand.AssertWasCalled(x => x.mark_as_able_to_take_insurance());
        };

        private static IPlayingPositions playing_positions;
        private static IPlayersHand playing_hand;
        private static IDealersHand dealers_hand;
    }
}