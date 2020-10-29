using KojackGames.Blackjack.Domain.GamePlay.Model.Dealer.Observations;
using Rhino.Mocks;

namespace KojackGames.Blackjack.Core.Tests.Domain_Specs.DealerAction_Specs.DealCardsIn
{
    public abstract class with_OptionsAvailableToPlayerAfterDealing
    {
        protected static ICanDoubleDown double_down_spec;
        protected static ICanSplit split_spec;
        protected static ICanTakeInsurance insurance_spec;
        protected static OptionsAvailableToPlayerAfterDealing SUT;

        public with_OptionsAvailableToPlayerAfterDealing()
        {
            double_down_spec = MockRepository.GenerateStub<ICanDoubleDown>();
            split_spec = MockRepository.GenerateStub<ICanSplit>();
            insurance_spec = MockRepository.GenerateStub<ICanTakeInsurance>();

            SUT = new OptionsAvailableToPlayerAfterDealing(double_down_spec, split_spec, insurance_spec);
        }
    }
}