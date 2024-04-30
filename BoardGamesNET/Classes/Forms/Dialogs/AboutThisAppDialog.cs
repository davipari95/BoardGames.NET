using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardGamesNET.Classes.Forms.Dialogs
{
    public partial class AboutThisAppDialog : Form
    {
        public AboutThisAppDialog()
        {
            InitializeComponent();

            Translate();

            FillLabel();
        }

        public static new void Show()
        {
            new AboutThisAppDialog().ShowDialog();
        }

        private void Translate()
        {
            Text = Program.cRegionManager.GetTranslatedText(49);
        }

        private void FillLabel()
        {
            string swVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string text = string.Format(Program.cRegionManager.GetTranslatedText(48), swVersion);

            InfoLabel.Text = text;
        }
    }
}
