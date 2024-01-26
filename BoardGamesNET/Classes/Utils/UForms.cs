using BoardGamesNET.Classes.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Classes.Utils
{
    public class UForms
    {

        public static bool IsFormOpenedInMdi(Form parent, Form toOpen, bool bringToFrontIfIsOpen)
        {
            Form? openedForm = parent.MdiChildren.Where(f => f.Name == toOpen.Name).FirstOrDefault();

            if (openedForm != null)
            {
                if (bringToFrontIfIsOpen)
                {
                    openedForm.WindowState = openedForm.WindowState == FormWindowState.Minimized ? FormWindowState.Normal : openedForm.WindowState;

                    openedForm.BringToFront();
                }
                
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsFormOpenedInMdi(Form parent, Form toOpen)
        {
            return IsFormOpenedInMdi(parent, toOpen, false);
        }
    }
}
