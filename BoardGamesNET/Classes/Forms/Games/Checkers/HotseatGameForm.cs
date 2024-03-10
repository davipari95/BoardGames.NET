﻿using BoardGamesNET.Classes.CustomComponents;
using BoardGamesNET.Classes.Objects;
using BoardGamesNET.Classes.Objects.Games.Checkers;
using BoardGamesNET.Classes.Objects.Games.Checkers.Games;
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
            Game.PawnMovedEvent += Game_PawnMovedEvent;
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
            if (sender != null && sender is GridPanel)
            {
                GridPanel clickedPanel = (GridPanel)sender;
                Debug.WriteLine(clickedPanel.GridPosition);

                Pawn? selectedElement = Game.CheckersBoard.GetPawnByPosition(clickedPanel.GridPosition);
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
            foreach (Pawn p in Game.CheckersBoard.Pawns)
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
        private void Game_SelectedPawnChangedEvent(object? sender, Pawn? e)
        {
            ClearSelection();

            if (e != null)
            {
                ShowSelectedPawnAndAvailabelMoves(e, Color.Yellow, Color.LawnGreen, Color.Red);
            }
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
        /// Change the background color of the cells on the checkersboard of the passed pawn.
        /// </summary>
        /// <param name="pawn">Pawn for highlitning movements.</param>
        /// <param name="selectedPawnColor">Background color of the selected pawn.</param>
        /// <param name="availableMovesColor">Background color of the availabel moves of the selected pawn.</param>
        /// <param name="eatablePieceColor">Background color of the piece that will be eated.</param>
        private void ShowSelectedPawnAndAvailabelMoves(Pawn pawn, Color selectedPawnColor, Color availableMovesColor, Color eatablePieceColor)
        {
            CheckersBoardPanels[pawn.GridPosition.Row, pawn.GridPosition.Column].BackColor = selectedPawnColor;

            IEnumerable<Pawn.AvailableMovesStruct> availableMoves = pawn.GetAvailableMoves();

            foreach (Pawn.AvailableMovesStruct move in availableMoves)
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
        /// Listener that manage the event <see cref="Game.PawnMovedEvent"/>.<br/>
        /// This is triggered everytime a pawn is moved.
        /// </summary>
        /// <param name="sender">Sender that triggers the event.<br/>The sender is a <see cref="Classes.Objects.Games.Checkers.Game"/> type.</param>
        /// <param name="e">Event args of the event. <br/>See <see cref="Classes.Objects.Games.Checkers.Game.PawnMovedEventArgs"/> for more informations.</param>
        private void Game_PawnMovedEvent(object? sender, Game.PawnMovedEventArgs e)
        {
            UpdateGraphics();
        }
        #endregion
    }
}
