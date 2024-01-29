using BoardGamesNET.Classes.Forms.Games.Checkers;
using BoardGamesNET.Classes.Objects;
using BoardGamesNET.Classes.Utils;

namespace BoardGamesNET.Classes.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Program.cSettingsManager.ActiveLanguageChangedValueEvent += CSettingsManager_ActiveLanguageChangedValueEvent;
        }

        private void CSettingsManager_ActiveLanguageChangedValueEvent(object? sender, string e)
        {
            Translate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Translate();
        }

        private void Translate()
        {
            Program.cRegionManager.TranslateAllElementsInControl(this);
        }

        private void FileQuitTranslatableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OptionsSettingsTranslatableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();

            if (!UForms.IsFormOpenedInMdi(this, form, true))
            {
                form.MdiParent = this;
                form.Show();
            }
        }

        private void GamesCheckersTwoPlayersLocalTranslatableToolStripMeniItem_Click(object sender, EventArgs e)
        {
            HotseatSettingsForm form = new HotseatSettingsForm();
            form.MdiParent = this;
            form.Show();
        }
    }
}