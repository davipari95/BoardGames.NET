using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Classes.Utils
{
    public static class UCrossThread
    {
        private delegate void SetTextCrossThreadDelegate(ButtonBase buttonBase, string text);
        private delegate void SetEnabledCrossThreadDelegate(Control control, bool enable);

        public static void SetTextCrossThread(this ButtonBase buttonBase, string text)
        {
            if (buttonBase.InvokeRequired)
            {
                buttonBase.FindForm().Invoke(new SetTextCrossThreadDelegate(SetTextCrossThread), buttonBase, text);
            }
            else
            {
                buttonBase.Text = text;
            }
        }

        public static void SetEnabledCrossThread(this Control control, bool enable)
        {
            if (control.InvokeRequired)
            {
                control.FindForm().Invoke(new SetEnabledCrossThreadDelegate(SetEnabledCrossThread), control, enable);
            }
            else
            {
                control.Enabled = enable;
            }
        }
    }
}
