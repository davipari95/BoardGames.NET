using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Exceptions
{
    /// <summary>
    /// Represents error that can be throw during checkers game.
    /// </summary>
    public class CheckersException : Exception
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="CheckersException"/> class.
        /// </summary>
        public CheckersException() : base() { }

        /// <summary>
        /// Initialize a new instance of the <see cref="CheckersException"/> class with a specified error message.
        /// </summary>
        /// <param name="message"></param>
        public CheckersException(string message) : base(message) { }

    }
}
