using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition;

namespace KojackGames.Blackjack.Domain.GamePlay.Model.Dealer.Observations
{
    public class OptionsAvailableToPlayerAfterDealing : IOptionsAvailableToPlayerAfterDealing
    {
        private readonly ICanDoubleDown _double_down_spec;
        private readonly ICanSplit _split_spec;
        private readonly ICanTakeInsurance _insurance_spec;

        public OptionsAvailableToPlayerAfterDealing(ICanDoubleDown double_down_spec, ICanSplit split_spec, ICanTakeInsurance insurance_spec)
        {
            _double_down_spec = double_down_spec;
            _insurance_spec = insurance_spec;
            _split_spec = split_spec;
        }

        public void set_for_hands_in(IPlayingPositions playing_positions)
        {
            if (_double_down_spec.is_satisfied_by(playing_positions.players_active_hand))
                playing_positions.players_active_hand.mark_as_able_to_double_down();

            if (_split_spec.is_satisfied_by(playing_positions.players_active_hand))
                playing_positions.players_active_hand.mark_as_able_to_split();

            if (_insurance_spec.is_satisfied_by(playing_positions.dealers_hand))
                playing_positions.players_active_hand.mark_as_able_to_take_insurance();  
        }
    }
}
