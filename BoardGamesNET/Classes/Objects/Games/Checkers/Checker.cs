using BoardGamesNET.Classes.Utils;
using BoardGamesNET.Enums;
using BoardGamesNET.Interfaces.Games.Checkers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Classes.Objects.Games.Checkers
{
    /// <summary>
    /// Class that rappresents and manage the pawn of the checkers game.
    /// </summary>
    public class Checker : IChecker, IEquatable<Checker>
    {
        #region ===== STRUCTS =====
        /// <summary>
        /// Struct that contains informations about the available move.
        /// </summary>
        public struct AvailableMoveStruct
        {
            /// <summary>
            /// <see cref="Objects.GridPosition"/> containing the available move.
            /// </summary>
            public GridPosition Move;

            /// <summary>
            /// Pawn that is eatable if you perform the movement in <see cref="Move"/>.<br/>
            /// If it's <see langword="null"/> it means that there's no piece to eat.
            /// </summary>
            public Checker? EatablePiece;
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

        /// <summary>
        /// Graphical image that rapresents this pawn.
        /// </summary>
        public Image Image
        {
            get
            {
                switch (Color)
                {
                    case PlayerColorWBEnum.White:
                        return IsKing ? Resources.Games.Checkers.CheckersResources.WhiteCheckerKing : Resources.Games.Checkers.CheckersResources.WhiteChecker;
                    case PlayerColorWBEnum.Black:
                        return IsKing ? Resources.Games.Checkers.CheckersResources.BlackCheckerKing : Resources.Games.Checkers.CheckersResources.BlackChecker;
                    default:
                        throw new ArgumentException("Color doesn't exists.");
                }
            }
        }

        /// <summary>
        /// Checkersboard where this pawn is positioned.
        /// </summary>
        public CheckersBoard CheckersBoardParent => _CheckersBoardParent;

        /// <summary>
        /// Says if this pawn is white.<br/>
        /// <see langword="true"/> if this pawn is white, <see langword="false"/> if this pawn is black.
        /// </summary>
        private bool IsWhite => Color == PlayerColorWBEnum.White;
        #endregion
        
        #region ===== EVENTS =====
        public event EventHandler<bool> IsKingValueChangedEvent;

        public event EventHandler<GridPosition> PositionChanged;

        public event EventHandler<IChecker.PieceMovedEventArgs> PieceMovedEvent;
        #endregion

        #region ===== CONSTRUCTORS =====
        /// <summary>
        /// Initialize this class.
        /// </summary>
        /// <param name="parent">Checkersboard where the pawn will be positioned.</param>
        /// <param name="color">Color of the pawn (white or black).</param>
        /// <param name="startingPosition">Cell where the pawn will be positioned.</param>
        public Checker(CheckersBoard parent, PlayerColorWBEnum color, GridPosition startingPosition)
        {
            _CheckersBoardParent = parent;
            _Color = color;
            _GridPosition = startingPosition;
            _IsKing = false;

            GridPosition.PositionChangedEvent += GridPosition_PositionChangedEvent;
        }
        #endregion

        #region ===== METHODS =====
        public bool Equals(Checker? other)
        {
            return
                other != null &&
                Color.Equals(other.Color) &&
                IsKing.Equals(other.IsKing) &&
                GridPosition.Equals(other.GridPosition);
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj is Checker)
            {
                return ((Checker)obj).Equals(this);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return
                Color.GetHashCode() ^
                IsKing.GetHashCode() ^
                GridPosition.GetHashCode();
        }

        public override string ToString()
        {
            return $"[ Color = {Color} ; IsKing = {IsKing} ; GridPosition = {GridPosition} ]";
        }

        /// <summary>
        /// Retrieve all available move of the pawn.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{AvailableMoveStruct}"/> of available moves, containing the positions and, in case, the pawns that can be eaten.</returns>
        public IEnumerable<AvailableMoveStruct> GetAvailableMoves()
        {
            List<AvailableMoveStruct> moves = new List<AvailableMoveStruct>();

            foreach (GridPosition p in GetAvailableDiagonalCells())
            {
                Checker? positionPawn = CheckersBoardParent.GetPawnByPosition(p);

                if (positionPawn == null)
                {
                    moves.Add(new AvailableMoveStruct()
                    {
                        EatablePiece = null,
                        Move = p,
                    });
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
                            moves.Add(new AvailableMoveStruct()
                            {
                                EatablePiece = positionPawn,
                                Move = nextPosition,
                            });
                        }
                    }
                }
            }

            IEnumerable<AvailableMoveStruct> eatableMoves = moves.Where(m => m.EatablePiece != null);

            return eatableMoves.Count() > 0 ? eatableMoves : moves;
        }

        /// <summary>
        /// Check if the position is an available move.
        /// </summary>
        /// <param name="position">Position to check.</param>
        /// <param name="eatablePawn">(<see langword="out"/>) The piece that can be eaten with the movement, if it is a legal move.</param>
        /// <returns><see langword="true"/> if the position is an available moves, else return <see langword="false"/>.</returns>
        public bool IsAvailableMoves(GridPosition position, out Checker? eatablePawn)
        {
            eatablePawn = null;

            IEnumerable<AvailableMoveStruct> availableMoves = GetAvailableMoves();

            IEnumerable<AvailableMoveStruct> move = availableMoves.Where(gp => gp.Move.Equals(position));

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

        /// <summary>
        /// Check if the position is an available move.
        /// </summary>
        /// <param name="row">Position row to check.</param>
        /// <param name="column">Position column to check.</param>
        /// <param name="eatablePawn">(<see langword="out"/>) The piece that can be eaten with the movement, if it is a legal move.</param>
        /// <returns><see langword="true"/> if the position is an available moves, else return <see langword="false"/>.</returns>
        public bool IsAvailableMoves(int row, int column, out Checker? eatablePawn)
        {
            return IsAvailableMoves(new GridPosition(row, column), out eatablePawn);
        }


        public void Move(GridPosition gridPosition)
        {
            if (IsAvailableMoves(gridPosition, out Checker? eatablePawn))
            {
                bool pieceAte = false;

                if (eatablePawn != null)
                {
                    eatablePawn.Eat();
                    pieceAte = true;
                }

                GridPosition = gridPosition;

                PieceMovedEvent?.Invoke(this, new PieceMovedEventArgs()
                {
                    PieceAte = pieceAte,
                    Position = GridPosition
                });
            }
        }

        /// <summary>
        /// Move pawn into a specific position.
        /// </summary>
        /// <param name="row">Position row where you want to move the pawn.</param>
        /// <param name="column">Position column where you want to move the pawn.</param>
        public void Move(int row, int column)
        {
            Move(new GridPosition(row, column));
        }

        public void Eat()
        {
            CheckersBoardParent.EatPawn(this);
        }

        /// <summary>
        /// Get all nearest diagonal cells.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{GridPosition}"/> containing the nearest diagonal cells.</returns>
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

        /// <summary>
        /// Listener that manage the event <see cref="GridPosition.PositionChangedEvent"/>.<br/>
        /// This will be triggered everytime the value of <see cref="GridPosition"/> is changed.
        /// </summary>
        /// <param name="sender">Sender that trigs the event.<br/>The sender is a <see cref="Objects.GridPosition"/>.</param>
        /// <param name="e">Actual position of the variable.</param>
        private void GridPosition_PositionChangedEvent(object? sender, GridPosition e)
        {
            PositionChanged?.Invoke(this, e);
        }

        public void Promote()
        {
            IsKing = true;
        }

        /// <summary>
        /// Get if the this pawn is available for be promoted as a king.
        /// </summary>
        /// <returns><see langword="true"/> if it can be promoted as a king, <see langword="false"/> otherwise.</returns>
        public bool AvailableForPromotion()
        {
            int kingPosition = IsWhite ? 0 : 7;

            return !IsKing && GridPosition.Row == kingPosition;
        }
        #endregion
    }
}
