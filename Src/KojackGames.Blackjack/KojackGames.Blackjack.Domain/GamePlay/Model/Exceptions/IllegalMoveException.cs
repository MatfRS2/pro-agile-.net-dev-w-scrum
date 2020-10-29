using System;

namespace KojackGames.Blackjack.Domain.GamePlay.Model.Exceptions
{
    public class IllegalMoveException : GameException 
    {
        public IllegalMoveException(string message) : base (message)
        { }
    }
}