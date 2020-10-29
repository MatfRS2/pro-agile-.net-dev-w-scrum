using System;

namespace KojackGames.Blackjack.Domain.GamePlay.Model.Exceptions
{
    public class GameException : ApplicationException
    {
        public GameException(string message) : base (message)
        {
                
        }
    }
}