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
    /// <summary>
    /// A ToolStripMenuItem containing the informations for translating the text.
    /// </summary>
    [ToolboxBitmap(typeof(ToolStripMenuItem))]
    public partial class TranslatableToolStripMenuItem : ToolStripMenuItem, ITranslatable
    {
        #region ===== VARIABLES =====

        #region ===== FIELDS FOR VARIABLES =====
        private long _LanguageReference = 0;
        #endregion

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
        /// <summary>
        /// Initialize the control.
        /// </summary>
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
