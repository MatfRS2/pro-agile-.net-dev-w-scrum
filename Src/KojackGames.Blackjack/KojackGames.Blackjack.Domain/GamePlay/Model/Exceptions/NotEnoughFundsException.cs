using System;

namespace KojackGames.Blackjack.Domain.GamePlay.Model.Exceptions
{
    public class NotEnoughFundsException : GameException
    {
        public NotEnoughFundsException(string message) : base (message)
        {            
        }
    }
    
}