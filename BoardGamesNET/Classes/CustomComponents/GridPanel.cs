using BoardGamesNET.Classes.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardGamesNET.Classes.CustomComponents
{
    /// <summary>
    /// Panel that contains the informations of a grid position.<br/>
    /// Informations are stored into <see cref="GridPosition"/> variable.
    /// </summary>
    [ToolboxBitmap(typeof(Panel))]
    public partial class GridPanel : Panel
    {
        #region ===== VARIABLES =====
        /// <summary>
        /// Informations about the position on grid of this panel.
        /// </summary>
        public GridPosition GridPosition { get; set; }
        #endregion

        #region ===== CONSTRUCTORS =====
        /// <summary>
        /// Initialize the panel with default <see cref="GridPosition"/> value: (0; 0).
        /// </summary>
        public GridPanel()
        {
            InitializeComponent();

            GridPosition = new GridPosition(0, 0);
        }

        /// <summary>
        /// Initialize the panel.
        /// </summary>
        /// <param name="gridPosition">Grid information.<br/>This information will be stored on <see cref="GridPosition"/>.</param>
        public GridPanel(GridPosition gridPosition)
        {
            InitializeComponent();

            GridPosition = new GridPosition(gridPosition);
        }

        /// <summary>
        /// Initialize the panel.
        /// </summary>
        /// <param name="row">Row of the grid position.<br/>This will be the row of <see cref="GridPosition"/>.</param>
        /// <param name="column">Column of the grid position.<br/>This will be the column of <see cref="GridPosition"/>.</param>
        public GridPanel(int row, int column)
        {
            InitializeComponent();

            GridPosition = new GridPosition(row, column);
        }
        #endregion

        #region ===== METHODS =====
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        #endregion
    }
}
