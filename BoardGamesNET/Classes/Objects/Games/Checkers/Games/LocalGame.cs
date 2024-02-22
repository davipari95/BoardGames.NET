using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Classes.Objects.Games.Checkers.Games
{
    public class LocalGame : Game
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

        #region ===== FIELDS FOR VARIABELS =====
        private Pawn? _SelectedPawn;
        #endregion

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

        #endregion

        #region ===== EVENTS =====
        public event EventHandler<Pawn?> SelectedPawnChangedEvent;
        #endregion

        #region ===== CONSTRUCTORS =====
        public LocalGame(string whitesPlayerName, string blacksPlayerName) : base(whitesPlayerName, blacksPlayerName)
        {
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

        public SelectPawnResultEnum UnselectPawn()
        {
            return SelectPawn(null, true);
        }

        #endregion
    }
}
