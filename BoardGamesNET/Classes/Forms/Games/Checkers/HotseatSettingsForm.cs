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
    public partial class HotseatSettingsForm : Form
    {
        #region ===== CONSTRUCTORS =====
        public HotseatSettingsForm()
        {
            InitializeComponent();

            Translate();

#if DEBUG
            WhitesPlayerNameTextBox.Text = "Mario Bianchi";
            BlacksPlayerNameTextBox.Text = "Filippo Neri";
#endif

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
            Text = $"[💻] [{Program.cRegionManager.GetTranslatedText(18)}] {Program.cRegionManager.GetTranslatedText(6)}";

            Program.cRegionManager.TranslateAllElementsInControl(this);
        }

        private void CancelTranslatableButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool AreBothNamesInserted()
        {
            return
                !string.IsNullOrWhiteSpace(WhitesPlayerNameTextBox.Text) &&
                !string.IsNullOrWhiteSpace(BlacksPlayerNameTextBox.Text);
        }
        #endregion

        private void PlayTranslatableButton_Click(object sender, EventArgs e)
        {
            if (!AreBothNamesInserted())
            {
                Program.cRegionManager.ShowTranslatedMessageDialog(20, 21, icon: MessageBoxIcon.Warning);
                return;
            }

            string whitesPlayerName = WhitesPlayerNameTextBox.Text;
            string blacksPlayerName = BlacksPlayerNameTextBox.Text;

            HotseatGameForm form = new HotseatGameForm(whitesPlayerName, blacksPlayerName);
            form.MdiParent = Program.MainForm;
            form.Show();
        }
    }
}
