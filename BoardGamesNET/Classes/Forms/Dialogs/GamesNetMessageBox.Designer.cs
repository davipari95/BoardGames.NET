namespace BoardGamesNET.Classes.Forms.Dialogs
{
    partial class GamesNetMessageBox
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
            panel1 = new Panel();
            SuperIconPanel = new Panel();
            IconPanel = new Panel();
            MessageLabel = new Label();
            RightButton = new Button();
            MiddleButton = new Button();
            LeftButton = new Button();
            panel1.SuspendLayout();
            SuperIconPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(SuperIconPanel);
            panel1.Controls.Add(MessageLabel);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(284, 80);
            panel1.TabIndex = 0;
            // 
            // SuperIconPanel
            // 
            SuperIconPanel.Controls.Add(IconPanel);
            SuperIconPanel.Dock = DockStyle.Fill;
            SuperIconPanel.Location = new Point(0, 0);
            SuperIconPanel.Name = "SuperIconPanel";
            SuperIconPanel.Size = new Size(41, 80);
            SuperIconPanel.TabIndex = 1;
            // 
            // IconPanel
            // 
            IconPanel.Location = new Point(9, 24);
            IconPanel.Name = "IconPanel";
            IconPanel.Size = new Size(32, 32);
            IconPanel.TabIndex = 0;
            // 
            // MessageLabel
            // 
            MessageLabel.Dock = DockStyle.Right;
            MessageLabel.Location = new Point(41, 0);
            MessageLabel.Name = "MessageLabel";
            MessageLabel.Size = new Size(243, 80);
            MessageLabel.TabIndex = 0;
            MessageLabel.Text = "[MESSAGE]";
            MessageLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // RightButton
            // 
            RightButton.Location = new Point(193, 89);
            RightButton.Name = "RightButton";
            RightButton.Size = new Size(75, 23);
            RightButton.TabIndex = 0;
            RightButton.Text = "[RIGHT]";
            RightButton.UseVisualStyleBackColor = true;
            RightButton.Visible = false;
            RightButton.Click += OnDialogButtonClicked;
            // 
            // MiddleButton
            // 
            MiddleButton.Location = new Point(108, 89);
            MiddleButton.Name = "MiddleButton";
            MiddleButton.Size = new Size(75, 23);
            MiddleButton.TabIndex = 1;
            MiddleButton.Text = "[MIDDLE]";
            MiddleButton.UseVisualStyleBackColor = true;
            MiddleButton.Visible = false;
            MiddleButton.Click += OnDialogButtonClicked;
            // 
            // LeftButton
            // 
            LeftButton.Location = new Point(24, 89);
            LeftButton.Name = "LeftButton";
            LeftButton.Size = new Size(75, 23);
            LeftButton.TabIndex = 2;
            LeftButton.Text = "[LEFT]";
            LeftButton.UseVisualStyleBackColor = true;
            LeftButton.Visible = false;
            LeftButton.Click += OnDialogButtonClicked;
            // 
            // GamesNetMessageBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 121);
            ControlBox = false;
            Controls.Add(LeftButton);
            Controls.Add(MiddleButton);
            Controls.Add(RightButton);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "GamesNetMessageBox";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "[TITLE]";
            panel1.ResumeLayout(false);
            SuperIconPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label MessageLabel;
        private Panel SuperIconPanel;
        private Panel IconPanel;
        protected Button RightButton;
        protected Button MiddleButton;
        protected Button LeftButton;
    }
}