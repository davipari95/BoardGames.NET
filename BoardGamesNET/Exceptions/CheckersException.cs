using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Exceptions
{
    public class CheckersException : Exception
    {

        public CheckersException() : base() { }

        public CheckersException(string message) : base(message) { }

    }
}
