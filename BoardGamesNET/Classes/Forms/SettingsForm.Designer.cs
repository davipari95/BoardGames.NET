namespace BoardGamesNET.Classes.Forms
{
    partial class SettingsForm
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
            translatableLabel1 = new CustomComponents.TranslatableLabel();
            AvailableLanguagesComboBox = new ComboBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            CancelTranslatableButton = new CustomComponents.TranslatableButton();
            SaveTranslatableButton = new CustomComponents.TranslatableButton();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 141F));
            tableLayoutPanel1.Controls.Add(translatableLabel1, 0, 0);
            tableLayoutPanel1.Controls.Add(AvailableLanguagesComboBox, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(363, 30);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // translatableLabel1
            // 
            translatableLabel1.AutoSize = true;
            translatableLabel1.Dock = DockStyle.Fill;
            translatableLabel1.LanguageReference = 7L;
            translatableLabel1.Location = new Point(3, 0);
            translatableLabel1.Name = "translatableLabel1";
            translatableLabel1.Size = new Size(216, 30);
            translatableLabel1.TabIndex = 0;
            translatableLabel1.Text = "Active langauge:";
            translatableLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // AvailableLanguagesComboBox
            // 
            AvailableLanguagesComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            AvailableLanguagesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            AvailableLanguagesComboBox.FormattingEnabled = true;
            AvailableLanguagesComboBox.Location = new Point(225, 3);
            AvailableLanguagesComboBox.Name = "AvailableLanguagesComboBox";
            AvailableLanguagesComboBox.Size = new Size(135, 23);
            AvailableLanguagesComboBox.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(CancelTranslatableButton, 0, 0);
            tableLayoutPanel2.Controls.Add(SaveTranslatableButton, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Bottom;
            tableLayoutPanel2.Location = new Point(0, 35);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(363, 43);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // CancelTranslatableButton
            // 
            CancelTranslatableButton.Dock = DockStyle.Fill;
            CancelTranslatableButton.LanguageReference = 8L;
            CancelTranslatableButton.Location = new Point(3, 3);
            CancelTranslatableButton.Name = "CancelTranslatableButton";
            CancelTranslatableButton.Size = new Size(175, 37);
            CancelTranslatableButton.TabIndex = 0;
            CancelTranslatableButton.Text = "&Cancel";
            CancelTranslatableButton.UseVisualStyleBackColor = true;
            CancelTranslatableButton.Click += CancelTranslatableButton_Click;
            // 
            // SaveTranslatableButton
            // 
            SaveTranslatableButton.Dock = DockStyle.Fill;
            SaveTranslatableButton.LanguageReference = 9L;
            SaveTranslatableButton.Location = new Point(184, 3);
            SaveTranslatableButton.Name = "SaveTranslatableButton";
            SaveTranslatableButton.Size = new Size(176, 37);
            SaveTranslatableButton.TabIndex = 1;
            SaveTranslatableButton.Text = "&Save";
            SaveTranslatableButton.UseVisualStyleBackColor = true;
            SaveTranslatableButton.Click += SaveTranslatableButton_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(363, 78);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings";
            Load += SettingsForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private CustomComponents.TranslatableLabel translatableLabel1;
        private ComboBox AvailableLanguagesComboBox;
        private TableLayoutPanel tableLayoutPanel2;
        private CustomComponents.TranslatableButton CancelTranslatableButton;
        private CustomComponents.TranslatableButton SaveTranslatableButton;
    }
}