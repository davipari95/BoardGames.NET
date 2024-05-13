namespace BoardGamesNET.Classes.Forms.Games.Checkers
{
    partial class ServerForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            translatableGroupBox3 = new CustomComponents.TranslatableGroupBox();
            PortNumberLabel = new Label();
            translatableGroupBox2 = new CustomComponents.TranslatableGroupBox();
            IPAddressLabel = new Label();
            LogTextBox = new TextBox();
            translatableGroupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            translatableGroupBox3.SuspendLayout();
            translatableGroupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // translatableGroupBox1
            // 
            translatableGroupBox1.Controls.Add(tableLayoutPanel1);
            translatableGroupBox1.Dock = DockStyle.Top;
            translatableGroupBox1.LanguageReference = 62L;
            translatableGroupBox1.Location = new Point(0, 0);
            translatableGroupBox1.Name = "translatableGroupBox1";
            translatableGroupBox1.Size = new Size(598, 79);
            translatableGroupBox1.TabIndex = 0;
            translatableGroupBox1.TabStop = false;
            translatableGroupBox1.Text = "Server informations";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(translatableGroupBox3, 1, 0);
            tableLayoutPanel1.Controls.Add(translatableGroupBox2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 19);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(592, 57);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // translatableGroupBox3
            // 
            translatableGroupBox3.Controls.Add(PortNumberLabel);
            translatableGroupBox3.Dock = DockStyle.Fill;
            translatableGroupBox3.LanguageReference = 59L;
            translatableGroupBox3.Location = new Point(299, 3);
            translatableGroupBox3.Name = "translatableGroupBox3";
            translatableGroupBox3.Size = new Size(290, 51);
            translatableGroupBox3.TabIndex = 1;
            translatableGroupBox3.TabStop = false;
            translatableGroupBox3.Text = "Port";
            // 
            // PortNumberLabel
            // 
            PortNumberLabel.Dock = DockStyle.Fill;
            PortNumberLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            PortNumberLabel.Location = new Point(3, 19);
            PortNumberLabel.Name = "PortNumberLabel";
            PortNumberLabel.Size = new Size(284, 29);
            PortNumberLabel.TabIndex = 1;
            PortNumberLabel.Text = "12345";
            PortNumberLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // translatableGroupBox2
            // 
            translatableGroupBox2.Controls.Add(IPAddressLabel);
            translatableGroupBox2.Dock = DockStyle.Fill;
            translatableGroupBox2.LanguageReference = 63L;
            translatableGroupBox2.Location = new Point(3, 3);
            translatableGroupBox2.Name = "translatableGroupBox2";
            translatableGroupBox2.Size = new Size(290, 51);
            translatableGroupBox2.TabIndex = 0;
            translatableGroupBox2.TabStop = false;
            translatableGroupBox2.Text = "IP address";
            // 
            // IPAddressLabel
            // 
            IPAddressLabel.Dock = DockStyle.Fill;
            IPAddressLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            IPAddressLabel.Location = new Point(3, 19);
            IPAddressLabel.Name = "IPAddressLabel";
            IPAddressLabel.Size = new Size(284, 29);
            IPAddressLabel.TabIndex = 0;
            IPAddressLabel.Text = "127.0.0.1";
            IPAddressLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LogTextBox
            // 
            LogTextBox.BackColor = Color.Black;
            LogTextBox.Dock = DockStyle.Fill;
            LogTextBox.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            LogTextBox.ForeColor = SystemColors.Control;
            LogTextBox.Location = new Point(0, 79);
            LogTextBox.Multiline = true;
            LogTextBox.Name = "LogTextBox";
            LogTextBox.ReadOnly = true;
            LogTextBox.Size = new Size(598, 443);
            LogTextBox.TabIndex = 1;
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(598, 522);
            Controls.Add(LogTextBox);
            Controls.Add(translatableGroupBox1);
            MinimumSize = new Size(416, 420);
            Name = "ServerForm";
            Text = "[Checkers] Server";
            translatableGroupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            translatableGroupBox3.ResumeLayout(false);
            translatableGroupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomComponents.TranslatableGroupBox translatableGroupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private CustomComponents.TranslatableGroupBox translatableGroupBox3;
        private CustomComponents.TranslatableGroupBox translatableGroupBox2;
        private Label IPAddressLabel;
        private Label PortNumberLabel;
        private TextBox LogTextBox;
    }
}