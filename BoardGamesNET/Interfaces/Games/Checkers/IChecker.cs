using BoardGamesNET.Classes.Objects;
using BoardGamesNET.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Interfaces.Games.Checkers
{
    /// <summary>
    /// Interface that represents the pawn of the game of checkers.
    /// </summary>
    public interface IChecker
    {
        #region ===== VARIABLES =====
        /// <summary>
        /// Color of the pawn (white or black).
        /// </summary>
        public PlayerColorWBEnum Color { get; set; }

        /// <summary>
        /// If it's <see langword="true"/> it means that the pawn is a king, <see langword="false"/> otherwise.
        /// </summary>
        public bool IsKing { get; set; }

        /// <summary>
        /// Actual position of this pawn.
        /// </summary>
        public GridPosition GridPosition { get; }
        #endregion

        #region ===== EVENTS =====
        /// <summary>
        /// Event triggered when this pawn becames a king.
        /// </summary>
        public event EventHandler<bool> IsKingValueChangedEvent;

        /// <summary>
        /// Event triggered everytime this pawn is moved.
        /// </summary>
        public event EventHandler<GridPosition> PositionChanged;
        #endregion

        #region ===== METHODS =====
        /// <summary>
        /// Move pawn into a specific position.
        /// </summary>
        /// <param name="gridPosition">Position where you want to move the pawn.</param>
        public void Move(GridPosition gridPosition);

        /// <summary>
        /// Eat this pawn.
        /// </summary>
        public void Eat();
        #endregion

    }
}
