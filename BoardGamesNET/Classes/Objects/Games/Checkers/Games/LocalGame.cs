using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Classes.Objects.Games.Checkers.Games
{
    public class LocalGame : Game
    {
        #region ===== CONSTRUCTORS =====
        public LocalGame(string whitesPlayerName, string blacksPlayerName) : base(whitesPlayerName, blacksPlayerName)
        {
        }
        #endregion
    }
}
