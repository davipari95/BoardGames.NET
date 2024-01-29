using BoardGamesNET.Classes.CustomComponents;
using BoardGamesNET.Classes.Objects;
using BoardGamesNET.Classes.Objects.Games.Checkers;
using BoardGamesNET.Classes.Objects.Games.Checkers.Games;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            InitializeGridPanels();

            Translate();

            UpdateGraphics();

            Program.cSettingsManager.ActiveLanguageChangedValueEvent += CSettingsManager_ActiveLanguageChangedValueEvent;
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

        private void InitializeGridPanels()
        {
            int MARGIN = 5;
            int SIZE = 100;

            CheckersBoardPanels = new GridPanel[8, 8];

            for (int r = 0; r < CheckersBoardPanels.GetLength(0); r++)
            {
                for (int c = 0; c < CheckersBoardPanels.GetLength(1); c++)
                {
                    CheckersBoardPanels[r, c] = new GridPanel(r, c)
                    {
                        Location = new Point((c * SIZE) + MARGIN, (r * SIZE) + MARGIN),
                        Size = new Size(SIZE - (MARGIN * 2), SIZE - (MARGIN * 2)),
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

        #endregion
    }
}
