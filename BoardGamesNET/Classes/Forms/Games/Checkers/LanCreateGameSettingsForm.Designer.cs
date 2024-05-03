using BoardGamesNET.Resources;

namespace BoardGamesNET.Classes.Forms.Games.Checkers
{
    partial class LanCreateGameSettingsForm
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
            translatableGroupBox1 = new CustomComponents.TranslatableGroupBox();
            UsernameTextBox = new TextBox();
            translatableGroupBox2 = new CustomComponents.TranslatableGroupBox();
            PlayAsBlackTranslatableRadioButton = new CustomComponents.TranslatableRadioButton();
            PlayAsWhiteTranslatableRadioButton = new CustomComponents.TranslatableRadioButton();
            translatableGroupBox3 = new CustomComponents.TranslatableGroupBox();
            LanPortNumericUpDown = new NumericUpDown();
            tableLayoutPanel1 = new TableLayoutPanel();
            CancelTranslatableButton = new CustomComponents.TranslatableButton();
            translatableButton1 = new CustomComponents.TranslatableButton();
            translatableGroupBox1.SuspendLayout();
            translatableGroupBox2.SuspendLayout();
            translatableGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LanPortNumericUpDown).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // translatableGroupBox1
            // 
            translatableGroupBox1.Controls.Add(UsernameTextBox);
            translatableGroupBox1.Dock = DockStyle.Top;
            translatableGroupBox1.LanguageReference = 54L;
            translatableGroupBox1.Location = new Point(0, 0);
            translatableGroupBox1.Name = "translatableGroupBox1";
            translatableGroupBox1.Size = new Size(283, 47);
            translatableGroupBox1.TabIndex = 0;
            translatableGroupBox1.TabStop = false;
            translatableGroupBox1.Text = "Username";
            // 
            // UsernameTextBox
            // 
            UsernameTextBox.Dock = DockStyle.Fill;
            UsernameTextBox.Location = new Point(3, 19);
            UsernameTextBox.Name = "UsernameTextBox";
            UsernameTextBox.Size = new Size(277, 23);
            UsernameTextBox.TabIndex = 0;
            // 
            // translatableGroupBox2
            // 
            translatableGroupBox2.Controls.Add(PlayAsBlackTranslatableRadioButton);
            translatableGroupBox2.Controls.Add(PlayAsWhiteTranslatableRadioButton);
            translatableGroupBox2.Dock = DockStyle.Top;
            translatableGroupBox2.LanguageReference = 56L;
            translatableGroupBox2.Location = new Point(0, 47);
            translatableGroupBox2.Name = "translatableGroupBox2";
            translatableGroupBox2.Size = new Size(283, 64);
            translatableGroupBox2.TabIndex = 1;
            translatableGroupBox2.TabStop = false;
            translatableGroupBox2.Text = "Play as";
            // 
            // PlayAsBlackTranslatableRadioButton
            // 
            PlayAsBlackTranslatableRadioButton.AutoSize = true;
            PlayAsBlackTranslatableRadioButton.Dock = DockStyle.Top;
            PlayAsBlackTranslatableRadioButton.LanguageReference = 58L;
            PlayAsBlackTranslatableRadioButton.Location = new Point(3, 38);
            PlayAsBlackTranslatableRadioButton.Name = "PlayAsBlackTranslatableRadioButton";
            PlayAsBlackTranslatableRadioButton.Size = new Size(277, 19);
            PlayAsBlackTranslatableRadioButton.TabIndex = 1;
            PlayAsBlackTranslatableRadioButton.Text = "Black";
            PlayAsBlackTranslatableRadioButton.UseVisualStyleBackColor = true;
            // 
            // PlayAsWhiteTranslatableRadioButton
            // 
            PlayAsWhiteTranslatableRadioButton.AutoSize = true;
            PlayAsWhiteTranslatableRadioButton.Checked = true;
            PlayAsWhiteTranslatableRadioButton.Dock = DockStyle.Top;
            PlayAsWhiteTranslatableRadioButton.LanguageReference = 57L;
            PlayAsWhiteTranslatableRadioButton.Location = new Point(3, 19);
            PlayAsWhiteTranslatableRadioButton.Name = "PlayAsWhiteTranslatableRadioButton";
            PlayAsWhiteTranslatableRadioButton.Size = new Size(277, 19);
            PlayAsWhiteTranslatableRadioButton.TabIndex = 0;
            PlayAsWhiteTranslatableRadioButton.TabStop = true;
            PlayAsWhiteTranslatableRadioButton.Text = "White";
            PlayAsWhiteTranslatableRadioButton.UseVisualStyleBackColor = true;
            // 
            // translatableGroupBox3
            // 
            translatableGroupBox3.Controls.Add(LanPortNumericUpDown);
            translatableGroupBox3.Dock = DockStyle.Top;
            translatableGroupBox3.LanguageReference = 59L;
            translatableGroupBox3.Location = new Point(0, 111);
            translatableGroupBox3.Name = "translatableGroupBox3";
            translatableGroupBox3.Size = new Size(283, 47);
            translatableGroupBox3.TabIndex = 2;
            translatableGroupBox3.TabStop = false;
            translatableGroupBox3.Text = "Port";
            // 
            // LanPortNumericUpDown
            // 
            LanPortNumericUpDown.Dock = DockStyle.Fill;
            LanPortNumericUpDown.Location = new Point(3, 19);
            LanPortNumericUpDown.Maximum = new decimal(new int[] { 49176, 0, 0, 0 });
            LanPortNumericUpDown.Minimum = new decimal(new int[] { 49152, 0, 0, 0 });
            LanPortNumericUpDown.Name = "LanPortNumericUpDown";
            LanPortNumericUpDown.Size = new Size(277, 23);
            LanPortNumericUpDown.TabIndex = 0;
            LanPortNumericUpDown.Value = new decimal(new int[] { 49152, 0, 0, 0 });
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(CancelTranslatableButton, 0, 0);
            tableLayoutPanel1.Controls.Add(translatableButton1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 158);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(283, 43);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // CancelTranslatableButton
            // 
            CancelTranslatableButton.Dock = DockStyle.Fill;
            CancelTranslatableButton.LanguageReference = 8L;
            CancelTranslatableButton.Location = new Point(3, 3);
            CancelTranslatableButton.Name = "CancelTranslatableButton";
            CancelTranslatableButton.Size = new Size(135, 37);
            CancelTranslatableButton.TabIndex = 1;
            CancelTranslatableButton.Text = "&Cancel";
            CancelTranslatableButton.UseVisualStyleBackColor = true;
            CancelTranslatableButton.Click += CancelTranslatableButton_Click;
            // 
            // translatableButton1
            // 
            translatableButton1.Dock = DockStyle.Fill;
            translatableButton1.LanguageReference = 60L;
            translatableButton1.Location = new Point(144, 3);
            translatableButton1.Name = "translatableButton1";
            translatableButton1.Size = new Size(136, 37);
            translatableButton1.TabIndex = 0;
            translatableButton1.Text = "&Start server";
            translatableButton1.UseVisualStyleBackColor = true;
            // 
            // LanCreateGameSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(283, 201);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(translatableGroupBox3);
            Controls.Add(translatableGroupBox2);
            Controls.Add(translatableGroupBox1);
            Name = "LanCreateGameSettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "[🌐] [Checkers] Create game";
            translatableGroupBox1.ResumeLayout(false);
            translatableGroupBox1.PerformLayout();
            translatableGroupBox2.ResumeLayout(false);
            translatableGroupBox2.PerformLayout();
            translatableGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LanPortNumericUpDown).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private CustomComponents.TranslatableGroupBox translatableGroupBox1;
        private TextBox UsernameTextBox;
        private CustomComponents.TranslatableGroupBox translatableGroupBox2;
        private CustomComponents.TranslatableRadioButton PlayAsBlackTranslatableRadioButton;
        private CustomComponents.TranslatableRadioButton PlayAsWhiteTranslatableRadioButton;
        private CustomComponents.TranslatableGroupBox translatableGroupBox3;
        private NumericUpDown LanPortNumericUpDown;
        private TableLayoutPanel tableLayoutPanel1;
        private CustomComponents.TranslatableButton CancelTranslatableButton;
        private CustomComponents.TranslatableButton translatableButton1;
    }
}