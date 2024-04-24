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

            /// <summary>
            /// A forced selected pawn is actually selected.
            /// </summary>
            SelectionForced,
        }

        /// <summary>
        /// What you want to retrieve with the function <see cref="GetTranslatetInfoText(InfoText)"/>.
        /// </summary>
        public enum InfoText
        {
            /// <summary>
            /// Information about whose turn it is right now.
            /// </summary>
            ActualTurnName,
        }
        #endregion

        #region ===== VARIABLES =====

        #region ===== FIELDS FOR VARIABLES =====
        private Dictionary<PlayerColorWBEnum, string> _PlayerNames;
        private CheckersBoard _CheckersBoard;
        private PlayerColorWBEnum _ActualTurn;
        private int _TurnNumber;
        private Checker? _SelectedPawn;
        private bool _SelectionForced;
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

        /// <summary>
        /// Information about if a selection is forced.<br/>
        /// This is used, for example, if a checker must eat more than one opposite checker.
        /// </summary>
        public bool SelectionForced
        {
            get
            {
                return _SelectionForced;
            }
            set
            {
                if (value != _SelectionForced)
                {
                    _SelectionForced = value;
                }
            }
        }
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
        public event EventHandler<PawnPositionChangedEventArgs> PawnPositionChangedEvent;

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

            CheckersBoard.PawnPositionChangedEvent += OnCheckersBoardPawnPositionChangedEvent;
            CheckersBoard.PawnMovedEvent += OnCheckersBoardPawnMovedEvent;
        }

        #endregion

        #region ===== METHODS =====
        /// <summary>
        /// Select the passed pawn.
        /// </summary>
        /// <param name="selectedPawn">Pawn that you want to select.</param>
        /// <param name="unselectIfNull">If you set this variable at <see langword="true"/>, if you pass a null value at <paramref name="selectedPawn"/>, you unselect the pawn.<br/>
        /// Default value is <see langword="false"/>.</param>
        /// <param name="forceSelection">If you set this variable at <see langword="true"/>, you select the pawn passed on <paramref name="selectedPawn"/> without the possibility to change it.<br/>
        /// Default value is <see langword="false"/>.</param>
        /// <returns>
        /// - <c>[<see cref="SelectPawnResultEnum.Ok"/>]</c> if pawn is correctly selected (or unselected).<br/>
        /// - <c>[<see cref="SelectPawnResultEnum.NoPawnSelected"/>]</c> if value in <paramref name="selectedPawn"/> is <see langword="null"/> and <paramref name="unselectIfNull"/> is <see langword="false"/>.<br/>
        /// - <c>[<see cref="SelectPawnResultEnum.SelectingOppositeColor"/>]</c> if is selecting a pawn of the color that is different from the actual color.<br/>
        /// - <c>[<see cref="SelectPawnResultEnum.SelectionForced"/>]</c> at the moment there is a forced selection enabled.
        /// </returns>
        public SelectPawnResultEnum SelectPawn(Checker? selectedPawn, bool unselectIfNull = false, bool forceSelection = false)
        {
            if (SelectionForced)
            {
                return SelectPawnResultEnum.SelectionForced;
            }

            if (selectedPawn != null)
            {
                if (selectedPawn.Color.Equals(ActualTurnColor))
                {
                    if (CheckersBoard.ForcedEater == null)
                    {
                        _SelectedPawn = selectedPawn;
                        SelectionForced = forceSelection;
                    }
                    else
                    {
                        if (CheckersBoard.ForcedEater.Contains(selectedPawn))
                        {
                            _SelectedPawn = selectedPawn;
                            SelectionForced = forceSelection;
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
                    SelectionForced = false;
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
        /// Retrieve a string to write on info label game form.
        /// </summary>
        /// <param name="toRetrieve">What you want to retrieve.</param>
        /// <returns>A required translated string.</returns>
        /// <exception cref="ArgumentException">Value on <paramref name="toRetrieve"/> is not valid.</exception>
        public string GetTranslatetInfoText(InfoText toRetrieve)
        {
            switch (toRetrieve)
            {
                case InfoText.ActualTurnName:
                    return Program.cRegionManager.GetTranslatedText(23, null, PlayerNames[ActualTurnColor]);
                default:
                    throw new ArgumentException("Translated info text parameter is not valid.");
            }
        }

        /// <summary>
        /// Listener that manage the event <see cref="CheckersBoard.PawnPositionChangedEvent"/>.<br/>
        /// This event is triggered everytime a pawn is moved.
        /// </summary>
        /// <param name="sender">Object that triggers the event.<br/> The sender is a <c>[<see cref="Checkers.CheckersBoard"/>]</c>.</param>
        /// <param name="e">Argumensts of the event containing information of the checkersboard where the pawn is moved, the pawn that is moved and the actual position of the pawn that is moved.</param>
        private void OnCheckersBoardPawnPositionChangedEvent(object? sender, CheckersBoard.PawnPositionChangedEventArgs e)
        {
            if (sender != null && sender is CheckersBoard)
            {
                PawnPositionChangedEvent?.Invoke(this, new PawnPositionChangedEventArgs((CheckersBoard)sender, e.Pawn, e.GridPosition)); 
            }
        }

        /// <summary>
        /// Listener that manage the event <see cref="CheckersBoard.PawnMovedEvent"/>.<br/>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="ArgumentNullException"></exception>
        private void OnCheckersBoardPawnMovedEvent(object? sender, CheckersBoard.PawnMovedEventArgs e)
        {
            bool pass = true;

            if (e.Pawn.AvailableForPromotion())
            {
                e.Pawn.Promote();
            }
            else if (!e.Pawn.IsKing && e.EatedPiece != null)
            {
                IEnumerable<Checker.AvailableMoveStruct> availableMoves = e.Pawn.GetAvailableMoves();

                if (availableMoves.Where(m => m.EatablePiece != null).Count() > 0)
                {
                    SelectPawn(e.Pawn, forceSelection: true);
                    pass = false;
                }
            }

            if (pass)
            {
                UnselectPawn();
                ChangeTurn(); 
            }

            if (sender != null && sender is CheckersBoard)
            {
                CheckersBoard board = (CheckersBoard)sender;

                PawnMovedEvent?.Invoke(this, new PawnMovedEventArgs(board, e.Pawn, e.Position, (Checker?)e.EatedPiece));
            }
        }
        #endregion

        #region ===== NESTED CLASSES =====
        /// <summary>
        /// Event args used for event <see cref="PawnPositionChangedEvent"/>.
        /// </summary>
        public class PawnPositionChangedEventArgs : CheckersBoard.PawnPositionChangedEventArgs
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
            public PawnPositionChangedEventArgs(CheckersBoard cBoard, Checker pawn, GridPosition gridPosition) : base(pawn, gridPosition)
            {
                _CheckersBoard = cBoard;
            }
            #endregion
        }

        /// <summary>
        /// Event args used for event <see cref="PawnMovedEvent"/>
        /// </summary>
        public class PawnMovedEventArgs : CheckersBoard.PawnMovedEventArgs
        {

            #region ===== FIELDS =====
            private CheckersBoard _CheckersBoard;
            #endregion

            #region ===== VARIABLES =====
            /// <summary>
            /// Checkersboard where the pawn was moved.
            /// </summary>
            public CheckersBoard CheckersBoard => _CheckersBoard;
            #endregion

            #region ===== CONSTRUCTORS =====
            /// <summary>
            /// Constructor for the event args.
            /// </summary>
            /// <param name="cBoard">Chessboard where pawn was moved.</param>
            /// <param name="movedPawn">Pawn that was moved.</param>
            /// <param name="gridPosition">New position of the moved pawn.</param>
            /// <param name="eatedPiece">Piece that has been eated.<br/>Set it <see langword="null"/> if no piece has been eated.</param>
            public PawnMovedEventArgs(CheckersBoard cBoard, Checker movedPawn, GridPosition gridPosition, Checker? eatedPiece) : base(movedPawn, gridPosition, eatedPiece)
            {
                _CheckersBoard = cBoard;
            }
            #endregion

        }
        #endregion

    }
}
