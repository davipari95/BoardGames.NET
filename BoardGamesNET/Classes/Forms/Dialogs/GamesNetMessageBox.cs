using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace BoardGamesNET.Classes.Forms.Dialogs
{
    public partial class GamesNetMessageBox : Form
    {
        private const int MESSAGE_LABEL_WIDTH_WITHOUT_ICON = 243 + 41;  //Standard label width + super icon panel width

        protected Dictionary<DialogResult, long> ButtonTextsLanRefs = new Dictionary<DialogResult, long>()
        {
            [DialogResult.OK] = 29,
            [DialogResult.Cancel] = 8,
            [DialogResult.Abort] = 30,
            [DialogResult.Retry] = 31,
            [DialogResult.Ignore] = 32,
            [DialogResult.Yes] = 33,
            [DialogResult.No] = 34,
            [DialogResult.Continue] = 35,
        };

        public GamesNetMessageBox(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            Initialize();

            SetElements(message, title, icon, buttons);
        }

        public GamesNetMessageBox(long messageLanguageReference, long titleLangaugeReference, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            Initialize();

            string message = Program.cRegionManager.GetTranslatedText(messageLanguageReference);
            string title = Program.cRegionManager.GetTranslatedText(titleLangaugeReference);

            SetElements(message, title, icon, buttons);
        }

        private void Initialize()
        {
            InitializeComponent();
        }

        private void SetElements(string message, string title, MessageBoxIcon icon, MessageBoxButtons buttons)
        {
            Text = title;
            MessageLabel.Text = message;
            SetIconPanel(icon);
            SetButtons(buttons);
        }

        private void SetIconPanel(MessageBoxIcon icon)
        {
            IconPanel.BackgroundImageLayout = ImageLayout.Zoom;

            if (icon != MessageBoxIcon.None)
            {
                IconPanel.BackgroundImage = GetIcon(icon).ToBitmap();
            }
            else
            {
                SuperIconPanel.Visible = false;
                MessageLabel.Width = MESSAGE_LABEL_WIDTH_WITHOUT_ICON;
            }
        }

        private Icon GetIcon(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.None:
                    throw new ArgumentException("Icon selected is \"None\"");
                case MessageBoxIcon.Hand:
                    return SystemIcons.Hand;
                case MessageBoxIcon.Question:
                    return SystemIcons.Question;
                case MessageBoxIcon.Exclamation:
                    return SystemIcons.Exclamation;;
                case MessageBoxIcon.Asterisk:
                    return SystemIcons.Asterisk;
            }

            throw new ArgumentException("Icon doesn't exists.");
        }

        private void SetButtons(MessageBoxButtons buttons)
        {
            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    DialogResult = DialogResult.OK;
                    SetButton(RightButton, DialogResult.OK);
                    break;
                case MessageBoxButtons.OKCancel:
                    DialogResult = DialogResult.Cancel;
                    SetButton(MiddleButton, DialogResult.OK);
                    SetButton(RightButton, DialogResult.Cancel);
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    DialogResult = DialogResult.Ignore;
                    SetButton(LeftButton, DialogResult.Abort);
                    SetButton(MiddleButton, DialogResult.Retry);
                    SetButton(RightButton, DialogResult.Ignore);
                    break;
                case MessageBoxButtons.YesNoCancel:
                    DialogResult = DialogResult.Cancel;
                    SetButton(LeftButton, DialogResult.Yes);
                    SetButton(MiddleButton, DialogResult.No);
                    SetButton(RightButton, DialogResult.Cancel);
                    break;
                case MessageBoxButtons.YesNo:
                    DialogResult = DialogResult.No;
                    SetButton(MiddleButton, DialogResult.Yes);
                    SetButton(RightButton, DialogResult.No);
                    break;
                case MessageBoxButtons.RetryCancel:
                    DialogResult = DialogResult.Cancel;
                    SetButton(MiddleButton, DialogResult.Retry);
                    SetButton(RightButton, DialogResult.Cancel);
                    break;
                case MessageBoxButtons.CancelTryContinue:
                    DialogResult = DialogResult.Cancel;
                    SetButton(LeftButton, DialogResult.Cancel);
                    SetButton(MiddleButton, DialogResult.Retry);
                    SetButton(RightButton, DialogResult.Continue);
                    break;
            }
        }

        private void SetButton(Button button, string text, DialogResult returnedResult)
        {
            button.Visible = true;
            button.Text = text;
            button.DialogResult = returnedResult;
        }

        private void SetButton(Button button, DialogResult returnedResult)
        {
            string text = Program.cRegionManager.GetTranslatedText(ButtonTextsLanRefs[returnedResult]);

            SetButton(button, text, returnedResult);
        }

        private void OnDialogButtonClicked(object sender, EventArgs args)
        {
            DialogResult = ((Button)sender).DialogResult;

            Close();
        }
    }
}
