using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Exceptions
{
    public class NetworkException : Exception
    {

        public NetworkException(string? message) : base(message) { }

        public NetworkException() : base() { }
    }
}
