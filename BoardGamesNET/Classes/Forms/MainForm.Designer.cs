namespace BoardGamesNET.Classes.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MainMenuStrip = new MenuStrip();
            MenuTranslatableToolStripMenuItem = new CustomComponents.TranslatableToolStripMenuItem();
            FileQuitTranslatableToolStripMenuItem = new CustomComponents.TranslatableToolStripMenuItem();
            translatableToolStripMenuItem1 = new CustomComponents.TranslatableToolStripMenuItem();
            GamesCheckersTranslatableToolStripMenuItem = new CustomComponents.TranslatableToolStripMenuItem();
            GamesCheckersTwoPlayersTranslatableToolStripMenuItem = new CustomComponents.TranslatableToolStripMenuItem();
            GamesCheckersTwoPlayersLocalTranslatableToolStripMeniItem = new CustomComponents.TranslatableToolStripMenuItem();
            GamesCheckersTwoPlayersLanTranslatableToolStripMeniItem = new CustomComponents.TranslatableToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            GamesCheckersRulesTranslatableToolStripMeniItem = new CustomComponents.TranslatableToolStripMenuItem();
            translatableToolStripMenuItem2 = new CustomComponents.TranslatableToolStripMenuItem();
            OptionsSettingsTranslatableToolStripMenuItem = new CustomComponents.TranslatableToolStripMenuItem();
            TestToolStripMenuItem = new ToolStripMenuItem();
            MainMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // MainMenuStrip
            // 
            MainMenuStrip.Items.AddRange(new ToolStripItem[] { MenuTranslatableToolStripMenuItem, translatableToolStripMenuItem1, translatableToolStripMenuItem2, TestToolStripMenuItem });
            MainMenuStrip.Location = new Point(0, 0);
            MainMenuStrip.Name = "MainMenuStrip";
            MainMenuStrip.Size = new Size(800, 24);
            MainMenuStrip.TabIndex = 1;
            MainMenuStrip.Text = "menuStrip1";
            // 
            // MenuTranslatableToolStripMenuItem
            // 
            MenuTranslatableToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { FileQuitTranslatableToolStripMenuItem });
            MenuTranslatableToolStripMenuItem.LanguageReference = 1L;
            MenuTranslatableToolStripMenuItem.Name = "MenuTranslatableToolStripMenuItem";
            MenuTranslatableToolStripMenuItem.Size = new Size(37, 20);
            MenuTranslatableToolStripMenuItem.Text = "&File";
            // 
            // FileQuitTranslatableToolStripMenuItem
            // 
            FileQuitTranslatableToolStripMenuItem.Image = Resources.App.Quit;
            FileQuitTranslatableToolStripMenuItem.LanguageReference = 4L;
            FileQuitTranslatableToolStripMenuItem.Name = "FileQuitTranslatableToolStripMenuItem";
            FileQuitTranslatableToolStripMenuItem.Size = new Size(97, 22);
            FileQuitTranslatableToolStripMenuItem.Text = "&Quit";
            FileQuitTranslatableToolStripMenuItem.Click += FileQuitTranslatableToolStripMenuItem_Click;
            // 
            // translatableToolStripMenuItem1
            // 
            translatableToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { GamesCheckersTranslatableToolStripMenuItem });
            translatableToolStripMenuItem1.LanguageReference = 3L;
            translatableToolStripMenuItem1.Name = "translatableToolStripMenuItem1";
            translatableToolStripMenuItem1.Size = new Size(55, 20);
            translatableToolStripMenuItem1.Text = "&Games";
            // 
            // GamesCheckersTranslatableToolStripMenuItem
            // 
            GamesCheckersTranslatableToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { GamesCheckersTwoPlayersTranslatableToolStripMenuItem, toolStripSeparator1, GamesCheckersRulesTranslatableToolStripMeniItem });
            GamesCheckersTranslatableToolStripMenuItem.Image = Resources.Games.Checkers.GameIcon;
            GamesCheckersTranslatableToolStripMenuItem.LanguageReference = 10L;
            GamesCheckersTranslatableToolStripMenuItem.Name = "GamesCheckersTranslatableToolStripMenuItem";
            GamesCheckersTranslatableToolStripMenuItem.Size = new Size(122, 22);
            GamesCheckersTranslatableToolStripMenuItem.Text = "&Checkers";
            // 
            // GamesCheckersTwoPlayersTranslatableToolStripMenuItem
            // 
            GamesCheckersTwoPlayersTranslatableToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { GamesCheckersTwoPlayersLocalTranslatableToolStripMeniItem, GamesCheckersTwoPlayersLanTranslatableToolStripMeniItem });
            GamesCheckersTwoPlayersTranslatableToolStripMenuItem.Image = Resources.PlayerNumberIcons._02;
            GamesCheckersTwoPlayersTranslatableToolStripMenuItem.LanguageReference = 12L;
            GamesCheckersTwoPlayersTranslatableToolStripMenuItem.Name = "GamesCheckersTwoPlayersTranslatableToolStripMenuItem";
            GamesCheckersTwoPlayersTranslatableToolStripMenuItem.Size = new Size(120, 22);
            GamesCheckersTwoPlayersTranslatableToolStripMenuItem.Text = "&2 players";
            // 
            // GamesCheckersTwoPlayersLocalTranslatableToolStripMeniItem
            // 
            GamesCheckersTwoPlayersLocalTranslatableToolStripMeniItem.Image = Resources.App.HotSeat;
            GamesCheckersTwoPlayersLocalTranslatableToolStripMeniItem.LanguageReference = 14L;
            GamesCheckersTwoPlayersLocalTranslatableToolStripMeniItem.Name = "GamesCheckersTwoPlayersLocalTranslatableToolStripMeniItem";
            GamesCheckersTwoPlayersLocalTranslatableToolStripMeniItem.Size = new Size(102, 22);
            GamesCheckersTwoPlayersLocalTranslatableToolStripMeniItem.Text = "&Local";
            GamesCheckersTwoPlayersLocalTranslatableToolStripMeniItem.Click += GamesCheckersTwoPlayersLocalTranslatableToolStripMeniItem_Click;
            // 
            // GamesCheckersTwoPlayersLanTranslatableToolStripMeniItem
            // 
            GamesCheckersTwoPlayersLanTranslatableToolStripMeniItem.Enabled = false;
            GamesCheckersTwoPlayersLanTranslatableToolStripMeniItem.Image = Resources.App.LAN;
            GamesCheckersTwoPlayersLanTranslatableToolStripMeniItem.LanguageReference = 15L;
            GamesCheckersTwoPlayersLanTranslatableToolStripMeniItem.Name = "GamesCheckersTwoPlayersLanTranslatableToolStripMeniItem";
            GamesCheckersTwoPlayersLanTranslatableToolStripMeniItem.Size = new Size(102, 22);
            GamesCheckersTwoPlayersLanTranslatableToolStripMeniItem.Text = "L&AN";
            GamesCheckersTwoPlayersLanTranslatableToolStripMeniItem.ToolTipText = "Coming soon...";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(117, 6);
            // 
            // GamesCheckersRulesTranslatableToolStripMeniItem
            // 
            GamesCheckersRulesTranslatableToolStripMeniItem.Enabled = false;
            GamesCheckersRulesTranslatableToolStripMeniItem.Image = Resources.App.Rules;
            GamesCheckersRulesTranslatableToolStripMeniItem.LanguageReference = 13L;
            GamesCheckersRulesTranslatableToolStripMeniItem.Name = "GamesCheckersRulesTranslatableToolStripMeniItem";
            GamesCheckersRulesTranslatableToolStripMeniItem.Size = new Size(120, 22);
            GamesCheckersRulesTranslatableToolStripMeniItem.Text = "&Rules";
            GamesCheckersRulesTranslatableToolStripMeniItem.ToolTipText = "Coming soon...";
            // 
            // translatableToolStripMenuItem2
            // 
            translatableToolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { OptionsSettingsTranslatableToolStripMenuItem });
            translatableToolStripMenuItem2.LanguageReference = 2L;
            translatableToolStripMenuItem2.Name = "translatableToolStripMenuItem2";
            translatableToolStripMenuItem2.Size = new Size(61, 20);
            translatableToolStripMenuItem2.Text = "&Options";
            // 
            // OptionsSettingsTranslatableToolStripMenuItem
            // 
            OptionsSettingsTranslatableToolStripMenuItem.Image = Resources.App.Settings;
            OptionsSettingsTranslatableToolStripMenuItem.LanguageReference = 5L;
            OptionsSettingsTranslatableToolStripMenuItem.Name = "OptionsSettingsTranslatableToolStripMenuItem";
            OptionsSettingsTranslatableToolStripMenuItem.Size = new Size(116, 22);
            OptionsSettingsTranslatableToolStripMenuItem.Text = "&Settings";
            OptionsSettingsTranslatableToolStripMenuItem.Click += OptionsSettingsTranslatableToolStripMenuItem_Click;
            // 
            // TestToolStripMenuItem
            // 
            TestToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            TestToolStripMenuItem.Name = "TestToolStripMenuItem";
            TestToolStripMenuItem.Size = new Size(43, 20);
            TestToolStripMenuItem.Text = "TEST";
            TestToolStripMenuItem.Visible = false;
            TestToolStripMenuItem.Click += TestToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(MainMenuStrip);
            IsMdiContainer = true;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BoardGames.NET";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            MainMenuStrip.ResumeLayout(false);
            MainMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip MainMenuStrip;
        private CustomComponents.TranslatableToolStripMenuItem MenuTranslatableToolStripMenuItem;
        private CustomComponents.TranslatableToolStripMenuItem translatableToolStripMenuItem1;
        private CustomComponents.TranslatableToolStripMenuItem translatableToolStripMenuItem2;
        private CustomComponents.TranslatableToolStripMenuItem FileQuitTranslatableToolStripMenuItem;
        private CustomComponents.TranslatableToolStripMenuItem OptionsSettingsTranslatableToolStripMenuItem;
        private CustomComponents.TranslatableToolStripMenuItem GamesCheckersTranslatableToolStripMenuItem;
        private CustomComponents.TranslatableToolStripMenuItem GamesCheckersTwoPlayersTranslatableToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private CustomComponents.TranslatableToolStripMenuItem GamesCheckersRulesTranslatableToolStripMeniItem;
        private CustomComponents.TranslatableToolStripMenuItem GamesCheckersTwoPlayersLocalTranslatableToolStripMeniItem;
        private CustomComponents.TranslatableToolStripMenuItem GamesCheckersTwoPlayersLanTranslatableToolStripMeniItem;
        private ToolStripMenuItem TestToolStripMenuItem;
    }
}