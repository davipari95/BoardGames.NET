using BoardGamesNET.Interfaces;
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
    [ToolboxBitmap(typeof(ToolStripMenuItem))]
    public partial class TranslatableToolStripMenuItem : ToolStripMenuItem, ITranslatable
    {
        #region ===== FIELDS FOR VARIABLES =====
        private long _LanguageReference = 0;
        #endregion

        #region ===== VARIABLES =====
        public long LanguageReference
        {
            get
            {
                return _LanguageReference;
            }
            set
            {
                if (value != _LanguageReference)
                {
                    _LanguageReference = value;
                    LanguageReferenceChangedEvent?.Invoke(this, value);
                }
            }
        }
        #endregion

        #region ===== EVENTS =====
        public event EventHandler<long> LanguageReferenceChangedEvent;
        #endregion

        #region ===== CONTRUCTORS =====
        public TranslatableToolStripMenuItem()
        {
            InitializeComponent();
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
