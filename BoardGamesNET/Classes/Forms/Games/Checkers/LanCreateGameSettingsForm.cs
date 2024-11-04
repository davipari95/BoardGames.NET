using BoardGamesNET.Classes.Forms.Dialogs;
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

        private void CancelTranslatableButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void StartServerTranslatableButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;

            if (string.IsNullOrEmpty(username))
            {
                GamesNetMessageBox.Show(61, 21, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UsernameTextBox.Focus();
            }
            else
            {
                //Open server
                int port = (int) LanPortNumericUpDown.Value;
                ServerForm form = new ServerForm(port);
                form.MdiParent = Program.MainForm;
                form.Show();

                #region Wait until server is ready for accepting client
                while (!form.IsServerReadyForAcceptingClient)
                {
                    await Task.Delay(1);
                }
                #endregion

                //Open client


                Close();
            }
        }
    }
}
