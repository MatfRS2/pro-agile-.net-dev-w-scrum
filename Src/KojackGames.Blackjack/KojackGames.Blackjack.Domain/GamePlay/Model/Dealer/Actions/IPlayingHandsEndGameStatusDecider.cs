using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition;
using KojackGames.Blackjack.Domain.Membership.Model;

namespace KojackGames.Blackjack.Domain.GamePlay.Model.Dealer.Actions
{
    public interface IPlayingHandsEndGameStatusDecider
    {
        void decide_end_game_status_for_hands_in(IPlayingPositions playing_positions);
    }
}