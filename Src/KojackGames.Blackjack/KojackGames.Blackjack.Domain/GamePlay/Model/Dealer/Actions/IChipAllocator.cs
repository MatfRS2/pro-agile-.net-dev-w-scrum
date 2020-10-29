using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition;
using KojackGames.Blackjack.Domain.Membership.Model;

namespace KojackGames.Blackjack.Domain.GamePlay.Model.Dealer.Actions
{
    public interface IChipAllocator
    {
        void allocate_chips_to_player_for_winnings_hands_in(IPlayingPositions positions, IPlayer player);
    }
}
