using BoardGamesNET.Classes.Forms.Dialogs;
using BoardGamesNET.Classes.Forms.Games.Checkers;
using BoardGamesNET.Classes.Objects;
using BoardGamesNET.Classes.Utils;

namespace BoardGamesNET.Classes.Forms
{
    /// <summary>
    /// Starting form.<br/>
    /// Everything starts from here.
    /// </summary>
    public partial class MainForm : Form
    {
        #region ===== CONSTRUCTORS =====
        /// <summary>
        /// Initialize the form.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

#if DEBUG
            TestToolStripMenuItem.Visible = true;
#endif

            Program.cSettingsManager.ActiveLanguageChangedValueEvent += CSettingsManager_ActiveLanguageChangedValueEvent;
        }
        #endregion

        #region ===== METHODS =====
        /// <summary>
        /// Listener that manage the event <see cref="SettingsManager.ActiveLanguageChangedValueEvent"/>.<br/>
        /// This is triggered everytime language is changed.
        /// </summary>
        /// <param name="sender">Element that triggers the event.<br/>The sender is a <see cref="SettingsManager"/> type.</param>
        /// <param name="e">The new setted language.</param>
        private void CSettingsManager_ActiveLanguageChangedValueEvent(object? sender, string e)
        {
            Translate();
        }

        /// <summary>
        /// Listener that manage the event <see cref="Form.Load"/>.
        /// </summary>
        /// <param name="sender">This form.</param>
        /// <param name="e">Event args with <b>empty</b> informations.</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            Translate();
        }

        /// <summary>
        /// Translate all elements in this form.
        /// </summary>
        private void Translate()
        {
            Program.cRegionManager.TranslateAllElementsInControl(this);
        }

        /// <summary>
        /// Listener that manage the click of <see cref="FileQuitTranslatableToolStripMenuItem"/>.<br/>
        /// This ToolStrimMenuItem will close the form (then the program).
        /// </summary>
        /// <param name="sender">The control <see cref="FileQuitTranslatableToolStripMenuItem"/>.</param>
        /// <param name="e">This is empty.</param>
        private void FileQuitTranslatableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Listener that manage the click of <see cref="OptionsSettingsTranslatableToolStripMenuItem"/>.<br/>
        /// This will open the form containing the settings.
        /// </summary>
        /// <param name="sender"><see cref="OptionsSettingsTranslatableToolStripMenuItem"/>.</param>
        /// <param name="e">This is empty</param>
        private void OptionsSettingsTranslatableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();

            if (!UForms.IsFormOpenedInMdi(this, form, true))
            {
                form.MdiParent = this;
                form.Show();
            }
        }

        /// <summary>
        /// Listener that manage the click of <see cref="GamesCheckersTwoPlayersLocalTranslatableToolStripMeniItem"/>.<br/>
        /// This will open the form for set the game of the checkers in local mode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GamesCheckersTwoPlayersLocalTranslatableToolStripMeniItem_Click(object sender, EventArgs e)
        {
            HotseatSettingsForm form = new HotseatSettingsForm();
            form.MdiParent = this;
            form.Show();
        }

        /// <summary>
        /// Listener that manage the click of <see cref="TestToolStripMenuItem"/>.<br/>
        /// This ToolStripMenuItem is visible only if you compyle with <c>#DEBUG</c> directive.
        /// </summary>
        /// <param name="sender"><see cref="TestToolStripMenuItem"/>.</param>
        /// <param name="e">This is empty.</param>
        private void TestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HotseatGameForm form = new HotseatGameForm("Angelo Bianchi", "Beatrice Neri");
            form.MdiParent = this;
            form.Show();
        }

        /// <summary>
        /// Listener that manages the event <see cref="Form.FormClosing"/>.<br/>
        /// </summary>
        /// <param name="sender">Sender that throw the event.<br/>This is a <see cref="Form"/> type.</param>
        /// <param name="e">Data provided with the event <see cref="Form.FormClosing"/>.</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult exitResult = GamesNetMessageBox.Show(28, 27, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (exitResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void AboutTranslatableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutThisAppDialog.Show();
        }

        private void GamesCheckersRulesTranslatableToolStripMeniItem_Click(object sender, EventArgs e)
        {
            OpenRulesForm(Resources.Rules.Default.Checkers, 18);
        }

        /// <summary>
        /// Open the form containing the rules of the selected game.<br/>
        /// Rules will be open at the active language.
        /// </summary>
        /// <param name="relativeRulePath">
        /// Relative path of the html rule file.<br/>
        /// File path is similar to <tt>Data\Rules\Checkers\{0}.html</tt>.<br/>
        /// Check <see cref="Resources.Rules.Default"/> to retrieve relative path.
        /// </param>
        /// <param name="gameNameLanguageReference">Language reference of the name of the game.</param>
        private void OpenRulesForm(string relativeRulePath, long gameNameLanguageReference)
        {
            string ruleSource = string.Format(relativeRulePath, Program.cSettingsManager.ActiveLangauge);
            string title = string.Format(Program.cRegionManager.GetTranslatedText(50), Program.cRegionManager.GetTranslatedText(gameNameLanguageReference));

            RulesViewerForm f = new RulesViewerForm(title, ruleSource);
            f.MdiParent = this;
            f.Show();
        }
        #endregion


    }
}