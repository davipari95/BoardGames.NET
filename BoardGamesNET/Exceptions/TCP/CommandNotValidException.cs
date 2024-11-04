using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Exceptions.TCP
{
    public class CommandNotValidException : TCPException
    {

        public CommandNotValidException() : base() { }

        public CommandNotValidException(string? message) : base(message) { }

    }
}
