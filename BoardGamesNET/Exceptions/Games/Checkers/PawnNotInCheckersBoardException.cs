using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Exceptions.Games.Checkers
{
    public class PawnNotInCheckersBoardException : CheckersException
    {

        public PawnNotInCheckersBoardException() : base() { }

        public PawnNotInCheckersBoardException(string message) : base(message) { }

    }
}
