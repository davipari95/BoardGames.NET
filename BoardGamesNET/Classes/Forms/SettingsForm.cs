using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardGamesNET.Classes.Forms
{
    public partial class SettingsForm : Form
    {
        #region ===== CONSTRUCTORS =====
        public SettingsForm()
        {
            InitializeComponent();
        }
        #endregion

        #region ===== METHODS =====
        private void TranslateAll()
        {
            Text = Program.cRegionManager.GetTranslatedText(6);

            Program.cRegionManager.TranslateAllElementsInControl(this);
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            TranslateAll();
            InitializeAvailableLangauges();
        }

        private void CancelTranslatableButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InitializeAvailableLangauges()
        {
            AvailableLanguagesComboBox.ValueMember = "Key";
            AvailableLanguagesComboBox.DisplayMember = "Value";
            AvailableLanguagesComboBox.DataSource = new BindingSource(Program.cRegionManager.AvailableLangauges, null);

            AvailableLanguagesComboBox.SelectedValue = Program.cSettingsManager.ActiveLangauge;
        }

        private void SaveTranslatableButton_Click(object sender, EventArgs e)
        {
            Program.cSettingsManager.ActiveLangauge = (string)AvailableLanguagesComboBox.SelectedValue;

            Close();
        }
        #endregion
    }
}
