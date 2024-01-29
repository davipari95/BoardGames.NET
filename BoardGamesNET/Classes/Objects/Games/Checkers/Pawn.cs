using BoardGamesNET.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICheckersPawn = BoardGamesNET.Interfaces.Games.Checkers.IChecker;

namespace BoardGamesNET.Classes.Objects.Games.Checkers
{
    public class Pawn : ICheckersPawn, IEquatable<Pawn>
    {
        #region ===== VARIABLES =====

        #region ===== FIELDS FOR VARIABLES =====
        private PlayerColorWBEnum _Color;
        private bool _IsKing;
        private GridPosition _GridPosition;
        #endregion

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

        public bool IsKing
        {
            get
            {
                return _IsKing;
            }
            set
            {
                if (value != _IsKing)
                {
                    _IsKing = value;
                    IsKingValueChangedEvent?.Invoke(this, value);
                }
            }
        }

        public GridPosition GridPosition
        {
            get
            {
                return _GridPosition;
            }
        }

        public Image Image
        {
            get
            {
                switch (Color)
                {
                    case PlayerColorWBEnum.White:
                        return IsKing ? Resources.Games.Checkers.WhiteCheckerKing : Resources.Games.Checkers.WhiteChecker;
                    case PlayerColorWBEnum.Black:
                        return IsKing ? Resources.Games.Checkers.BlackCheckerKing : Resources.Games.Checkers.BlackChecker;
                    default:
                        throw new ArgumentException("Color doesn't exists.");
                }
            }
        }
        #endregion

        #region ===== EVENTS =====
        public event EventHandler<bool> IsKingValueChangedEvent;
        public event EventHandler<GridPosition> PositionChanged;
        #endregion

        #region ===== CONSTRUCTORS =====
        public Pawn(PlayerColorWBEnum color, GridPosition startingPosition)
        {
            _Color = color;
            _GridPosition = startingPosition;
            _IsKing = false;

            GridPosition.PositionChangedEvent += GridPosition_PositionChangedEvent;
        }
        #endregion

        #region ===== METHODS =====
        private void GridPosition_PositionChangedEvent(object? sender, GridPosition e)
        {
            PositionChanged?.Invoke(this, e);
        }

        public bool Equals(Pawn? other)
        {
            return
                other != null &&
                Color.Equals(other.Color) &&
                IsKing.Equals(other.IsKing) &&
                GridPosition.Equals(other.GridPosition);
        }
        #endregion
    }
}
