using BoardGamesNET.Classes.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardGamesNET.Classes.Forms.Dialogs
{
    public class GamesNetMessageBoxTimerized : GamesNetMessageBox
    {
        #region ===== FIELDS =====
        private int _CountdownValue = -1;
        #endregion

        #region ===== VARIABLES =====
        private DialogResult TimerizedButtonDiagRes { get; set; }
        private Button TimerizedButton { get; set; }
        private System.Timers.Timer CountdownTimer { get; set; }
        private int CountdownValue
        {
            get
            {
                return _CountdownValue;
            }
            set
            {
                _CountdownValue = value;
                CountdownValueChangedEvent?.Invoke(null, value);
            }
        }
        #endregion

        #region ===== EVENTS =====
        private event EventHandler<int> CountdownValueChangedEvent;
        #endregion

        #region ===== CONSTRUCTORS =====
        public GamesNetMessageBoxTimerized(long messageLanguageReference, long titleLangaugeReference, MessageBoxButtons buttons, MessageBoxIcon icon, DialogResult timerizedButton, int timerLengthSecs) : base(messageLanguageReference, titleLangaugeReference, buttons, icon)
        {
            Init(timerizedButton, buttons, timerLengthSecs);
        }

        public GamesNetMessageBoxTimerized(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon, DialogResult timerizedButton, int timerLengthSecs) : base(message, title, buttons, icon)
        {
            Init(timerizedButton, buttons, timerLengthSecs);
        }
        #endregion

        #region ===== METHODS =====
        private void Init(DialogResult timerizedButton, MessageBoxButtons buttons, int timerLengthSecs)
        {
            if (!IsButtonAvailable(timerizedButton, buttons))
            {
                throw new ArgumentException("Selected timerized button is not present in this message box");
            }

            TimerizedButtonDiagRes = timerizedButton;

            TimerizedButton = GetButton(TimerizedButtonDiagRes);
            TimerizedButton.Enabled = false;
            CountdownValue = timerLengthSecs;
            TimerizedButton.Text = $"{Program.cRegionManager.GetTranslatedText(ButtonTextsLanRefs[timerizedButton])} ({CountdownValue})";

            CountdownValueChangedEvent += GamesNetMessageBoxTimerized_CountdownValueChangedEvent;
            Load += GamesNetMessageBoxTimerized_Load;
        }

        private void GamesNetMessageBoxTimerized_CountdownValueChangedEvent(object? sender, int e)
        {
            if (e != 0)
            {
                TimerizedButton.SetTextCrossThread($"{Program.cRegionManager.GetTranslatedText(ButtonTextsLanRefs[TimerizedButtonDiagRes])} ({e})");
            }
            else
            {
                CountdownTimer.Enabled = false;
                TimerizedButton.SetEnabledCrossThread(true);
                TimerizedButton.SetTextCrossThread(Program.cRegionManager.GetTranslatedText(ButtonTextsLanRefs[TimerizedButtonDiagRes]));
            }
        }

        private void GamesNetMessageBoxTimerized_Load(object? sender, EventArgs e)
        {
            CountdownTimer = new System.Timers.Timer(1000);
            CountdownTimer.Elapsed += CountdownTimer_Elapsed;
            CountdownTimer.Enabled = true;
        }

        private void CountdownTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            CountdownValue--;
        }

        private bool IsButtonAvailable(DialogResult button, MessageBoxButtons buttons)
        {
            switch (button)
            {
                case DialogResult.None:
                    return false;
                case DialogResult.OK:
                    return
                        buttons == MessageBoxButtons.OK ||
                        buttons == MessageBoxButtons.OKCancel;
                case DialogResult.Cancel:
                    return
                        buttons == MessageBoxButtons.CancelTryContinue ||
                        buttons == MessageBoxButtons.OKCancel ||
                        buttons == MessageBoxButtons.RetryCancel ||
                        buttons == MessageBoxButtons.YesNoCancel;
                case DialogResult.Abort:
                case DialogResult.Ignore:
                    return
                        buttons == MessageBoxButtons.AbortRetryIgnore;
                case DialogResult.Retry:
                    return
                        buttons == MessageBoxButtons.AbortRetryIgnore ||
                        buttons == MessageBoxButtons.RetryCancel;
                case DialogResult.Yes:
                case DialogResult.No:
                    return
                        buttons == MessageBoxButtons.YesNoCancel ||
                        buttons == MessageBoxButtons.YesNo;
                case DialogResult.TryAgain:
                    return
                        buttons == MessageBoxButtons.AbortRetryIgnore ||
                        buttons == MessageBoxButtons.CancelTryContinue ||
                        buttons == MessageBoxButtons.RetryCancel;
                case DialogResult.Continue:
                    return
                        buttons == MessageBoxButtons.CancelTryContinue;
            }

            return false;
        }

        private Button GetButton(DialogResult selectedButton)
        {
            if (LeftButton.DialogResult == selectedButton)
            {
                return LeftButton;
            }
            else if (MiddleButton.DialogResult == selectedButton)
            {
                return MiddleButton;
            }
            else if (RightButton.DialogResult == selectedButton)
            {
                return RightButton;
            }

            throw new ArgumentException("Selected button doesn't exists.");
        }

        public static DialogResult Show(long messageLanguageReference, long titleLangaugeReference, MessageBoxButtons buttons, MessageBoxIcon icon, DialogResult timerizedButton, int timerLengthSecs)
        {
            return new GamesNetMessageBoxTimerized(messageLanguageReference, titleLangaugeReference, buttons, icon, timerizedButton, timerLengthSecs).ShowDialog();
        }

        public static DialogResult Show(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon, DialogResult timerizedButton, int timerLengthSecs)
        {
            return new GamesNetMessageBoxTimerized(message, title, buttons, icon, timerizedButton, timerLengthSecs).ShowDialog();
        }
        #endregion
    }
}
