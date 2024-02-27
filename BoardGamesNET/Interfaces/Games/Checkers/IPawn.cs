using BoardGamesNET.Classes.Objects;
using BoardGamesNET.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Interfaces.Games.Checkers
{
    public interface IChecker
    {
        #region ===== VARIABLES =====
        public PlayerColorWBEnum Color { get; set; }
        public bool IsKing { get; set; }
        public GridPosition GridPosition { get; }
        #endregion

        #region ===== EVENTS =====
        public event EventHandler<bool> IsKingValueChangedEvent;
        public event EventHandler<GridPosition> PositionChanged;
        #endregion

        #region ===== METHODS =====
        public void Move(GridPosition gridPosition);
        public void Eat();
        #endregion

    }
}
