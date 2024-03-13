using BoardGamesNET.Classes.Utils;
using BoardGamesNET.Enums;
using BoardGamesNET.Exceptions.Games.Checkers;
using System.CodeDom;
using System.Data.Entity.Core.Mapping;
using System.Reflection;

namespace BoardGamesNET.Classes.Objects.Games.Checkers
{
    /// <summary>
    /// Class that rapresents the checkersboard of the checkers game.
    /// </summary>
    public class CheckersBoard
    {

        #region ===== VARIABLES =====

        #region ==== FIELDS FOR VARIABLES =====
        private List<Checker> _Pawns;
        private Game _ParentGame;
        private IEnumerable<Checker>? _ForcedEater = default;
        #endregion

        /// <summary>
        /// List of pawns (<see cref="Checker"/>) contained in this checkersboard.
        /// </summary>
        public List<Checker> Pawns
        {
            get
            {
                return _Pawns;
            }
            set
            {
                if (value != _Pawns)
                {
                    _Pawns = value;
                }
            }
        }

        /// <summary>
        /// Game parent.
        /// </summary>
        public Game ParentGame
        {
            get
            {
                return _ParentGame;
            }
            set
            {
                if (value != _ParentGame)
                {
                    _ParentGame = value;
                }
            }
        }

        /// <summary>
        /// Pawns that must eat another pawn.
        /// </summary>
        public IEnumerable<Checker>? ForcedEater
        {
            get
            {
                return _ForcedEater;
            }
            set
            {
                if (value == null || value.Count() <= 0)
                {
                    _ForcedEater = null;
                }
                else
                {
                    _ForcedEater = value;
                }

                ForcedEaterValueChangedEvent?.Invoke(this, _ForcedEater);
            }
        }

        #endregion

        #region ===== EVENTS =====
        /// <summary>
        /// Event that is triggered everytime a pawn on this chessboard is moved.
        /// </summary>
        public event EventHandler<PawnMovedEventArgs> PawnMovedEvent;

        /// <summary>
        /// Event that is triggered everytime the list of checkers that are forced to eat changed.
        /// </summary>
        public event EventHandler<IEnumerable<Checker>?> ForcedEaterValueChangedEvent;
        #endregion

        #region ===== CONSTRUCTORS =====
        /// <summary>
        /// Build a new checkersboard
        /// </summary>
        /// <param name="parentGame">Game parent</param>
        public CheckersBoard(Game parentGame)
        {
            ParentGame = parentGame;

            InitializePawns();

            ParentGame.ActualTurnChangedEvent += ParentGame_ActualTurnChangedEvent;
        }
        #endregion

        #region ===== METHODS =====
        /// <summary>
        /// Retrieve a pawn (<see cref="Checker"/>) by the position.
        /// </summary>
        /// <param name="position">Position where you think that there is a pawn.</param>
        /// <returns><see cref="Checker"/> if there is a pawn in that position, otherwise <see langword="null"/>.</returns>
        public Checker? GetPawnByPosition(GridPosition position)
        {
            return Pawns.FirstOrDefault(p => p.GridPosition.Equals(position));
        }

        /// <summary>
        /// Delete a <see cref="Checker"> into a checkersboard.
        /// </summary>
        /// <param name="piece">Pawn to remove (eat).</param>
        /// <exception cref="PawnNotInCheckersBoardException">Pawn is not in checkersboard.</exception>
        public void EatPawn(Checker piece)
        {
            if (!Pawns.Remove(piece))
            {
                throw new PawnNotInCheckersBoardException();
            }
        }

        /// <summary>
        /// Check if a grid position is inside the checkersboard.
        /// </summary>
        /// <param name="position">Grid position to check.</param>
        /// <returns><see langword="true"/> if position is inside the checkersboard, <see langword="false"/> otherwise.</returns>
        public static bool IsInCheckersBoard(GridPosition position)
        {
            return
                UMath.Beetween(position.Row, 0, 7) &&
                UMath.Beetween(position.Column, 0, 7);
        }

        /// <summary>
        /// Check if a grid position is inside the checkersboard.
        /// </summary>
        /// <param name="row">Row of the checkersboard.</param>
        /// <param name="column">Column of the checkersboard.</param>
        /// <returns><see langword="true"/> if position is inside the checkersboard, <see langword="false"/> otherwise.</returns>
        public static bool IsInCheckersBoard(int row, int column)
        {
            return IsInCheckersBoard(new GridPosition(row, column));
        }

        /// <summary>
        /// Check if a grid or column is inside the checkersboard.
        /// </summary>
        /// <param name="rowOrColumn">Row or column to check.</param>
        /// <returns><see langword="true"/> if position is inside the checkersboard, <see langword="false"/> otherwise.</returns>
        public static bool IsInCheckersBoard(int rowOrColumn)
        {
            return UMath.Beetween(rowOrColumn, 0, 7);
        }

        /// <summary>
        /// Retrieve all pawns into a checkersboard by color.
        /// </summary>
        /// <param name="color">Pawn color of the pawns that you want retrieve.</param>
        /// <returns><see cref="IEnumerable{Pawn}"/> containing the list of the pawns into this checkersboard with the choosen color.</returns>
        public IEnumerable<Checker> GetColoredPawns(PlayerColorWBEnum color)
        {
            return Pawns.Where(p => p.Color.Equals(color));
        }

        /// <summary>
        /// Retrieve all pawns that can eat an opposite pawn.
        /// </summary>
        /// <param name="eaterColor">Color of the eaters.</param>
        /// <returns></returns>
        public IEnumerable<Checker> GetPawnsThatCanEat(PlayerColorWBEnum eaterColor)
        {
            IEnumerable<Checker> pawns = GetColoredPawns(eaterColor);

            foreach (Checker pawn in pawns)
            {
                if (pawn.GetAvailableMoves().Where(m => m.EatablePiece != null).Count() > 0)
                {
                    yield return pawn;
                }
            }
        }

        /// <summary>
        /// Initialize the pawns into the checkersboard.
        /// </summary>
        private void InitializePawns()
        {
            Pawns = new List<Checker>(0);

            Pawns.AddRange(GetStartingPawns(PlayerColorWBEnum.White));
            Pawns.AddRange(GetStartingPawns(PlayerColorWBEnum.Black));

            foreach (Checker p in Pawns)
            {
                p.PositionChanged += OnPawnPositionChangedEvent;
            }
        }

        /// <summary>
        /// Retrieve starting pawns by color.
        /// </summary>
        /// <param name="color">Color of the starting pawns.</param>
        /// <returns><see cref="IEnumerable{Pawn}"/> pawns positioned into their starting cell.</returns>
        private IEnumerable<Checker> GetStartingPawns(PlayerColorWBEnum color)
        {
            int startingRow = color == PlayerColorWBEnum.White ? 7 : 0;
            int endingRow = color == PlayerColorWBEnum.White ? 5 : 2;
            int incrementor = color == PlayerColorWBEnum.White ? -1 : 1;

            for (int r = startingRow; UMath.Beetween(r, startingRow, endingRow); r += incrementor)
            {
                for (int c = (r + 1) % 2; c < 8; c += 2)
                {
                    yield return new Checker(this, color, new GridPosition(r, c));
                }
            }
        }

        /// <summary>
        /// Listener that manage the event <see cref="Checker.PositionChanged"/>.<br/>
        /// This is triggered when a pawn is moved.
        /// </summary>
        /// <param name="sender">Sender that trigger the event.<br/> It should be a <see cref="Checker"/>.</param>
        /// <param name="e">New position of the <see cref="Checker"/>.</param>
        /// <exception cref="ArgumentNullException">Sender is <see langword="null"/>.</exception>
        private void OnPawnPositionChangedEvent(object? sender, GridPosition e)
        {
            if (sender != null && sender is Checker)
            {
                PawnMovedEvent?.Invoke(this, new PawnMovedEventArgs((Checker)sender, e)); 
            }
            else
            {
                throw new ArgumentNullException("Sender is null.");
            }
        }

        /// <summary>
        /// Listener that manage the event <see cref="Game.ActualTurnChangedEvent"/>.<br/>
        /// This is triggered when the actual turn change color.
        /// </summary>
        /// <param name="sender">Sender that trigger the event.<br/> It should be a <see cref="Game"/>.</param>
        /// <param name="e">Color of the actual turn.</param>
        private void ParentGame_ActualTurnChangedEvent(object? sender, PlayerColorWBEnum e)
        {
            ForcedEater = GetPawnsThatCanEat(e);
        }
        #endregion

        #region ===== NESTED CLASSES =====
        /// <summary>
        /// Event args used for event <see cref="PawnMovedEvent"/>.
        /// </summary>
        public class PawnMovedEventArgs
        {
            #region ===== VARIABLES =====

            #region ===== FIELDS FOR VARIABLES
            private Checker _Pawn;
            private GridPosition _GridPosition;
            #endregion

            /// <summary>
            /// Pawn that triggered the event.
            /// </summary>
            public Checker Pawn => _Pawn;

            /// <summary>
            /// New position of the pawn (<see cref="Pawn"/>).
            /// </summary>
            public GridPosition GridPosition => _GridPosition;
            #endregion

            #region ===== CONSTRUCTORS =====
            /// <summary>
            /// Initialize this class.
            /// </summary>
            /// <param name="pawn">Pawn that triggered the event.</param>
            /// <param name="gridPosition">New grid position of the pawn.</param>
            public PawnMovedEventArgs(Checker pawn, GridPosition gridPosition)
            {
                _Pawn = pawn;
                _GridPosition = gridPosition;
            }
            #endregion
        }
        #endregion
    }
}
