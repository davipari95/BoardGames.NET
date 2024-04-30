namespace BoardGamesNET.Classes.Forms.Dialogs
{
    partial class AboutThisAppDialog
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
            InfoLabel = new Label();
            SuspendLayout();
            // 
            // InfoLabel
            // 
            InfoLabel.Dock = DockStyle.Fill;
            InfoLabel.Location = new Point(0, 0);
            InfoLabel.Name = "InfoLabel";
            InfoLabel.Size = new Size(272, 73);
            InfoLabel.TabIndex = 0;
            InfoLabel.Text = "BoardGamesNET\r\n\r\nSoftware version: {0}";
            InfoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AboutThisAppDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(272, 73);
            Controls.Add(InfoLabel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            Name = "AboutThisAppDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AboutThisAppDialog";
            ResumeLayout(false);
        }

        #endregion

        private Label InfoLabel;
    }
}