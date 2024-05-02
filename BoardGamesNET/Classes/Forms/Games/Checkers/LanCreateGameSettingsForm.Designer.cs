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
            textBox1 = new TextBox();
            translatableGroupBox2 = new CustomComponents.TranslatableGroupBox();
            PlayAsWhiteTranslatableRadioButton = new CustomComponents.TranslatableRadioButton();
            PlayAsBlackTranslatableRadioButton = new CustomComponents.TranslatableRadioButton();
            translatableGroupBox1.SuspendLayout();
            translatableGroupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // translatableGroupBox1
            // 
            translatableGroupBox1.Controls.Add(textBox1);
            translatableGroupBox1.Dock = DockStyle.Top;
            translatableGroupBox1.LanguageReference = 54L;
            translatableGroupBox1.Location = new Point(0, 0);
            translatableGroupBox1.Name = "translatableGroupBox1";
            translatableGroupBox1.Size = new Size(283, 47);
            translatableGroupBox1.TabIndex = 0;
            translatableGroupBox1.TabStop = false;
            translatableGroupBox1.Text = "Username";
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(3, 19);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(277, 23);
            textBox1.TabIndex = 0;
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
            // PlayAsWhiteTranslatableRadioButton
            // 
            PlayAsWhiteTranslatableRadioButton.AutoSize = true;
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
            // PlayAsBlackTranslatableRadioButton
            // 
            PlayAsBlackTranslatableRadioButton.AutoSize = true;
            PlayAsBlackTranslatableRadioButton.Dock = DockStyle.Top;
            PlayAsBlackTranslatableRadioButton.LanguageReference = 58L;
            PlayAsBlackTranslatableRadioButton.Location = new Point(3, 38);
            PlayAsBlackTranslatableRadioButton.Name = "PlayAsBlackTranslatableRadioButton";
            PlayAsBlackTranslatableRadioButton.Size = new Size(277, 19);
            PlayAsBlackTranslatableRadioButton.TabIndex = 1;
            PlayAsBlackTranslatableRadioButton.TabStop = true;
            PlayAsBlackTranslatableRadioButton.Text = "Black";
            PlayAsBlackTranslatableRadioButton.UseVisualStyleBackColor = true;
            // 
            // LanCreateGameSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(283, 171);
            Controls.Add(translatableGroupBox2);
            Controls.Add(translatableGroupBox1);
            Name = "LanCreateGameSettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "[🌐] [Checkers] Create game";
            translatableGroupBox1.ResumeLayout(false);
            translatableGroupBox1.PerformLayout();
            translatableGroupBox2.ResumeLayout(false);
            translatableGroupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CustomComponents.TranslatableGroupBox translatableGroupBox1;
        private TextBox textBox1;
        private CustomComponents.TranslatableGroupBox translatableGroupBox2;
        private CustomComponents.TranslatableRadioButton PlayAsBlackTranslatableRadioButton;
        private CustomComponents.TranslatableRadioButton PlayAsWhiteTranslatableRadioButton;
    }
}