using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Classes.Objects.Games.Checkers.Games
{
    /// <summary>
    /// Class that manage the game of checkers in local mode (hot-seat).
    /// </summary>
    public class LocalGame : Game
    {
        #region ===== CONSTRUCTORS =====
        /// <summary>
        /// Initialize the local game.
        /// </summary>
        /// <param name="whitesPlayerName">Username of the player that wants to play the white pieces.</param>
        /// <param name="blacksPlayerName">Username of the player that wants to play the black pieces.</param>
        public LocalGame(string whitesPlayerName, string blacksPlayerName) : base(whitesPlayerName, blacksPlayerName)
        {
        }
        #endregion
    }
}
