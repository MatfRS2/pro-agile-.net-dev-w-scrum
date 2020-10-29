using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition;

namespace KojackGames.Blackjack.Domain.GamePlay.Model.Dealer.Observations
{
    public interface IOptionsAvailableToPlayerAfterDealing
    {
        void set_for_hands_in(IPlayingPositions playing_positions);
    }
}