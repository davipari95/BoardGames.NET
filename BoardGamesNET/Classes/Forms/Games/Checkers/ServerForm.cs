using BoardGamesNET.Classes.Objects.Games;
using BoardGamesNET.Classes.Objects.Games.Checkers;
using BoardGamesNET.Classes.Utils;
using BoardGamesNET.Enums;
using BoardGamesNET.Exceptions.TCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        /// Variable for checking if the server is listening for new clients.
        /// </summary>
        public bool IsServerReadyForAcceptingClient
        {
            get
            {
                return Server != null && Server.Server.IsBound;
            }
        }

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

        /// <summary>
        /// List containing the player list that are connected with TCP/IP.
        /// </summary>
        private List<CheckersTCPPlayer> TCPPlayers { get; set; } = new List<CheckersTCPPlayer>(0);
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

            StartServer();
            AcceptClients();
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

            AppendLog("Server is started.");
        }

        private async Task AcceptClients()
        {
            while (TCPPlayers.Count < 2)
            {
                AppendLog($"Server is waiting for client nr. ({TCPPlayers.Count + 1})");

                TcpClient client = await Server.AcceptTcpClientAsync();

                CheckersTCPPlayer player = new CheckersTCPPlayer("", PlayerColorWBEnum.White, client);
                player.TcpStringReceivedEvent += Player_TcpStringReceivedEvent;

                TCPPlayers.Add(player);
            }
        }

        private void Player_TcpStringReceivedEvent(object? sender, string e)
        {
            if (sender != null)
            { 
                CheckersTCPPlayer senderPlayer = (CheckersTCPPlayer)sender;

                string[] command = e.Split(" ");

                switch (command[0])
                {
                    case "set-user-name":
                        string username = UString.GetBetweenBrackets(e);
                        senderPlayer.Name = username;
                        break;

                    default:
                        throw new CommandNotValidException($"Command {command[0]} doesn't exists.");
                }
            }
            else
            {
                throw new ArgumentNullException("Sender cannot be null.");
            }
        }

        private async Task WriteToClient(TCPPlayer player, string value)
        {
            byte[] stringToByte = Encoding.Unicode.GetBytes(value);
            await player.Client.GetStream().WriteAsync(stringToByte);
        }

        private async Task WriteToClient(TCPPlayer player, string formatString, params object[] parameters)
        {
            await WriteToClient(player, string.Format(formatString, parameters));
        }
        #endregion

        #region ===== NESTED CLASSES =====
        /// <summary>
        /// Class containing all informations about TCP player of checkers game.
        /// </summary>
        private class CheckersTCPPlayer : TCPPlayer
        {

            #region ===== FIELDS =====
            private PlayerColorWBEnum _Color;
            private bool _ReadFromClientEnabled;
            #endregion

            #region ===== VARIABLES =====
            /// <summary>
            /// Color of the player (white or black).<br/>
            /// Changing the value of this variable trigs the event <see cref="ColorChangedEvent"/>.
            /// </summary>
            public PlayerColorWBEnum Color
            {
                get
                {
                    return _Color;
                }
                set
                {
                    if (value != _Color)
                    {
                        _Color = value;
                    }
                }
            }

            private bool ReadFromClientEnabled
            {
                get
                {
                    return _ReadFromClientEnabled;
                }
                set
                {
                    if (value != _ReadFromClientEnabled)
                    {
                        _ReadFromClientEnabled = value;
                    }
                }
            }

            private Task ReadFromClientTask { get; set; }
            #endregion

            #region ===== EVENTS =====
            /// <summary>
            /// Event that is triggered when the variable <see cref="Color"/> is changed.
            /// </summary>
            public event EventHandler<PlayerColorWBEnum> ColorChangedEvent;

            /// <summary>
            /// Event that is triggered everytime a string from the server is received.
            /// </summary>
            public event EventHandler<string> TcpStringReceivedEvent;
            #endregion

            #region ===== CONSTRUCTORS =====
            /// <summary>
            /// Class constructor.
            /// </summary>
            /// <param name="name">Name of the player.</param>
            /// <param name="color">Color of the player.</param>
            /// <param name="client">TCP client of the player.</param>
            public CheckersTCPPlayer(string name, PlayerColorWBEnum color, TcpClient client) : base(name, client)
            {
                _Color = color;

                ReadFromClientTask = Task.Run(ReadFromClientAction);
            }
            #endregion

            #region ===== METHODS =====
            private void ReadFromClientAction()
            {
                while (ReadFromClientEnabled)
                {
                    using (StreamReader sr = new StreamReader(Client.GetStream()))
                    {
                        string? input = sr.ReadLine();

                        if (input != null)
                        {
                            Debug.WriteLine(input);

                            TcpStringReceivedEvent?.Invoke(this, input);
                        }
                        else
                        {
                            //Client disconnects
                        }
                    }
                }
            }
            #endregion

        }
        #endregion
    }
}
