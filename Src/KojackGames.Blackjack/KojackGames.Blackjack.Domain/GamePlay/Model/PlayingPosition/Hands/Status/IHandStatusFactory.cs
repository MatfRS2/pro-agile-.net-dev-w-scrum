namespace KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition.Hands.Status
{
    public interface IHandStatusFactory
    {
        void set_status_for(IHand hand);
        void update_the_status_of_each_hand_in(IPlayingPositions playing_positions);
    }
}