using BoardGamesNET.Enums;
using static BoardGamesNET.Classes.Objects.Games.Checkers.Games.LocalGame;

namespace BoardGamesNET.Classes.Objects.Games.Checkers
{
    public class Game
    {
        #region ===== ENUMS =====
        public enum SelectPawnResultEnum
        {
            Ok,
            NoPawnSelected,
            SelectingOppositeColor,
        }
        #endregion

        #region ===== VARIABLES =====

        #region ===== FIELDS FOR VARIABLES =====
        private Dictionary<PlayerColorWBEnum, string> _PlayerNames;
        private CheckersBoard _CheckersBoard;
        private PlayerColorWBEnum _ActualTurn;
        private int _TurnNumber;
        private Pawn? _SelectedPawn;
        #endregion

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

        public Pawn? SelectedPawn
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

        public int TurnNumber => _TurnNumber;

        #endregion

        #region ===== EVENTS =====
        public event EventHandler<PlayerColorWBEnum> ActualTurnChangedEvent;
        public event EventHandler<Pawn?> SelectedPawnChangedEvent;
        public event EventHandler<PawnMovedEventArgs> PawnMovedEvent;
        #endregion

        #region ===== CONSTRUCTORS =====

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
        public SelectPawnResultEnum SelectPawn(Pawn? selectedPawn, bool unselectIfNull = false)
        {
            if (selectedPawn != null)
            {
                if (selectedPawn.Color.Equals(ActualTurnColor))
                {
                    _SelectedPawn = selectedPawn;
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

        public void ChangeTurn()
        {
            ActualTurnColor = ActualTurnColor == PlayerColorWBEnum.White ? PlayerColorWBEnum.Black : PlayerColorWBEnum.White;
        }

        public SelectPawnResultEnum UnselectPawn()
        {
            return SelectPawn(null, true);
        }

        private void CheckersBoard_PawnMovedEvent(object? sender, CheckersBoard.PawnMovedEventArgs e)
        {
            UnselectPawn();
            ChangeTurn();

            if (sender != null && sender is CheckersBoard)
            {
                PawnMovedEvent?.Invoke(this, new PawnMovedEventArgs((CheckersBoard)sender, e.Pawn, e.GridPosition)); 
            }
        }
        #endregion

        #region ===== NESTED CLASSES =====
        public class PawnMovedEventArgs : CheckersBoard.PawnMovedEventArgs
        {
            #region ===== VARIABLES =====
            #region ===== FIELDS FOR VARIABLES =====
            private CheckersBoard _CheckersBoard;
            #endregion

            public CheckersBoard CheckersBoard => _CheckersBoard;
            #endregion

            #region ===== CONSTRUCTORS =====
            public PawnMovedEventArgs(CheckersBoard cBoard, Pawn pawn, GridPosition gridPosition) : base(pawn, gridPosition)
            {
                _CheckersBoard = cBoard;
            }
            #endregion
        }
        #endregion

    }
}
