using BoardGamesNET.Classes.CustomComponents;
using BoardGamesNET.Classes.Objects;
using BoardGamesNET.Classes.Objects.Games.Checkers;
using BoardGamesNET.Classes.Objects.Games.Checkers.Games;
using System.Diagnostics;

namespace BoardGamesNET.Classes.Forms.Games.Checkers
{
    public partial class HotseatGameForm : Form
    {
        #region ===== VARIABLES =====

        #region ===== FIELDS FOR VARIABLES =====
        private GridPanel[,] _CheckersBoardPanels;
        private LocalGame _Game;
        #endregion

        private GridPanel[,] CheckersBoardPanels
        {
            get
            {
                return _CheckersBoardPanels;
            }
            set
            {
                if (value != _CheckersBoardPanels)
                {
                    _CheckersBoardPanels = value;
                }
            }
        }

        private LocalGame Game
        {
            get
            {
                return _Game;
            }
            set
            {
                if (value != _Game)
                {
                    _Game = value;
                }
            }
        }

        #endregion

        #region ===== CONSTRUCTOR =====
        public HotseatGameForm(string whitesPlayerName, string blacksPlayerName)
        {
            Game = new LocalGame(whitesPlayerName, blacksPlayerName);

            InitializeComponent();
            InitializeGridPanels(cellSize: 100, margin: 5);

            Translate();

            UpdateGraphics();

            Program.cSettingsManager.ActiveLanguageChangedValueEvent += CSettingsManager_ActiveLanguageChangedValueEvent;
            Game.SelectedPawnChangedEvent += Game_SelectedPawnChangedEvent;
        }
        #endregion

        #region ===== METHODS =====
        private void CSettingsManager_ActiveLanguageChangedValueEvent(object? sender, string e)
        {
            Translate();
        }

        private void Translate()
        {
            Text = $"[💻] [{Program.cRegionManager.GetTranslatedText(18)}] {Program.cRegionManager.GetTranslatedText(22)}";
        }

        private void InitializeGridPanels(int cellSize, int margin)
        {
            CheckersBoardPanels = new GridPanel[8, 8];

            for (int r = 0; r < CheckersBoardPanels.GetLength(0); r++)
            {
                for (int c = 0; c < CheckersBoardPanels.GetLength(1); c++)
                {
                    CheckersBoardPanels[r, c] = new GridPanel(r, c)
                    {
                        Location = new Point((c * cellSize) + margin, (r * cellSize) + margin),
                        Size = new Size(cellSize - (margin * 2), cellSize - (margin * 2)),
                        BackColor = Color.Transparent,
                        BackgroundImageLayout = ImageLayout.Zoom,
                    };

                    CheckersBoardPanel.Controls.Add(CheckersBoardPanels[r, c]);

                    CheckersBoardPanels[r, c].MouseUp += OnCheckersBoardPanelMouseReleased;
                }
            }
        }

        private void OnCheckersBoardPanelMouseReleased(object? sender, EventArgs e)
        {
            if (sender != null && sender is GridPanel)
            {
                GridPanel clickedPanel = (GridPanel)sender;
                Debug.WriteLine(clickedPanel.GridPosition);

                Pawn? selectedElement = Game.CheckersBoard.GetPawnByPosition(clickedPanel.GridPosition);
                Debug.WriteLine(selectedElement);

                if (Game.SelectedPawn == null)
                {
                    if (selectedElement != null && selectedElement.Color.Equals(Game.ActualTurnColor))
                    {
                        Game.SelectPawn(selectedElement);
                    }
                }
                else
                {
                    if (selectedElement == null)
                    {
                        if (Game.SelectedPawn.IsAvailableMoves(clickedPanel.GridPosition))
                        {
                            Game.SelectedPawn.Move(clickedPanel.GridPosition);
                        }
                        else
                        {
                            Game.UnselectPawn();
                        }
                    }
                    else if (!selectedElement.Color.Equals(Game.ActualTurnColor))
                    {
                        Game.UnselectPawn();
                    }
                    else
                    {
                        Game.SelectPawn(selectedElement);
                    }
                }
            }
        }

        private void UpdateGraphics()
        {
            ClearGrid();

            InsertPawns();
        }

        private void ClearGrid()
        {
            foreach (GridPanel p in CheckersBoardPanels)
            {
                p.BackgroundImage = null;
            }
        }

        private void InsertPawns()
        {
            foreach (Pawn p in Game.CheckersBoard.Pawns)
            {
                CheckersBoardPanels[p.GridPosition.Row, p.GridPosition.Column].BackgroundImage = p.Image;
            }
        }

        private void Game_SelectedPawnChangedEvent(object? sender, Pawn? e)
        {
            ClearSelection();

            if (e != null)
            {
                ShowSelectedPawnAndAvailabelMoves(e);
            }
        }

        private void ClearSelection()
        {
            foreach (GridPanel p in CheckersBoardPanels)
            {
                p.BackColor = Color.Transparent;
            }
        }

        private void ShowSelectedPawnAndAvailabelMoves(Pawn pawn)
        {
            CheckersBoardPanels[pawn.GridPosition.Row, pawn.GridPosition.Column].BackColor = Color.Yellow;

            IEnumerable<GridPosition> availableMoves = pawn.GetAvailableMoves();

            foreach (GridPosition move in availableMoves)
            {
                CheckersBoardPanels[move.Row, move.Column].BackColor = Color.LawnGreen;
            }
        }

        #endregion
    }
}
