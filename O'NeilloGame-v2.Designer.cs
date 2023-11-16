namespace O_NeilloGame_v2
{
    partial class O_Neill_Game_Window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(O_Neill_Game_Window));
            labelGameInformation = new Label();
            menuStrip1 = new MenuStrip();
            gameToolStripMenuItem = new ToolStripMenuItem();
            newGameToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            saveGameToolStripMenuItem = new ToolStripMenuItem();
            restoreGameToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            speechToolStripMenuItem = new ToolStripMenuItem();
            informationPanelToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            labelSpeaking = new Label();
            pictureBoxPlayer1 = new PictureBox();
            labelPlayer1 = new Label();
            labelPlayer1Name = new Label();
            labelPlayer1TokenCount = new Label();
            labelPlayer1NumberOfTokens = new Label();
            labelPlayer1ToPlay = new Label();
            labelPlayer2ToPlay = new Label();
            labelPlayer2TokenCount = new Label();
            labelPlayer2NumberOfTokens = new Label();
            labelPlayer2Name = new Label();
            labelPlayer2 = new Label();
            pictureBoxPlayer2 = new PictureBox();
            labelNewGame = new Label();
            labelStartGameToChangeSettings = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPlayer1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPlayer2).BeginInit();
            SuspendLayout();
            // 
            // labelGameInformation
            // 
            labelGameInformation.AccessibleDescription = "labelGameInformation";
            labelGameInformation.AccessibleName = "labelGameInformation";
            labelGameInformation.AutoSize = true;
            labelGameInformation.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelGameInformation.Location = new Point(552, 40);
            labelGameInformation.Name = "labelGameInformation";
            labelGameInformation.Size = new Size(150, 21);
            labelGameInformation.TabIndex = 0;
            labelGameInformation.Text = "Game Information";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { gameToolStripMenuItem, settingsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            gameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newGameToolStripMenuItem, exitToolStripMenuItem, saveGameToolStripMenuItem, restoreGameToolStripMenuItem });
            gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            gameToolStripMenuItem.Size = new Size(50, 20);
            gameToolStripMenuItem.Text = "Game";
            // 
            // newGameToolStripMenuItem
            // 
            newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            newGameToolStripMenuItem.Size = new Size(147, 22);
            newGameToolStripMenuItem.Text = "New Game";
            newGameToolStripMenuItem.Click += newGameToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(147, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // saveGameToolStripMenuItem
            // 
            saveGameToolStripMenuItem.Name = "saveGameToolStripMenuItem";
            saveGameToolStripMenuItem.Size = new Size(147, 22);
            saveGameToolStripMenuItem.Text = "Save Game";
            saveGameToolStripMenuItem.Click += saveGameToolStripMenuItem_Click;
            // 
            // restoreGameToolStripMenuItem
            // 
            restoreGameToolStripMenuItem.Enabled = false;
            restoreGameToolStripMenuItem.Name = "restoreGameToolStripMenuItem";
            restoreGameToolStripMenuItem.Size = new Size(147, 22);
            restoreGameToolStripMenuItem.Text = "Restore Game";
            restoreGameToolStripMenuItem.Click += restoreGameToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { speechToolStripMenuItem, informationPanelToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(61, 20);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // speechToolStripMenuItem
            // 
            speechToolStripMenuItem.CheckOnClick = true;
            speechToolStripMenuItem.Name = "speechToolStripMenuItem";
            speechToolStripMenuItem.Size = new Size(180, 22);
            speechToolStripMenuItem.Text = "Speech";
            speechToolStripMenuItem.Click += speechToolStripMenuItem_Click;
            // 
            // informationPanelToolStripMenuItem
            // 
            informationPanelToolStripMenuItem.Checked = true;
            informationPanelToolStripMenuItem.CheckOnClick = true;
            informationPanelToolStripMenuItem.CheckState = CheckState.Checked;
            informationPanelToolStripMenuItem.Name = "informationPanelToolStripMenuItem";
            informationPanelToolStripMenuItem.Size = new Size(180, 22);
            informationPanelToolStripMenuItem.Text = "Information Panel";
            informationPanelToolStripMenuItem.Click += informationPanelToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(107, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // labelSpeaking
            // 
            labelSpeaking.AccessibleDescription = "labelSpeaking";
            labelSpeaking.AccessibleName = "labelSpeaking";
            labelSpeaking.AutoSize = true;
            labelSpeaking.Location = new Point(724, 426);
            labelSpeaking.Name = "labelSpeaking";
            labelSpeaking.Size = new Size(64, 15);
            labelSpeaking.TabIndex = 2;
            labelSpeaking.Text = "Speaking...";
            labelSpeaking.Visible = false;
            // 
            // pictureBoxPlayer1
            // 
            pictureBoxPlayer1.AccessibleDescription = "pictureBoxPlayer1";
            pictureBoxPlayer1.AccessibleName = "pictureBoxPlayer1";
            pictureBoxPlayer1.Image = (Image)resources.GetObject("pictureBoxPlayer1.Image");
            pictureBoxPlayer1.Location = new Point(555, 86);
            pictureBoxPlayer1.Name = "pictureBoxPlayer1";
            pictureBoxPlayer1.Size = new Size(44, 39);
            pictureBoxPlayer1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPlayer1.TabIndex = 3;
            pictureBoxPlayer1.TabStop = false;
            // 
            // labelPlayer1
            // 
            labelPlayer1.AccessibleDescription = "labelPlayer1";
            labelPlayer1.AccessibleName = "labelPlayer1";
            labelPlayer1.AutoSize = true;
            labelPlayer1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelPlayer1.Location = new Point(605, 86);
            labelPlayer1.Name = "labelPlayer1";
            labelPlayer1.Size = new Size(54, 15);
            labelPlayer1.TabIndex = 4;
            labelPlayer1.Text = "Player 1:";
            // 
            // labelPlayer1Name
            // 
            labelPlayer1Name.AccessibleDescription = "labelPlayer1Name";
            labelPlayer1Name.AccessibleName = "labelPlayer1Name";
            labelPlayer1Name.AutoSize = true;
            labelPlayer1Name.Location = new Point(665, 86);
            labelPlayer1Name.Name = "labelPlayer1Name";
            labelPlayer1Name.Size = new Size(55, 15);
            labelPlayer1Name.TabIndex = 5;
            labelPlayer1Name.Text = "Player #1";
            // 
            // labelPlayer1TokenCount
            // 
            labelPlayer1TokenCount.AccessibleDescription = "labelPlayer1TokenCount";
            labelPlayer1TokenCount.AccessibleName = "labelPlayer1TokenCount";
            labelPlayer1TokenCount.AutoSize = true;
            labelPlayer1TokenCount.Location = new Point(723, 110);
            labelPlayer1TokenCount.Name = "labelPlayer1TokenCount";
            labelPlayer1TokenCount.Size = new Size(13, 15);
            labelPlayer1TokenCount.TabIndex = 7;
            labelPlayer1TokenCount.Text = "0";
            // 
            // labelPlayer1NumberOfTokens
            // 
            labelPlayer1NumberOfTokens.AccessibleDescription = "labelPlayer1NumberOfTokens";
            labelPlayer1NumberOfTokens.AccessibleName = "labelPlayer1NumberOfTokens";
            labelPlayer1NumberOfTokens.AutoSize = true;
            labelPlayer1NumberOfTokens.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelPlayer1NumberOfTokens.Location = new Point(605, 110);
            labelPlayer1NumberOfTokens.Name = "labelPlayer1NumberOfTokens";
            labelPlayer1NumberOfTokens.Size = new Size(112, 15);
            labelPlayer1NumberOfTokens.TabIndex = 6;
            labelPlayer1NumberOfTokens.Text = "Number of tokens:";
            // 
            // labelPlayer1ToPlay
            // 
            labelPlayer1ToPlay.AccessibleDescription = "labelPlayer1ToPlay";
            labelPlayer1ToPlay.AccessibleName = "labelPlayer1ToPlay";
            labelPlayer1ToPlay.AutoSize = true;
            labelPlayer1ToPlay.Enabled = false;
            labelPlayer1ToPlay.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            labelPlayer1ToPlay.Location = new Point(605, 141);
            labelPlayer1ToPlay.Name = "labelPlayer1ToPlay";
            labelPlayer1ToPlay.Size = new Size(51, 15);
            labelPlayer1ToPlay.TabIndex = 8;
            labelPlayer1ToPlay.Text = "To Play";
            // 
            // labelPlayer2ToPlay
            // 
            labelPlayer2ToPlay.AccessibleDescription = "labelPlayer2ToPlay";
            labelPlayer2ToPlay.AccessibleName = "labelPlayer2ToPlay";
            labelPlayer2ToPlay.AutoSize = true;
            labelPlayer2ToPlay.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            labelPlayer2ToPlay.Location = new Point(605, 253);
            labelPlayer2ToPlay.Name = "labelPlayer2ToPlay";
            labelPlayer2ToPlay.Size = new Size(51, 15);
            labelPlayer2ToPlay.TabIndex = 14;
            labelPlayer2ToPlay.Text = "To Play";
            // 
            // labelPlayer2TokenCount
            // 
            labelPlayer2TokenCount.AccessibleDescription = "labelPlayer2TokenCount";
            labelPlayer2TokenCount.AccessibleName = "labelPlayer2TokenCount";
            labelPlayer2TokenCount.AutoSize = true;
            labelPlayer2TokenCount.Location = new Point(723, 222);
            labelPlayer2TokenCount.Name = "labelPlayer2TokenCount";
            labelPlayer2TokenCount.Size = new Size(13, 15);
            labelPlayer2TokenCount.TabIndex = 13;
            labelPlayer2TokenCount.Text = "0";
            // 
            // labelPlayer2NumberOfTokens
            // 
            labelPlayer2NumberOfTokens.AccessibleDescription = "labelPlayer2NumberOfTokens";
            labelPlayer2NumberOfTokens.AccessibleName = "labelPlayer2NumberOfTokens";
            labelPlayer2NumberOfTokens.AutoSize = true;
            labelPlayer2NumberOfTokens.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelPlayer2NumberOfTokens.Location = new Point(605, 222);
            labelPlayer2NumberOfTokens.Name = "labelPlayer2NumberOfTokens";
            labelPlayer2NumberOfTokens.Size = new Size(112, 15);
            labelPlayer2NumberOfTokens.TabIndex = 12;
            labelPlayer2NumberOfTokens.Text = "Number of tokens:";
            // 
            // labelPlayer2Name
            // 
            labelPlayer2Name.AccessibleDescription = "labelPlayer2Name";
            labelPlayer2Name.AccessibleName = "labelPlayer2Name";
            labelPlayer2Name.AutoSize = true;
            labelPlayer2Name.Location = new Point(665, 198);
            labelPlayer2Name.Name = "labelPlayer2Name";
            labelPlayer2Name.Size = new Size(55, 15);
            labelPlayer2Name.TabIndex = 11;
            labelPlayer2Name.Text = "Player #2";
            // 
            // labelPlayer2
            // 
            labelPlayer2.AccessibleDescription = "labelPlayer2";
            labelPlayer2.AccessibleName = "labelPlayer2";
            labelPlayer2.AutoSize = true;
            labelPlayer2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelPlayer2.Location = new Point(605, 198);
            labelPlayer2.Name = "labelPlayer2";
            labelPlayer2.Size = new Size(54, 15);
            labelPlayer2.TabIndex = 10;
            labelPlayer2.Text = "Player 2:";
            // 
            // pictureBoxPlayer2
            // 
            pictureBoxPlayer2.AccessibleDescription = "pictureBoxPlayer2";
            pictureBoxPlayer2.AccessibleName = "pictureBoxPlayer2";
            pictureBoxPlayer2.Image = (Image)resources.GetObject("pictureBoxPlayer2.Image");
            pictureBoxPlayer2.Location = new Point(555, 198);
            pictureBoxPlayer2.Name = "pictureBoxPlayer2";
            pictureBoxPlayer2.Size = new Size(44, 39);
            pictureBoxPlayer2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPlayer2.TabIndex = 9;
            pictureBoxPlayer2.TabStop = false;
            // 
            // labelNewGame
            // 
            labelNewGame.AccessibleDescription = "labelNewGame";
            labelNewGame.AccessibleName = "labelNewGame";
            labelNewGame.AutoSize = true;
            labelNewGame.Location = new Point(25, 46);
            labelNewGame.Name = "labelNewGame";
            labelNewGame.Size = new Size(170, 15);
            labelNewGame.TabIndex = 15;
            labelNewGame.Text = "To start, use the \"Game\" menu.";
            // 
            // labelStartGameToChangeSettings
            // 
            labelStartGameToChangeSettings.AccessibleDescription = "labelStartGameToChangeSettings";
            labelStartGameToChangeSettings.AccessibleName = "labelStartGameToChangeSettings";
            labelStartGameToChangeSettings.AutoSize = true;
            labelStartGameToChangeSettings.Location = new Point(25, 73);
            labelStartGameToChangeSettings.Name = "labelStartGameToChangeSettings";
            labelStartGameToChangeSettings.Size = new Size(479, 15);
            labelStartGameToChangeSettings.TabIndex = 16;
            labelStartGameToChangeSettings.Text = "Please start a game to change game settings. Saved setting will be restored on game load.";
            labelStartGameToChangeSettings.Visible = false;
            // 
            // O_Neill_Game_Window
            // 
            AccessibleDescription = "O_Neill_Game_Window";
            AccessibleName = "O_Neill_Game_Window";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelStartGameToChangeSettings);
            Controls.Add(labelNewGame);
            Controls.Add(labelPlayer2ToPlay);
            Controls.Add(labelPlayer2TokenCount);
            Controls.Add(labelPlayer2NumberOfTokens);
            Controls.Add(labelPlayer2Name);
            Controls.Add(labelPlayer2);
            Controls.Add(pictureBoxPlayer2);
            Controls.Add(labelPlayer1ToPlay);
            Controls.Add(labelPlayer1TokenCount);
            Controls.Add(labelPlayer1NumberOfTokens);
            Controls.Add(labelPlayer1Name);
            Controls.Add(labelPlayer1);
            Controls.Add(pictureBoxPlayer1);
            Controls.Add(labelSpeaking);
            Controls.Add(labelGameInformation);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MaximumSize = new Size(816, 489);
            MinimumSize = new Size(816, 489);
            Name = "O_Neill_Game_Window";
            Text = "O'Neill Game";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPlayer1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPlayer2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelGameInformation;
        private MenuStrip menuStrip1;
        private Label labelSpeaking;
        private PictureBox pictureBoxPlayer1;
        private Label labelPlayer1;
        private Label labelPlayer1Name;
        private Label labelPlayer1TokenCount;
        private Label labelPlayer1NumberOfTokens;
        private Label labelPlayer1ToPlay;
        private Label labelPlayer2ToPlay;
        private Label labelPlayer2TokenCount;
        private Label labelPlayer2NumberOfTokens;
        private Label labelPlayer2Name;
        private Label labelPlayer2;
        private PictureBox pictureBoxPlayer2;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private ToolStripMenuItem speechToolStripMenuItem;
        private ToolStripMenuItem informationPanelToolStripMenuItem;
        private Label labelNewGame;
        private Label labelStartGameToChangeSettings;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem saveGameToolStripMenuItem;
        private ToolStripMenuItem restoreGameToolStripMenuItem;
    }
}