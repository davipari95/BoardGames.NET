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
    /// <summary>
    /// Settings form for setting the game of the checkers in hot-seat mode.
    /// </summary>
    public partial class HotseatSettingsForm : Form
    {
        #region ===== CONSTRUCTORS =====
        /// <summary>
        /// Initialize the form.<br/>
        /// This will initialize components, translate that and add listeners.
        /// </summary>
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
        /// <summary>
        /// Listener that manage the event <see cref="Classes.Objects.SettingsManager.ActiveLanguageChangedValueEvent"/>.<br/>
        /// This event is triggered everytime the active langauge is changed.
        /// </summary>
        /// <param name="sender">Sender that triggers the event.<br/>The sender is a <see cref="Classes.Objects.SettingsManager"/> class.</param>
        /// <param name="e">The new language that is setted.</param>
        private void CSettingsManager_ActiveLanguageChangedValueEvent(object? sender, string e)
        {
            Translate();
        }

        /// <summary>
        /// Translate all contents inside this form.
        /// </summary>
        private void Translate()
        {
            Text = $"[💻] [{Program.cRegionManager.GetTranslatedText(18)}] {Program.cRegionManager.GetTranslatedText(6)}";

            Program.cRegionManager.TranslateAllElementsInControl(this);
        }

        /// <summary>
        /// Lister that manage the click of <see cref="CancelTranslatableButton"/>.
        /// </summary>
        /// <param name="sender">The button that triggers the event.<br/>The sender is a <see cref="Classes.CustomComponents.TranslatableButton"/>.</param>
        /// <param name="e">Event args containing the information of the event.<br/>This is always empty.</param>
        private void CancelTranslatableButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Check if both name are inserted in <see cref="WhitesPlayerNameTextBox"/> and <see cref="BlacksPlayerNameTextBox"/>.<br/>
        /// This check event if there are white spaces.
        /// </summary>
        /// <returns>Returns <see langword="true"/> if both name are inserted correctly, <see langword="false"/> otherwise.</returns>
        private bool AreBothNamesInserted()
        {
            return
                !string.IsNullOrWhiteSpace(WhitesPlayerNameTextBox.Text) &&
                !string.IsNullOrWhiteSpace(BlacksPlayerNameTextBox.Text);
        }

        /// <summary>
        /// Listener that manage the click of <see cref="PlayTranslatableButton"/>.
        /// </summary>
        /// <param name="sender">The element that trigs the event.<br/>The sender is a <see cref="Classes.CustomComponents.TranslatableButton"/>.</param>
        /// <param name="e">Event args containing the information of the event.<br/>This is always empty.</param>
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
        #endregion
    }
}
