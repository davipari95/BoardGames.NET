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
    [ToolboxBitmap(typeof(Label))]
    public partial class GridLabel : Label
    {
        #region ===== VARIABLES =====
        public GridPosition GridPosition { get; set; }
        #endregion

        #region ===== CONSTRUCTORS =====
        public GridLabel()
        {
            InitializeComponent();

            GridPosition = new GridPosition(0, 0);
        }

        public GridLabel(GridPosition gridPosition)
        {
            InitializeComponent();

            GridPosition = new GridPosition(gridPosition);
        }

        public GridLabel(int row, int column)
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
