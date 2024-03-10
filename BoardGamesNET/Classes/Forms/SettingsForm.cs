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
    /// <summary>
    /// Form that manage the active settings.
    /// </summary>
    public partial class SettingsForm : Form
    {
        #region ===== CONSTRUCTORS =====
        /// <summary>
        /// Initialize the form.
        /// </summary>
        public SettingsForm()
        {
            InitializeComponent();
        }
        #endregion

        #region ===== METHODS =====
        /// <summary>
        /// Translate all elements in this form.
        /// </summary>
        private void TranslateAll()
        {
            Text = Program.cRegionManager.GetTranslatedText(6);

            Program.cRegionManager.TranslateAllElementsInControl(this);
        }

        /// <summary>
        /// Listener that manage the trigger of the event <see cref="Form.Load"/>.
        /// </summary>
        /// <param name="sender"><see cref="SettingsForm"/>.</param>
        /// <param name="e">This is empty.</param>
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            TranslateAll();
            InitializeAvailableLangauges();
        }

        /// <summary>
        /// Listener that manage the trigger of the click of the <see cref="CancelTranslatableButton"/><br/>
        /// This will close the form without saving the settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelTranslatableButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Initialize the element for managing the language.
        /// </summary>
        private void InitializeAvailableLangauges()
        {
            AvailableLanguagesComboBox.ValueMember = "Key";
            AvailableLanguagesComboBox.DisplayMember = "Value";
            AvailableLanguagesComboBox.DataSource = new BindingSource(Program.cRegionManager.AvailableLangauges, null);

            AvailableLanguagesComboBox.SelectedValue = Program.cSettingsManager.ActiveLangauge;
        }

        /// <summary>
        /// Listener that manage the click of <see cref="SaveTranslatableButton"/>.<br/>
        /// This will close the form saving the elements.
        /// </summary>
        /// <param name="sender"><see cref="SaveTranslatableButton"/>.</param>
        /// <param name="e">This is empty.</param>
        private void SaveTranslatableButton_Click(object sender, EventArgs e)
        {
            Program.cSettingsManager.ActiveLangauge = (string)AvailableLanguagesComboBox.SelectedValue;

            Close();
        }
        #endregion
    }
}
