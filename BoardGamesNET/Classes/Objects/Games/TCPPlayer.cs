using BoardGamesNET.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Classes.Objects.Games
{
    public class TCPPlayer
    {
        #region ===== FIELDS =====
        private string _Name;
        private TcpClient _Client;
        #endregion

        #region ===== VARIABLES =====
        /// <summary>
        /// Name of the player.
        /// </summary>
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (value != _Name)
                {
                    _Name = value;
                }
            }
        }

        /// <summary>
        /// TCP client of the player.
        /// </summary>
        public TcpClient Client
        {
            get
            {
                return _Client;
            }
        }
        #endregion

        #region ===== EVENTS =====
        public event EventHandler<string> PlayerNameChangedEvent;
        #endregion

        #region ===== CONSTRUCTORS =====
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="name">Name of the player.</param>
        /// <param name="client">TCP client of the player.</param>
        public TCPPlayer(string name, TcpClient client)
        {
            _Name = name;
            _Client = client;
        }
        #endregion
    }
}
