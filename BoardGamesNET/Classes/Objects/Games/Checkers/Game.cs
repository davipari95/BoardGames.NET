using BoardGamesNET.Enums;

namespace BoardGamesNET.Classes.Objects.Games.Checkers
{
    public class Game
    {
        #region ===== VARIABLES =====

        #region ===== FIELDS FOR VARIABLES =====
        private Dictionary<PlayerColorWBEnum, string> _PlayerNames;
        private CheckersBoard _CheckersBoard;
        private PlayerColorWBEnum _ActualTurn;
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

        public PlayerColorWBEnum ActualTurn
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

        #endregion

        #region ===== EVENTS =====
        public event EventHandler<PlayerColorWBEnum> ActualTurnChangedEvent;
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
        }

        #endregion

        #region ===== METHODS =====
        public void ChangeTurn()
        {
            ActualTurn = ActualTurn == PlayerColorWBEnum.White ? PlayerColorWBEnum.Black : PlayerColorWBEnum.White;
        }
        #endregion

    }
}
