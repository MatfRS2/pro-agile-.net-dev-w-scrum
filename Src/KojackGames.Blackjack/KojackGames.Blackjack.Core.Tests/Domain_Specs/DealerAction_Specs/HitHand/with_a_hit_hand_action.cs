using KojackGames.Blackjack.Domain.GamePlay.Model.Dealer.Actions;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition.Hands.Status;
using Rhino.Mocks;

namespace KojackGames.Blackjack.Core.Tests.Domain_Specs.DealerAction_Specs.HitHand
{
    public abstract class with_a_hit_hand_action
    {
        protected static Domain.GamePlay.Model.Dealer.Actions.HitHand SUT;
        protected static IPlayingHandsEndGameStatusDecider playing_hands_end_game_status_decider;
        protected static IHandStatusFactory hand_status_factory;
        protected static IPlayDealersHand player_dealers_hand;
        private IChipAllocator chip_allocator;

        public with_a_hit_hand_action()
        {
            hand_status_factory = MockRepository.GenerateStub<IHandStatusFactory>();
            playing_hands_end_game_status_decider = MockRepository.GenerateStub<IPlayingHandsEndGameStatusDecider>();
            player_dealers_hand = MockRepository.GenerateStub<IPlayDealersHand>();
            chip_allocator = MockRepository.GenerateStub<IChipAllocator>();

            SUT = new Domain.GamePlay.Model.Dealer.Actions.HitHand(hand_status_factory, player_dealers_hand, playing_hands_end_game_status_decider, chip_allocator);
        }
    }
}