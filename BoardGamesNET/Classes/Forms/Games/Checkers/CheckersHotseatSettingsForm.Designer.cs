namespace BoardGamesNET.Classes.Forms.Games.Checkers
{
    partial class CheckersHotseatSettingsForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            BlacksPlayerNameTextBox = new TextBox();
            translatableLabel2 = new CustomComponents.TranslatableLabel();
            translatableLabel1 = new CustomComponents.TranslatableLabel();
            WhitesPlayerNameTextBox = new TextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            PlayTranslatableButton = new CustomComponents.TranslatableButton();
            CancelTranslatableButton = new CustomComponents.TranslatableButton();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(BlacksPlayerNameTextBox, 1, 1);
            tableLayoutPanel1.Controls.Add(translatableLabel2, 0, 1);
            tableLayoutPanel1.Controls.Add(translatableLabel1, 0, 0);
            tableLayoutPanel1.Controls.Add(WhitesPlayerNameTextBox, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(312, 59);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // BlacksPlayerNameTextBox
            // 
            BlacksPlayerNameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            BlacksPlayerNameTextBox.Location = new Point(159, 32);
            BlacksPlayerNameTextBox.Name = "BlacksPlayerNameTextBox";
            BlacksPlayerNameTextBox.Size = new Size(150, 23);
            BlacksPlayerNameTextBox.TabIndex = 3;
            // 
            // translatableLabel2
            // 
            translatableLabel2.AutoSize = true;
            translatableLabel2.Dock = DockStyle.Fill;
            translatableLabel2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            translatableLabel2.LanguageReference = 17L;
            translatableLabel2.Location = new Point(3, 29);
            translatableLabel2.Name = "translatableLabel2";
            translatableLabel2.Size = new Size(150, 30);
            translatableLabel2.TabIndex = 1;
            translatableLabel2.Text = "Blacks player name:";
            translatableLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // translatableLabel1
            // 
            translatableLabel1.AutoSize = true;
            translatableLabel1.Dock = DockStyle.Fill;
            translatableLabel1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            translatableLabel1.LanguageReference = 16L;
            translatableLabel1.Location = new Point(3, 0);
            translatableLabel1.Name = "translatableLabel1";
            translatableLabel1.Size = new Size(150, 29);
            translatableLabel1.TabIndex = 0;
            translatableLabel1.Text = "Whites player name:";
            translatableLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // WhitesPlayerNameTextBox
            // 
            WhitesPlayerNameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            WhitesPlayerNameTextBox.Location = new Point(159, 3);
            WhitesPlayerNameTextBox.Name = "WhitesPlayerNameTextBox";
            WhitesPlayerNameTextBox.Size = new Size(150, 23);
            WhitesPlayerNameTextBox.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(PlayTranslatableButton, 1, 0);
            tableLayoutPanel2.Controls.Add(CancelTranslatableButton, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Bottom;
            tableLayoutPanel2.Location = new Point(0, 68);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(312, 33);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // PlayTranslatableButton
            // 
            PlayTranslatableButton.Dock = DockStyle.Fill;
            PlayTranslatableButton.LanguageReference = 19L;
            PlayTranslatableButton.Location = new Point(159, 3);
            PlayTranslatableButton.Name = "PlayTranslatableButton";
            PlayTranslatableButton.Size = new Size(150, 27);
            PlayTranslatableButton.TabIndex = 1;
            PlayTranslatableButton.Text = "&Play >";
            PlayTranslatableButton.UseVisualStyleBackColor = true;
            PlayTranslatableButton.Click += PlayTranslatableButton_Click;
            // 
            // CancelTranslatableButton
            // 
            CancelTranslatableButton.Dock = DockStyle.Fill;
            CancelTranslatableButton.LanguageReference = 8L;
            CancelTranslatableButton.Location = new Point(3, 3);
            CancelTranslatableButton.Name = "CancelTranslatableButton";
            CancelTranslatableButton.Size = new Size(150, 27);
            CancelTranslatableButton.TabIndex = 0;
            CancelTranslatableButton.Text = "&Cancel";
            CancelTranslatableButton.UseVisualStyleBackColor = true;
            CancelTranslatableButton.Click += CancelTranslatableButton_Click;
            // 
            // CheckersHotseatSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(312, 101);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "CheckersHotseatSettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "[💻] [Checkers] Settings";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private CustomComponents.TranslatableLabel translatableLabel2;
        private CustomComponents.TranslatableLabel translatableLabel1;
        private TableLayoutPanel tableLayoutPanel2;
        private CustomComponents.TranslatableButton PlayTranslatableButton;
        private CustomComponents.TranslatableButton CancelTranslatableButton;
        private TextBox BlacksPlayerNameTextBox;
        private TextBox WhitesPlayerNameTextBox;
    }
}