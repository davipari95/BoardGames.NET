using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Exceptions
{
    public class TCPException : Exception
    {
        public TCPException() : base() { }

        public TCPException(string? message) : base(message) { }
    }
}
