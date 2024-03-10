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
    /// A label containing the informations for translating the text.
    /// </summary>
    [ToolboxBitmap(typeof(Label))]
    public partial class TranslatableLabel : Label, ITranslatable
    {
        #region ===== VARIABLES =====

        #region ===== VARIABLES FOR FIELDS =====
        private long _LangaugeReference = 0;
        #endregion

        public long LanguageReference
        {
            get
            {
                return _LangaugeReference;
            }
            set
            {
                if (value != _LangaugeReference)
                {
                    _LangaugeReference = value;
                    LanguageReferenceChangedEvent?.Invoke(this, value);
                }
            }
        }
        #endregion

        #region ===== EVENTS =====
        public event EventHandler<long> LanguageReferenceChangedEvent;
        #endregion

        #region ===== CONSTRUCTORS =====
        /// <summary>
        /// Initialize the control.
        /// </summary>
        public TranslatableLabel()
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
