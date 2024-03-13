using BoardGamesNET.Classes.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Classes.Utils
{
    /// <summary>
    /// Class containing static function for managing forms.
    /// </summary>
    public class UForms
    {
        /// <summary>
        /// Check if a form is opened inside the MDI parent
        /// </summary>
        /// <param name="parent">Form with the MDI container.</param>
        /// <param name="toOpen">Form to check if it's opened.</param>
        /// <param name="bringToFrontIfIsOpen">If this is setted to <see langword="true"/>, bring the form on top if it's open.</param>
        /// <returns><see langword="true"/> if the form is opened inside the parent, otherwise <see langword="false"/>.</returns>
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

        /// <summary>
        /// Check if a form is opened inside the MDI parent
        /// </summary>
        /// <param name="parent">Form with the MDI container.</param>
        /// <param name="toOpen">Form to check if it's opened.</param>
        /// <returns><see langword="true"/> if the form is opened inside the parent, otherwise <see langword="false"/>.</returns>
        public static bool IsFormOpenedInMdi(Form parent, Form toOpen)
        {
            return IsFormOpenedInMdi(parent, toOpen, false);
        }
    }
}
