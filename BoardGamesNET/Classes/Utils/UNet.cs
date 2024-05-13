using BoardGamesNET.Exceptions.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Classes.Utils
{
    public class UNet
    {

        public static IPAddress GetIPAddress()
        {
            string hostName = Dns.GetHostName();
            IPHostEntry hostEntry = Dns.GetHostEntry(hostName);

            foreach (IPAddress ip in hostEntry.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }

            throw new LocalIPAddressNotFoundException("No InterNetwork was found.");
        }

        public static string GetIPAddressString()
        {
            try
            {
                return GetIPAddress().ToString();
            }
            catch
            {
                throw;
            }
        }
    }
}
