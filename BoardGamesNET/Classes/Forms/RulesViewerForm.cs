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

namespace BoardGamesNET.Classes.Forms
{
    public partial class RulesViewerForm : Form
    {

        public RulesViewerForm(string title, string source)
        {
            InitializeComponent();

            Text = title;

            string absoluteSource = UFiles.FromRelativeToAbsolutePath(source);
            Uri uri = new Uri(absoluteSource);
            RuleWebView2.Source = uri;
        }
    }
}
