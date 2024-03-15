using BoardGamesNET.Enums;
using System.Data.Entity.Infrastructure;
using static BoardGamesNET.Classes.Objects.Games.Checkers.Games.LocalGame;

namespace BoardGamesNET.Classes.Objects.Games.Checkers
{
    /// <summary>
    /// Class that rapresents the game of the checkers.
    /// </summary>
    public class Game
    {
        #region ===== ENUMS =====
        /// <summary>
        /// Result for selecting a pawn.
        /// </summary>
        public enum SelectPawnResultEnum
        {
            /// <summary>
            /// Pawn is correctly selected.
            /// </summary>
            Ok,

            /// <summary>
            /// No pawn is selected.
            /// </summary>
            NoPawnSelected,

            /// <summary>
            /// A pawn with the opposite color of the actual turn is selected.
            /// </summary>
            SelectingOppositeColor,

            /// <summary>
            /// A not forced eater pawn is selecting.
            /// </summary>
            SelectingANotForcedEaterPawn,
        }
        #endregion

        #region ===== VARIABLES =====

        #region ===== FIELDS FOR VARIABLES =====
        private Dictionary<PlayerColorWBEnum, string> _PlayerNames;
        private CheckersBoard _CheckersBoard;
        private PlayerColorWBEnum _ActualTurn;
        private int _TurnNumber;
        private Checker? _SelectedPawn;
        #endregion

        /// <summary>
        /// White and black player names.
        /// </summary>
        public Dictionary<PlayerColorWBEnum, string> PlayerNames
        {
            get
            {
                return _PlayerNames;
            }
            init
            {
                _PlayerNames = value;
            }
        }

        /// <summary>
        /// Instance of a class that rapresents the checkersboard.
        /// </summary>
        public CheckersBoard CheckersBoard
        {
            get
            {
                return _CheckersBoard;
            }
            set
            {
                if (value != _CheckersBoard)
                {
                    _CheckersBoard = value;
                }
            }
        }

        /// <summary>
        /// Color of the actual turn (white or black).
        /// </summary>
        public PlayerColorWBEnum ActualTurnColor
        {
            get
            {
                return _ActualTurn;
            }
            private set
            {
                if (value != _ActualTurn)
                {
                    _ActualTurn = value;
                    ActualTurnChangedEvent?.Invoke(this, value);
                }
            }
        }

        /// <summary>
        /// Actual selected pawn.<br/>
        /// If this variable is <see langword="null"/> it means that no pawn is selected.
        /// </summary>
        public Checker? SelectedPawn
        {
            get
            {
                return _SelectedPawn;
            }
            private set
            {
                if (!value.Equals(_SelectedPawn))
                {
                    _SelectedPawn = value;
                    SelectedPawnChangedEvent?.Invoke(this, value);
                }
            }
        }

        /// <summary>
        /// Turn counter.
        /// </summary>
        public int TurnNumber => _TurnNumber;

        #endregion

        #region ===== EVENTS =====
        /// <summary>
        /// Event that is triggered everytime the turn color is changed.
        /// </summary>
        public event EventHandler<PlayerColorWBEnum> ActualTurnChangedEvent;

        /// <summary>
        /// Event that is triggered everytime the selected pawn is changed.
        /// </summary>
        public event EventHandler<Checker?> SelectedPawnChangedEvent;

        /// <summary>
        /// Event that is triggered everytime a pawn is moved.
        /// </summary>
        public event EventHandler<PawnMovedEventArgs> PawnMovedEvent;
        #endregion

        #region ===== CONSTRUCTORS =====

        /// <summary>
        /// Initialize this class
        /// </summary>
        /// <param name="whitesPlayerName">Username of the player that plays white pawns.</param>
        /// <param name="blacksPlayerName">Username of the player that plays black pawns.</param>
        public Game(string whitesPlayerName, string blacksPlayerName)
        {
            PlayerNames = new Dictionary<PlayerColorWBEnum, string>()
            {
                [PlayerColorWBEnum.White] = whitesPlayerName,
                [PlayerColorWBEnum.Black] = blacksPlayerName,
            };

            CheckersBoard = new CheckersBoard(this);

            CheckersBoard.PawnMovedEvent += CheckersBoard_PawnMovedEvent;
        }

        #endregion

        #region ===== METHODS =====
        /// <summary>
        /// Select the passed pawn.
        /// </summary>
        /// <param name="selectedPawn">Pawn that you want to select.</param>
        /// <param name="unselectIfNull">If you set this variable at <see langword="true"/>, if you pass a null value at <paramref name="selectedPawn"/>, you unselect the pawn.<br/>
        /// Default value is <see langword="false"/>.</param>
        /// <returns>
        /// - <c>[<see cref="SelectPawnResultEnum.Ok"/>]</c> if pawn is correctly selected (or unselected).<br/>
        /// - <c>[<see cref="SelectPawnResultEnum.NoPawnSelected"/>]</c> if value in <paramref name="selectedPawn"/> is <see langword="null"/> and <paramref name="unselectIfNull"/> is <see langword="false"/>.<br/>
        /// - <c>[<see cref="SelectPawnResultEnum.SelectingOppositeColor"/>]</c> if is selecting a pawn of the color that is different from the actual color.
        /// </returns>
        public SelectPawnResultEnum SelectPawn(Checker? selectedPawn, bool unselectIfNull = false)
        {
            if (selectedPawn != null)
            {
                if (selectedPawn.Color.Equals(ActualTurnColor))
                {
                    if (CheckersBoard.ForcedEater == null)
                    {
                        _SelectedPawn = selectedPawn; 
                    }
                    else
                    {
                        if (CheckersBoard.ForcedEater.Contains(selectedPawn))
                        {
                            _SelectedPawn = selectedPawn;
                        }
                        else
                        {
                            return SelectPawnResultEnum.SelectingANotForcedEaterPawn;
                        }
                    }
                }
                else
                {
                    return SelectPawnResultEnum.SelectingOppositeColor;
                }
            }
            else
            {
                if (unselectIfNull)
                {
                    _SelectedPawn = null;
                }
                else
                {
                    return SelectPawnResultEnum.NoPawnSelected;
                }
            }

            SelectedPawnChangedEvent?.Invoke(this, _SelectedPawn);
            return SelectPawnResultEnum.Ok;
        }

        /// <summary>
        /// Switch turn from white to black or viceversa.
        /// </summary>
        public void ChangeTurn()
        {
            ActualTurnColor = ActualTurnColor == PlayerColorWBEnum.White ? PlayerColorWBEnum.Black : PlayerColorWBEnum.White;
        }

        /// <summary>
        /// Unselect the pawn.
        /// </summary>
        /// <returns>
        /// - <c>[<see cref="SelectPawnResultEnum.Ok"/>]</c> if pawn is correctly unselected.<br/>
        /// - <c>[<see cref="SelectPawnResultEnum.NoPawnSelected"/>]</c> won't be returned.<br/>
        /// - <c>[<see cref="SelectPawnResultEnum.SelectingOppositeColor"/>]</c> won't be returned.
        /// </returns>
        public SelectPawnResultEnum UnselectPawn()
        {
            return SelectPawn(null, true);
        }

        /// <summary>
        /// Listener that manage the event <see cref="CheckersBoard.PawnMovedEvent"/>.<br/>
        /// This event is triggered everytime a pawn is moved.
        /// </summary>
        /// <param name="sender">Object that triggers the event.<br/> The sender is a <c>[<see cref="Checkers.CheckersBoard"/>]</c>.</param>
        /// <param name="e">Argumensts of the event containing information of the checkersboard where the pawn is moved, the pawn that is moved and the actual position of the pawn that is moved.</param>
        private void CheckersBoard_PawnMovedEvent(object? sender, CheckersBoard.PawnMovedEventArgs e)
        {
            if (e.Pawn.AvailableForPromotion())
            {
                e.Pawn.Promote();
            }

            UnselectPawn();
            ChangeTurn();

            if (sender != null && sender is CheckersBoard)
            {
                PawnMovedEvent?.Invoke(this, new PawnMovedEventArgs((CheckersBoard)sender, e.Pawn, e.GridPosition)); 
            }
        }
        #endregion

        #region ===== NESTED CLASSES =====
        /// <summary>
        /// Event args used for event <see cref="PawnMovedEvent"/>.
        /// </summary>
        public class PawnMovedEventArgs : CheckersBoard.PawnMovedEventArgs
        {
            #region ===== VARIABLES =====
            #region ===== FIELDS FOR VARIABLES =====
            private CheckersBoard _CheckersBoard;
            #endregion

            /// <summary>
            /// Checkersboard where pawn was moved.
            /// </summary>
            public CheckersBoard CheckersBoard => _CheckersBoard;
            #endregion

            #region ===== CONSTRUCTORS =====
            /// <summary>
            /// Initialize the class.
            /// </summary>
            /// <param name="cBoard">Checkersboard where the pawn was moved.</param>
            /// <param name="pawn">Pawn that is moved.</param>
            /// <param name="gridPosition">Actual position of the moved pawn.</param>
            public PawnMovedEventArgs(CheckersBoard cBoard, Checker pawn, GridPosition gridPosition) : base(pawn, gridPosition)
            {
                _CheckersBoard = cBoard;
            }
            #endregion
        }
        #endregion

    }
}
