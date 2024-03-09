using BoardGamesNET.Classes.Utils;
using BoardGamesNET.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ICheckersPawn = BoardGamesNET.Interfaces.Games.Checkers.IChecker;

namespace BoardGamesNET.Classes.Objects.Games.Checkers
{
    public class Pawn : ICheckersPawn, IEquatable<Pawn>
    {
        #region ===== STRUCTS =====
        public struct AvailableMovesStruct
        {
            public GridPosition Move;
            public Pawn? EatablePiece;
        }
        #endregion

        #region ===== VARIABLES =====

        #region ===== FIELDS FOR VARIABLES =====
        private PlayerColorWBEnum _Color;
        private bool _IsKing;
        private GridPosition _GridPosition;
        private CheckersBoard _CheckersBoardParent;
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
            set
            {
                if (!value.Equals(_GridPosition))
                {
                    _GridPosition = value;
                    PositionChanged?.Invoke(this, value);
                }
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

        public CheckersBoard CheckersBoardParent => _CheckersBoardParent;

        private bool IsWhite => Color == PlayerColorWBEnum.White;
        #endregion
        
        #region ===== EVENTS =====
        public event EventHandler<bool> IsKingValueChangedEvent;
        public event EventHandler<GridPosition> PositionChanged;
        #endregion

        #region ===== CONSTRUCTORS =====
        public Pawn(CheckersBoard parent, PlayerColorWBEnum color, GridPosition startingPosition)
        {
            _CheckersBoardParent = parent;
            _Color = color;
            _GridPosition = startingPosition;
            _IsKing = false;

            GridPosition.PositionChangedEvent += GridPosition_PositionChangedEvent;
        }
        #endregion

        #region ===== METHODS =====
        public bool Equals(Pawn? other)
        {
            return
                other != null &&
                Color.Equals(other.Color) &&
                IsKing.Equals(other.IsKing) &&
                GridPosition.Equals(other.GridPosition);
        }

        public override string ToString()
        {
            return $"[ Color = {Color} ; IsKing = {IsKing} ; GridPosition = {GridPosition} ]";
        }

        public IEnumerable<AvailableMovesStruct> GetAvailableMoves()
        {
            foreach (GridPosition p in GetAvailableDiagonalCells())
            {
                Pawn? positionPawn = CheckersBoardParent.GetPawnByPosition(p);

                if (positionPawn == null)
                {
                    yield return new AvailableMovesStruct()
                    {
                        EatablePiece = null,
                        Move = p,
                    };
                }
                else
                {
                    if (!positionPawn.Color.Equals(Color))
                    {
                        GridPosition nextPosition = new GridPosition()
                        {
                            Row = (2 * p.Row) - GridPosition.Row,
                            Column = (2 * p.Column) - GridPosition.Column,
                        };

                        if (CheckersBoard.IsInCheckersBoard(nextPosition) && CheckersBoardParent.GetPawnByPosition(nextPosition) == null)
                        {
                            yield return new AvailableMovesStruct()
                            {
                                EatablePiece = positionPawn,
                                Move = nextPosition,
                            };
                        }
                    }
                }
            }
        }

        public bool IsAvailableMoves(GridPosition position, out Pawn? eatablePawn)
        {
            eatablePawn = null;

            IEnumerable<AvailableMovesStruct> availableMoves = GetAvailableMoves();

            IEnumerable<AvailableMovesStruct> move = availableMoves.Where(gp => gp.Move.Equals(position));

            if (move.Count() == 1)
            {
                eatablePawn = move.ToArray()[0].EatablePiece;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsAvailableMoves(int row, int column, out Pawn? eatablePawn)
        {
            return IsAvailableMoves(new GridPosition(row, column), out eatablePawn);
        }

        public void Move(GridPosition gridPosition)
        {
            if (IsAvailableMoves(gridPosition, out Pawn? eatablePawn))
            {
                if (eatablePawn != null)
                {
                    eatablePawn.Eat();
                }

                GridPosition = gridPosition;
            }
        }

        public void Move(int row, int column)
        {
            Move(new GridPosition(row, column));
        }

        public void Eat()
        {
            CheckersBoardParent.EatPawn(this);
        }

        private IEnumerable<GridPosition> GetAvailableDiagonalCells()
        {
            List<GridPosition> neightboringCells = new List<GridPosition>(0);

            int movement = IsWhite ? -1 : 1;

            List<int> rows = new List<int>() { GridPosition.Row + movement };
            if (IsKing) rows.Add(GridPosition.Row - movement);

            List<int> cols = new List<int>() { GridPosition.Column - 1, GridPosition.Column + 1};

            foreach (int row in rows)
            {
                foreach (GridPosition p in cols.Select(c => new GridPosition(row, c)))
                {
                    if (CheckersBoard.IsInCheckersBoard(p))
                    {
                        yield return p;
                    }
                } 
            }
        }

        private void GridPosition_PositionChangedEvent(object? sender, GridPosition e)
        {
            PositionChanged?.Invoke(this, e);
        }
        #endregion
    }
}
