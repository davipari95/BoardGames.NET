using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Exceptions.Network
{
    internal class LocalIPAddressNotFoundException : NetworkException
    {

        public LocalIPAddressNotFoundException(string message) : base(message) { }

        public LocalIPAddressNotFoundException() : base() { }

    }
}
