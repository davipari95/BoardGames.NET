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
        #region ===== STRUCTS =====
        /// <summary>
        /// Event args containing the arguments of the event <see cref="MovedEvent"/>.
        /// </summary>
        public struct PieceMovedEventArgs
        {
            /// <summary>
            /// Actual position of the checker after it was moved.
            /// </summary>
            public GridPosition Position;

            /// <summary>
            /// Flag that means that a checker was eat after the movement is done.
            /// </summary>
            public bool PieceAte;
        }
        #endregion

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

        /// <summary>
        /// Event that is throwed after that the checker was moved. 
        /// </summary>
        public event EventHandler<PieceMovedEventArgs> MovedEvent;
        #endregion

        #region ===== METHODS =====
        /// <summary>
        /// Move pawn into a specific position.<br/>
        /// The event <see cref="MovedEvent"/> must be implemented here.
        /// </summary>
        /// <param name="gridPosition">Position where you want to move the pawn.</param>
        public void Move(GridPosition gridPosition);

        /// <summary>
        /// Eat this pawn.
        /// </summary>
        public void Eat();

        /// <summary>
        /// Promote this pawn.<br/>
        /// It means that this pawn will be a king.
        /// </summary>
        public void Promote();
        #endregion
    }
}
