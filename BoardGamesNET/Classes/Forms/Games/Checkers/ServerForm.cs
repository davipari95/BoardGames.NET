using BoardGamesNET.Classes.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardGamesNET.Classes.Forms.Games.Checkers
{
    /// <summary>
    /// Server form for checkers game.
    /// </summary>
    public partial class ServerForm : Form
    {
        #region ===== FIELDS =====
        private bool _IsServerOpen = false;
        private int _ServerPort;
        private IPAddress _IPAddress;
        #endregion

        #region ===== VARIABLES =====
        /// <summary>
        /// Variable for check if server is open.<br/>
        /// If it's <see langword="true"/> it means that server is running.
        /// </summary>
        public bool IsServerOpen => _IsServerOpen;

        /// <summary>
        /// Port of the server.
        /// </summary>
        private int ServerPort
        {
            get
            {
                return _ServerPort;
            }
            set
            {
                if (value != _ServerPort)
                {
                    _ServerPort = value;
                }
            }
        }

        /// <summary>
        /// Server for route commands.
        /// </summary>
        private TcpListener Server { get; set; }

        /// <summary>
        /// Local IP address that server is listening to.
        /// </summary>
        private IPAddress IPAddress => _IPAddress;
        #endregion

        #region ===== CONSTRUCTORS =====
        /// <summary>
        /// Constructor for server form.
        /// </summary>
        /// <param name="port">Port for opening the server.</param>
        public ServerForm(int port)
        {
            InitializeComponent();

            _ServerPort = port;
            _IPAddress = UNet.GetIPAddress();

            IPAddressLabel.Text = IPAddress.ToString();
            PortNumberLabel.Text = port.ToString();
        }
        #endregion

        #region ===== METHODS =====
        /// <summary>
        /// Write log on server form.<br/>
        /// This will append a new line on style
        /// <code>  [dd/MM/yyyy HH:mm:ss.fff] >> {message}</code>
        /// </summary>
        /// <param name="message">Message to append on log.</param>
        private void AppendLog(string message)
        {
            string _msg = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss.fff}] >> {message}\r\n";

            LogTextBox.AppendText(_msg);
        }

        /// <summary>
        /// Open and start the server.<br/>
        /// The port used to open the server is the same passed on constructor <see cref="ServerForm(int)"/>.
        /// </summary>
        private void StartServer()
        {
            Server = new TcpListener(IPAddress, ServerPort);
            Server.Start();
        }
        #endregion
    }
}
