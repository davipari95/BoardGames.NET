using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Exceptions.Games.Checkers
{
    /// <summary>
    /// Represents errors that occur if you want to manage a pawn but it's not contained into the checkersboard.
    /// </summary>
    public class PawnNotInCheckersBoardException : CheckersException
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="PawnNotInCheckersBoardException"/> class.
        /// </summary>
        public PawnNotInCheckersBoardException() : base() { }

        /// <summary>
        /// Initialize a new instance of the <see cref="PawnNotInCheckersBoardException"/> class with a specified error message.
        /// </summary>
        /// <param name="message"></param>
        public PawnNotInCheckersBoardException(string message) : base(message) { }

    }
}
