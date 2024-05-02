namespace BoardGamesNET.Classes.Forms
{
    partial class RulesViewerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            RuleWebView2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)RuleWebView2).BeginInit();
            SuspendLayout();
            // 
            // RuleWebView2
            // 
            RuleWebView2.AllowExternalDrop = true;
            RuleWebView2.CreationProperties = null;
            RuleWebView2.DefaultBackgroundColor = Color.White;
            RuleWebView2.Dock = DockStyle.Fill;
            RuleWebView2.Location = new Point(0, 0);
            RuleWebView2.Name = "RuleWebView2";
            RuleWebView2.Size = new Size(638, 776);
            RuleWebView2.Source = new Uri("https://www.google.com", UriKind.Absolute);
            RuleWebView2.TabIndex = 0;
            RuleWebView2.ZoomFactor = 1D;
            // 
            // RulesViewerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(638, 776);
            Controls.Add(RuleWebView2);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "RulesViewerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RulesViewerForm";
            ((System.ComponentModel.ISupportInitialize)RuleWebView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 RuleWebView2;
    }
}