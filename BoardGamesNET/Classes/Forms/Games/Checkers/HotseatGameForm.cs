using BoardGamesNET.Classes.CustomComponents;
using BoardGamesNET.Classes.Forms.Dialogs;
using BoardGamesNET.Classes.Objects;
using BoardGamesNET.Classes.Objects.Games.Checkers;
using BoardGamesNET.Classes.Objects.Games.Checkers.Games;
using BoardGamesNET.Exceptions.Games.Checkers;
using System.Data.Entity;
using System.Diagnostics;

namespace BoardGamesNET.Classes.Forms.Games.Checkers
{
    /// <summary>
    /// Form that is used for playing the game of the checkers in hot-seat mode.
    /// </summary>
    public partial class HotseatGameForm : Form
    {
        #region ===== VARIABLES =====

        #region ===== FIELDS FOR VARIABLES =====
        private GridPanel[,] _CheckersBoardPanels;
        private LocalGame _Game;
        #endregion

        /// <summary>
        /// Panels disposed on a checkersboard.<br/>
        /// Each panel is a cell.
        /// </summary>
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

        /// <summary>
        /// Class containing the local game of the checkersboard.
        /// </summary>
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

        /// <summary>
        /// Initialize the form.
        /// </summary>
        /// <param name="whitesPlayerName">Username of the player that use white checkers.</param>
        /// <param name="blacksPlayerName">Username of the player that use black checkers.</param>
        public HotseatGameForm(string whitesPlayerName, string blacksPlayerName)
        {
            Game = new LocalGame(whitesPlayerName, blacksPlayerName);

            InitializeComponent();
            InitializeGridPanels(cellSize: 100, margin: 5);

            Translate();

            UpdateGraphics();

            Program.cSettingsManager.ActiveLanguageChangedValueEvent += CSettingsManager_ActiveLanguageChangedValueEvent;
            Game.SelectedPawnChangedEvent += Game_SelectedPawnChangedEvent;
            Game.ActualTurnChangedEvent += Game_ActualTurnChangedEvent;
            Game.PawnMovedEvent += Game_PawnMovedEvent;
            Game.GameIsOverEvent += Game_GameIsOverEvent;
        }
        #endregion

        #region ===== METHODS =====
        /// <summary>
        /// Listener of the event <see cref="SettingsManager.ActiveLanguageChangedValueEvent"/>.<br/>
        /// This is triggered when someone is changing the language.
        /// </summary>
        /// <param name="sender">Sender that trigger the event.<br/>The sender is <see cref="SettingsManager"/>.</param>
        /// <param name="e">New language code</param>
        private void CSettingsManager_ActiveLanguageChangedValueEvent(object? sender, string e)
        {
            Translate();
        }

        /// <summary>
        /// Translate everything into the form.
        /// </summary>
        private void Translate()
        {
            Text = $"[💻] [{Program.cRegionManager.GetTranslatedText(18)}] {Program.cRegionManager.GetTranslatedText(22)}";

            UpdateInfo(Objects.Games.Checkers.Game.InfoText.ActualTurnName);

            Program.cRegionManager.TranslateAllElementsInControl(this);
        }

        /// <summary>
        /// Dispose the cells (<see cref="CheckersBoardPanels"/>) into the form.
        /// </summary>
        /// <param name="cellSize">Width and height of the cells</param>
        /// <param name="margin">Margin of the cell.</param>
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

        /// <summary>
        /// Listener that manage the event <see cref="Control.MouseUp"/>.<br/>
        /// This is triggered when you click on a cell of the checkersboard.
        /// </summary>
        /// <param name="sender">Cells that triggered this event.<br/>The sender is always a <see cref="GridPanel"/>.</param>
        /// <param name="e">Event args.<br/>This is always empty.</param>
        private void OnCheckersBoardPanelMouseReleased(object? sender, EventArgs e)
        {
            if (Game.IsGameOver)
            {
                return;
            }

            if (sender != null && sender is GridPanel)
            {
                GridPanel clickedPanel = (GridPanel)sender;
                Debug.WriteLine(clickedPanel.GridPosition);

                Checker? selectedElement = Game.CheckersBoard.GetPawnByPosition(clickedPanel.GridPosition);
                Debug.WriteLine(selectedElement);

                if (Game.SelectedPawn == null)  //If no pawn is selected
                {
                    if (selectedElement != null && selectedElement.Color.Equals(Game.ActualTurnColor))  //If I clicked on a pawn and the pawn is the same color of the actual turn...
                    {
                        Game.SelectPawn(selectedElement);   //Select the pawn.
                    }
                }
                else   //If pawn is selected
                {
                    if (selectedElement == null)    //If i click on an empty cell
                    {
                        if (Game.SelectedPawn.IsAvailableMoves(clickedPanel.GridPosition, out _))  //If this is an available move, then...
                        {
                            Game.SelectedPawn.Move(clickedPanel.GridPosition);  //Move in this position.
                        }
                        else //if is not an available move...
                        {
                            Game.UnselectPawn();    //Unselect
                        }
                    }
                    else if (!selectedElement.Color.Equals(Game.ActualTurnColor))   //Else if I click on a cell with the pawn of a different color of the actual turn...
                    {
                        Game.UnselectPawn();    //Unselect
                    }
                    else //else if I click on a pawn of the same color of the actual turn...
                    {
                        Game.SelectPawn(selectedElement);   //Select the pawn!
                    }
                }
            }
        }

        /// <summary>
        /// Clear the grid and re-insert graphically the pawns on the checkersboard.
        /// </summary>
        private void UpdateGraphics()
        {
            ClearGrid();

            InsertPawns();
        }

        /// <summary>
        /// Remove graphically all pawns on the checkersboard.
        /// </summary>
        private void ClearGrid()
        {
            foreach (GridPanel p in CheckersBoardPanels)
            {
                p.BackgroundImage = null;
            }
        }

        /// <summary>
        /// Insert graphically all pawns into the checkersboard.<br/>
        /// Pawns are retrieved on <see cref="CheckersBoard.Pawns"/>.
        /// </summary>
        private void InsertPawns()
        {
            foreach (Checker p in Game.CheckersBoard.Pawns)
            {
                CheckersBoardPanels[p.GridPosition.Row, p.GridPosition.Column].BackgroundImage = p.Image;
            }
        }

        /// <summary>
        /// Listener that manage the event <see cref="Game.SelectedPawnChangedEvent"/>.<br/>
        /// Triggered everytime the selected pawn (value on <see cref="Game.SelectedPawn"/>) is changed.
        /// </summary>
        /// <param name="sender">Object that trigs the event.<br/>It's always a <see cref="Objects.Games.Checkers.Game"/>.</param>
        /// <param name="e">Pawn that is actually selected.<br/> If it's <see langword="null"/> it meanst that the pawn is unselected.</param>
        private void Game_SelectedPawnChangedEvent(object? sender, Checker? e)
        {
            UpdateBackgrounds();
        }

        /// <summary>
        /// Clear the backgrounds of the cells on checkersboard.
        /// </summary>
        private void ClearSelection()
        {
            foreach (GridPanel p in CheckersBoardPanels)
            {
                p.BackColor = Color.Transparent;
            }
        }

        /// <summary>
        /// Show forced eater on checkersboard.<br/>
        /// It take eaters from <see cref="CheckersBoard.ForcedEater"/>.
        /// </summary>
        /// <param name="backColor">Background color of forced eater.</param>
        private void ShowForcedEaterSelection(Color backColor)
        {
            if (Game.CheckersBoard.ForcedEater != null)
            {
                foreach (Checker c in Game.CheckersBoard.ForcedEater)
                {
                    CheckersBoardPanels[c.GridPosition.Row, c.GridPosition.Column].BackColor = backColor;
                }
            }
        }

        /// <summary>
        /// Update the cells background showing moves of a pawn passed as <paramref name="pawnForShowingMoves"/>.
        /// </summary>
        /// <param name="pawnForShowingMoves">Pawn to show available moves.</param>
        private void UpdateBackgrounds(Checker? pawnForShowingMoves)
        {
            ClearSelection();

            ShowForcedEaterSelection(Resources.Games.Checkers.CheckersSettings.Default.ForcedEaterColor);

            if (pawnForShowingMoves != null)
            {
                ShowSelectedPawnAndAvailabelMoves(pawnForShowingMoves,
                    Resources.Games.Checkers.CheckersSettings.Default.SelectedPieceColor,
                    Resources.Games.Checkers.CheckersSettings.Default.AvailableMoveColor,
                    Resources.Games.Checkers.CheckersSettings.Default.EatableCheckerColor);
            }
        }

        /// <summary>
        /// Update the cells background showing moves of the selected pawn.
        /// </summary>
        private void UpdateBackgrounds()
        {
            UpdateBackgrounds(Game.SelectedPawn);
        }

        /// <summary>
        /// Change the background color of the cells on the checkersboard of the passed pawn.
        /// </summary>
        /// <param name="pawn">Pawn for highlitning movements.</param>
        /// <param name="selectedPawnColor">Background color of the selected pawn.</param>
        /// <param name="availableMovesColor">Background color of the availabel moves of the selected pawn.</param>
        /// <param name="eatablePieceColor">Background color of the piece that will be eated.</param>
        private void ShowSelectedPawnAndAvailabelMoves(Checker pawn, Color selectedPawnColor, Color availableMovesColor, Color eatablePieceColor)
        {
            CheckersBoardPanels[pawn.GridPosition.Row, pawn.GridPosition.Column].BackColor = selectedPawnColor;

            IEnumerable<Checker.AvailableMoveStruct> availableMoves = pawn.GetAvailableMoves();

            foreach (Checker.AvailableMoveStruct move in availableMoves)
            {
                CheckersBoardPanels[move.Move.Row, move.Move.Column].BackColor = availableMovesColor;

                if (move.EatablePiece != null)
                {
                    int r = move.EatablePiece.GridPosition.Row;
                    int c = move.EatablePiece.GridPosition.Column;

                    CheckersBoardPanels[r, c].BackColor = eatablePieceColor;
                }
            }
        }

        /// <summary>
        /// Listener that manage the event <see cref="Game.ActualTurnChangedEvent"/><br/>
        /// This is triggered everytime the turn is passed.
        /// </summary>
        /// <param name="sender">Sender that trigs the event.<br/>The sender is a <see cref="Objects.Games.Checkers.Game"/> type.</param>
        /// <param name="e">Actually turn color.</param>
        private void Game_ActualTurnChangedEvent(object? sender, Enums.PlayerColorWBEnum e)
        {
            UpdateBackgrounds();

            UpdateInfo(Objects.Games.Checkers.Game.InfoText.ActualTurnName);
        }

        /// <summary>
        /// Update the value of <see cref="InfoLabel"/>.
        /// </summary>
        private void UpdateInfo(Game.InfoText toRetrieve)
        {
            InfoLabel.Text = Game.GetTranslatetInfoText(toRetrieve);
        }

        /// <summary>
        /// Listener that manage the event <see cref="Game.PawnMovedEvent"/>.<br/>
        /// This is triggered everytime a pawn is moved.
        /// </summary>
        /// <param name="sender">Sender that trigs the event.<br/>This sender is a <see cref="Objects.Games.Checkers.Game"/> type.</param>
        /// <param name="e">Event args containing all informations about the move.</param>
        private void Game_PawnMovedEvent(object? sender, Game.PawnMovedEventArgs e)
        {
            UpdateGraphics();
        }

        /// <summary>
        /// Listener that manage the event <see cref="ToolStripItem.Click"/> invoked by <see cref="SurrendTranslatableToolStripMenuItem"/>.<br/>
        /// </summary>
        /// <param name="sender">Object that invoke the method.<br/>This is <see cref="SurrendTranslatableToolStripMenuItem"/>.</param>
        /// <param name="e">Event args of the listener.</param>
        private void SurrentTranslatableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = String.Format(Program.cRegionManager.GetTranslatedText(36), Game.ActualTurnPlayerName);
            string title = Program.cRegionManager.GetTranslatedText(37);

            DialogResult surrendResult = GamesNetMessageBoxTimerized.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, DialogResult.Yes, 5);

            if (surrendResult == DialogResult.Yes)
            {
                Game.GameOver();

                message = string.Format(Program.cRegionManager.GetTranslatedText(39), Game.OppositeTurnPlayerName);
                title = Program.cRegionManager.GetTranslatedText(38);

                GamesNetMessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        /// <summary>
        /// Listener that manage the event <see cref="Game.GameIsOverEvent"/>.<br/>
        /// This event is invoked with method <see cref="Game.GameOver"/> and it means that the game is over.
        /// </summary>
        /// <param name="sender">Element that invoke the event.<br/>This is a <see cref="Objects.Games.Checkers.Game"/> type.</param>
        /// <param name="e">Event args of the listener.<br/>The event args are empty.</param>
        private void Game_GameIsOverEvent(object? sender, EventArgs e)
        {
            InfoLabel.Text = Program.cRegionManager.GetTranslatedText(40);
        }

        /// <summary>
        /// Listener that manage the event <see cref="ToolStripItem.Click"/> invoked by <see cref="DeclareDrawTranslatableToolStripMenuItem"/>.
        /// </summary>
        /// <param name="sender">Object that invoke the method.<br/>This is <see cref="DeclareDrawTranslatableToolStripMenuItem"/>.</param>
        /// <param name="e">Event args of the listener.</param>
        private void DeclareDrawTranslatableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = string.Format(Program.cRegionManager.GetTranslatedText(41), Game.ActualTurnPlayerName);
            string title = Program.cRegionManager.GetTranslatedText(42);

            DialogResult drawResult = GamesNetMessageBoxTimerized.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, DialogResult.Yes, 5);

            if (drawResult == DialogResult.Yes)
            {
                message = string.Format(Program.cRegionManager.GetTranslatedText(43), Game.OppositeTurnPlayerName);

                DialogResult confirmResult = GamesNetMessageBoxTimerized.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, DialogResult.Yes, 5);

                if (confirmResult == DialogResult.Yes)
                {
                    Game.GameOver();

                    GamesNetMessageBox.Show(44, 45, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion
    }
}
