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
    public partial class LanCreateGameSettingsForm : Form
    {
        public LanCreateGameSettingsForm()
        {
            InitializeComponent();

            Translate();
        }

        private void Translate()
        {
            Text = $"[🌐] [{Program.cRegionManager.GetTranslatedText(18)}] {Program.cRegionManager.GetTranslatedText(55)}";

            Program.cRegionManager.TranslateAllElementsInControl(this);
        }
    }
}
