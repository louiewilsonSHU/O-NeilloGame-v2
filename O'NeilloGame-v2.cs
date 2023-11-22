using GameboardGUI;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace O_NeilloGame_v2
{
    public partial class O_Neill_Game_Window : Form
    {
        //declare global Boolean flag used in the game associated with the speech application rule
        private bool speechEnabled; //speech, default is off
        public bool SpeechEnabled { get { return this.speechEnabled; } set { this.speechEnabled = value; } }

        //declare application rule variable, assign saved string
        private string applicationRule = File.ReadAllLines("./gamesaves/game_data.json")[0];

        //declare speech variable, assign new speech synthesis object
        private SpeechSynthesizer speech = new();

        //declare game variable, assignment comes when creating a new game or opening existing game
        private GameLogic game;

        /// <summary>
        /// Constructor method for game window
        /// </summary>
        public O_Neill_Game_Window()
        {
            InitializeComponent();
        }

        ///<summary> Event handler for if a game board tile was clicked </summary>
        private void GameTileClicked(object sender, EventArgs e)
        {
            //get the row and column of the tile clicked
            int row = game.gameBoard.GetCurrentRowIndex(sender);
            int column = game.gameBoard.GetCurrentColumnIndex(sender);

            //save the current (original state of the) tile, in case it must be reverted
            int originalTile = game.gameBoardData[row, column];

            //set the tile to the player's colour if the tile was a "10" tile
            if (originalTile == 10)
            {
                game.gameBoardData[row, column] = game.Player;
            }
            else
            {
                if (SpeechEnabled) { say($"Player {(game.Player == 0 ? 2 : 1)} illegally tried to place a tile at row {row} column {column}"); }
                MessageBox.Show("Illegal move");

                //reset tile to its original state
                game.gameBoardData[row, column] = originalTile;


                //do not process the event handler any further
                return;
            }

            //check if the move was legal

            if (!GameLogic.checkForIllegalMove(game.gameBoardData, row, column, game.Player))
            {
                if (SpeechEnabled) { say($"Player {(game.Player == 0 ? 2 : 1)} placed a tile at row {row} column {column}"); }

                //check if any tiles need flipping and flip them
                List<List<int>> tilesToFlip = GameLogic.processMove(game.gameBoardData, row, column, game.Player);
                foreach (List<int> tileToFlip in tilesToFlip)
                {
                    game.gameBoardData[tileToFlip[0], tileToFlip[1]] = game.Player == 1 ? 1 : 0;
                }

                //update numbers of tiles
                updateTileNumbers();

                //update the game board
                game.gameBoard.UpdateBoardGui(game.gameBoardData);

                //next player, output if the next player has no valid moves
                if (invertPlayer() == -1)
                {
                    if (SpeechEnabled) { say($"Player {(game.Player == 0 ? 2 : 1)} has no valid moves"); }
                    MessageBox.Show($"Player {(game.Player == 0 ? 2 : 1)} has no valid moves");

                    //invert player again, and check if the next player has no valid moves
                    if (invertPlayer() == -1 || Convert.ToInt32(labelPlayer1TokenCount.Text) == 0 || Convert.ToInt32(labelPlayer2TokenCount.Text) == 0)
                    {
                        game.gameOver(Convert.ToInt32(labelPlayer1TokenCount.Text), Convert.ToInt32(labelPlayer2TokenCount.Text));
                    }
                }


            }
            else
            {
                if (SpeechEnabled) { say($"Player {(game.Player == 0 ? 2 : 1)} illegally tried to place a tile at row {row} column {column}"); }
                MessageBox.Show("Illegal move");

                //reset tile to its original state
                game.gameBoardData[row, column] = originalTile;

                //update the game board
                game.gameBoard.UpdateBoardGui(game.gameBoardData);
            }
        }

        /// <summary>
        /// Updates numbers of tiles for each player
        /// </summary>
        private void updateTileNumbers()
        {
            //declare total variables, assign 0 to both
            int player1Tiles = 0, player2Tiles = 0;

            //count each type of tile on the board
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    switch (game.gameBoardData[row, column])
                    {
                        case 0:
                            player2Tiles++;
                            break;
                        case 1:
                            player1Tiles++;
                            break;
                    }
                }
            }
            labelPlayer1TokenCount.Text = Convert.ToString(player1Tiles);
            labelPlayer2TokenCount.Text = Convert.ToString(player2Tiles);
        }

        ///<summary> Initialise board array - set all cells to blank, then add starter colours </summary>
        private void createBoard()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    game.gameBoardData[row, column] = 10;
                }
            }

            //assign starter colours to respective cells
            game.gameBoardData[3, 3] = 0;
            game.gameBoardData[4, 4] = 0;
            game.gameBoardData[4, 3] = 1;
            game.gameBoardData[3, 4] = 1;
        }

        /// <summary>
        ///Switches the player from player 1 to player 2, or vice versa
        /// </summary>
        /// <returns>New player number</returns>
        public int invertPlayer()
        {
            if (game.Player == 1) //set player to player 2 (black), noted as "0" here to coincide with the tile filename
            {
                game.Player = 0;
                labelPlayer1ToPlay.Enabled = false;
                labelPlayer2ToPlay.Enabled = true;
            }
            else if (game.Player == 0) //set player to player 1 (white)
            {
                game.Player = 1;
                labelPlayer1ToPlay.Enabled = true;
                labelPlayer2ToPlay.Enabled = false;
            }
            //check if the new player has a valid move available or not
            if (!GameLogic.checkForValidMove(game.gameBoardData, game.Player))
            {
                //if there are no valid moves
                return -1;
            }
            return game.Player;
        }

        ///<summary> Makes the speaking label visible, says the data, makes the speaking label invisible</summary>
        ///<param name="stringToSay">Contains the text to convert to speech</param>
        public void say(string stringToSay)
        {
            labelSpeaking.Visible = true;
            speech.Speak(stringToSay);
            labelSpeaking.Visible = false;
        }

        /// <summary>
        /// Event handler for if the "About" menu option is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(File.ReadAllText("../../../README.md"));
        }

        /// <summary>
        /// Event handler for if the "Speech" menu option is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void speechToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleSpeech();

            try
            {
                if (SpeechEnabled)
                {
                    File.WriteAllText("./gamesaves/game_data.json", File.ReadAllText("./gamesaves/game_data.json").Replace("~speech:false~", "~speech:true~"));
                }
                else
                {
                    File.WriteAllText("./gamesaves/game_data.json", File.ReadAllText("./gamesaves/game_data.json").Replace("~speech:true~", "~speech:false~"));
                }
            }
            catch (NullReferenceException) { MessageBox.Show("Please start a game to change game settings. Saved setting will be restored on game load."); } //this error would be thrown if there is no game object instantiated, so there is no game in progress
        }

        /// <summary>
        /// Toggles speech on or off.
        /// </summary>
        private void toggleSpeech()
        {
            try
            {
                if (SpeechEnabled) { SpeechEnabled = false; speechToolStripMenuItem.Checked = false; say("Speech disabled"); }
                else { SpeechEnabled = true; speechToolStripMenuItem.Checked = true; say($"Speech enabled."); }
            }
            //if there is no gameLogic instance assigned to game variable
            catch (NullReferenceException) { labelStartGameToChangeSettings.Visible = true; speechToolStripMenuItem.Checked = false; }
        }

        /// <summary>
        /// Event handler for if the "Information Panel" menu option is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void informationPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleInformationPanel();

            try
            {
                if (labelGameInformation.Visible)
                {
                    File.WriteAllText("./gamesaves/game_data.json", File.ReadAllText("./gamesaves/game_data.json").Replace("~informationPanel:false~", "~informationPanel:true~"));
                }
                else
                {
                    File.WriteAllText("./gamesaves/game_data.json", File.ReadAllText("./gamesaves/game_data.json").Replace("~informationPanel:true~", "~informationPanel:false~"));
                }
            }
            catch (NullReferenceException) { MessageBox.Show("Please start a game to change game settings. Saved setting will be restored on game load."); } //this error would be thrown if there is no game object instantiated, so there is no game in progress
        }

        /// <summary>
        /// Toggles the information panel on or off
        /// </summary>
        private void toggleInformationPanel()
        {
            try
            {
                if (labelGameInformation.Visible)
                {
                    labelGameInformation.Visible = false;
                    informationPanelToolStripMenuItem.Checked = false;
                    labelGameInformation.Visible = false;
                    pictureBoxPlayer1.Visible = false;
                    pictureBoxPlayer2.Visible = false;
                    labelPlayer1.Visible = false;
                    labelPlayer2.Visible = false;
                    labelPlayer1Name.Visible = false;
                    labelPlayer2Name.Visible = false;
                    labelPlayer1TokenCount.Visible = false;
                    labelPlayer2TokenCount.Visible = false;
                    labelPlayer1NumberOfTokens.Visible = false;
                    labelPlayer2NumberOfTokens.Visible = false;
                    labelPlayer1ToPlay.Visible = false;
                    labelPlayer2ToPlay.Visible = false;
                    if (SpeechEnabled) { say("Information panel off"); }
                }
                else if (!labelGameInformation.Visible)
                {
                    labelGameInformation.Visible = true;
                    informationPanelToolStripMenuItem.Checked = true;
                    labelGameInformation.Visible = true;
                    pictureBoxPlayer1.Visible = true;
                    pictureBoxPlayer2.Visible = true;
                    labelPlayer1.Visible = true;
                    labelPlayer2.Visible = true;
                    labelPlayer1Name.Visible = true;
                    labelPlayer2Name.Visible = true;
                    labelPlayer1TokenCount.Visible = true;
                    labelPlayer2TokenCount.Visible = true;
                    labelPlayer1NumberOfTokens.Visible = true;
                    labelPlayer2NumberOfTokens.Visible = true;
                    labelPlayer1ToPlay.Visible = true;
                    labelPlayer2ToPlay.Visible = true;
                    if (SpeechEnabled) { say("Information panel on"); }
                }
            }
            //if there is no gameLogic instance assigned to game variable
            catch (NullReferenceException) { labelStartGameToChangeSettings.Visible = true; informationPanelToolStripMenuItem.Checked = true; }
        }

        /// <summary>
        /// Event handler for if the "New Game" menu option is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //hide new game message and "start game to change settings" message if it is visible
            labelNewGame.Visible = false;
            labelStartGameToChangeSettings.Visible = false;

            //check if there is a game in progress and prompt user to save if so
            try
            {
                if (game.GameInProgress)
                {
                    saveGame();
                }
            }
            catch (NullReferenceException) { } //this error would be thrown if there is no game object instantiated, so there is no game in progress

            //once there are no outstanding games to save, start a new game
            createNewGameInstance();
        }

        /// <summary>
        /// Restores a game save from the game saves file
        /// </summary>
        private void restoreGame()
        {
            //get a dictionary of the current game saves, create a string of keys (separated with space) to be used when checking if a game save with the name save already exists and declare string to store chosen game JSON
            var currentGameSavesDictionary = new Dictionary<string, string>();
            string keys = "";
            string gameJson;
            foreach (string gameSave in File.ReadAllLines("./gamesaves/game_data.json"))
            {
                if (gameSave.Trim() == "") { continue; }
                else if (gameSave.Trim().Contains("~applicationRule~")) { continue; }
                currentGameSavesDictionary.Add(gameSave.Split(':')[0], gameSave.Substring(gameSave.Split(':')[0].Length + 1));
                keys += $"{gameSave.Split(':')[0]} ";
            }

            //declare integer variable, assignment comes when user selects which save to overwrite
            int gameSaveChoice = 0;

            //check if only one game save, restore that one, if not then let user choose
            if (keys.Split(' ').Length == 2)
            {
                //get game save as a string
                gameJson = currentGameSavesDictionary[keys.Split(' ')[0]];
            }
            else
            {
                //create prompt string based on how many game saves there are
                string prompt = $"Enter the number of the game save to restore.\nPress \"Cancel\" or enter 0 to cancel.";
                for (int iterator = 0; iterator < keys.Split(' ').Length; iterator++)
                {
                    if (keys.Split(' ')[iterator].Trim() == "") { continue; }
                    prompt += $"\n{iterator + 1}. {keys.Split(' ')[iterator].Replace('_', ' ')}";
                }

                //while loop used for validation - continue prompting user for valid entry until entry is valid
                while (true)
                {
                    //try...catch statement used for presence and type check
                    try
                    {
                        gameSaveChoice = Convert.ToInt32(Interaction.InputBox(prompt, "O'Neillo Game"));

                        //check if the user selected "Cancel"
                        if (gameSaveChoice == 0) { return; }

                        //validation - range check
                        if (!(gameSaveChoice > 0 && gameSaveChoice < keys.Split(' ').Length))
                        {
                            MessageBox.Show("Please enter a valid input.");
                        }
                        else { break; }
                    }
                    catch (FormatException)
                    {
                        //check if the user selected "Cancel"
                        if (gameSaveChoice == 0) { return; }

                        //if the user did not select "Cancel"
                        MessageBox.Show("Please enter a valid input.");
                    }
                }

                //get game save as a string
                gameJson = currentGameSavesDictionary[keys.Split(' ')[gameSaveChoice - 1]];
            }

            //destroy the current game board if there is one instantiated
            try
            { if (game.GameInProgress) { game.gameBoard.destroy(); } }
            catch (NullReferenceException) { }

            //create the GameLogic instance using the game save
            game = new GameLogic();

            //de-serialize game properties and assign to respective game variables
            JObject gameJsonObject = JsonConvert.DeserializeObject<JObject>(gameJson);
            game.gameBoardData = JsonConvert.DeserializeObject<int[,]>(Convert.ToString(gameJsonObject["gameBoardData"]));

            game.Player = JsonConvert.DeserializeObject<int>(Convert.ToString(gameJsonObject["Player"]));

            //set relevant player "To Play" label to enabled
            if (game.Player == 1)
            {
                labelPlayer1ToPlay.Enabled = true;
                labelPlayer2ToPlay.Enabled = false;
            }
            else
            {
                labelPlayer1ToPlay.Enabled = false;
                labelPlayer2ToPlay.Enabled = true;
            }

            //assign names to the window and to the respective game variables
            game.Player1Name = Convert.ToString(gameJsonObject["Player1Name"]);
            game.Player2Name = Convert.ToString(gameJsonObject["Player2Name"]);
            labelPlayer1Name.Text = game.Player1Name;
            labelPlayer2Name.Text = game.Player2Name;

            //align the board to the left to leave space for the information panel using the two Point objects
            game.gameBoard = new GameboardImageArray(this, game.gameBoardData, new Point(5, 29), new Point(253, 5), 1, game.imagePath);
            game.gameBoard.TileClicked += new GameboardImageArray.TileClickedEventDelegate(GameTileClicked);

            //update the game board
            game.gameBoard.UpdateBoardGui(game.gameBoardData);

            //update tile numbers
            updateTileNumbers();

            //disable any starter messages that may be visible
            labelNewGame.Visible = false;
            labelStartGameToChangeSettings.Visible = false;

            //restore application rule
            applicationRule = File.ReadAllLines("./gamesaves/game_data.json")[0];
            if (applicationRule.Split("speech:")[1].Split("~")[0] == "true" && !SpeechEnabled) { toggleSpeech(); }
            else if (applicationRule.Split("speech:")[1].Split("~")[0] == "false" && SpeechEnabled) { toggleSpeech(); }
            if (applicationRule.Split("informationPanel:")[1].Split("~")[0] == "false" && labelGameInformation.Visible) { toggleInformationPanel(); }
            else if (applicationRule.Split("informationPanel:")[1].Split("~")[0] == "true" && !labelGameInformation.Visible) { toggleInformationPanel(); toggleInformationPanel(); }
        }

        /// <summary>
        /// Allows the user to save the currently-in-progress game
        /// </summary>
        private void saveGame()
        {
            //declare string, user will input game save name and will be assigned to this variable
            string gameSaveName;

            //get a dictionary of the current game saves, and create a string of keys (separated with space) to be used when checking if a game save with the name save already exists
            var currentGameSavesDictionary = new Dictionary<string, string>();
            string keys = "";
            foreach (string gameSave in File.ReadAllLines("./gamesaves/game_data.json"))
            {
                if (gameSave.Trim() == "") { continue; }
                else if (gameSave.Trim().Contains("~applicationRule~")) { continue; }
                currentGameSavesDictionary.Add(gameSave.Split(':')[0], gameSave.Substring(gameSave.Split(':')[0].Length + 1));
                keys += $"{gameSave.Split(':')[0]} ";
            }

            //while loop used for validation - continue prompting user for valid entry until entry is valid
            while (true)
            {
                gameSaveName = Interaction.InputBox("Please choose a name for your game save.\nPress \"Cancel\" or leave blank to skip saving.", "O'Neillo Game", Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")));
                //replace all spaces with underscores
                gameSaveName = gameSaveName.Replace(' ', '_');

                //if the user enters nothing or presses "Cancel", do not save
                if (gameSaveName.Trim() == "")
                {
                    return;
                }
                //check for duplicate game save, prompt to overwrite
                else if (keys.Contains(gameSaveName))
                {
                    if (MessageBox.Show("A game save with this name already exists. Okay to overwrite?", "O'Neillo Game", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //overwrite here and process this method no further (number of saves will not change)
                        currentGameSavesDictionary[gameSaveName] = JsonConvert.SerializeObject(game, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                        File.WriteAllText("./gamesaves/game_data.json", $"~applicationRule~speech:{Convert.ToString(SpeechEnabled).ToLower()}~informationPanel:{Convert.ToString(labelGameInformation.Visible).ToLower()}~");
                        foreach (string key in keys.Split(' '))
                        {
                            if (key == "") { continue; }
                            else if (key.Trim().Contains("~applicationRule~")) { continue; }
                            File.AppendAllText("./gamesaves/game_data.json", $"\n{key}:{currentGameSavesDictionary[key]}");
                            //enable the "Restore Game" menu option
                            restoreGameToolStripMenuItem.Enabled = true;
                        }
                        MessageBox.Show("Success");
                        return;
                    }
                }
                else { break; }
            }
            //check if there are 5 game saves, choose which to overwrite if there are
            //(the logic counts the application rule as a game save, hence the condition looking for 6 keys)
            if (keys.Split(' ').Length > 5)
            {
                //declare integer variable, assignment comes when user selects which save to overwrite
                int overwriteChoice;

                //while loop used for validation - continue prompting user for valid entry until entry is valid
                while (true)
                {
                    //try...catch statement used for presence and type check
                    try
                    {
                        overwriteChoice = Convert.ToInt32(Interaction.InputBox($"You already have five game saves.\nEnter the number of the game save to overwrite\n1. {keys.Split(' ')[0]}\n2. {keys.Split(' ')[1]}\n3. {keys.Split(' ')[2]}\n4. {keys.Split(' ')[3]}\n5. {keys.Split(' ')[4]}".Replace('_', ' '), "O'Neillo Game"));

                        //validation - range check
                        if (!(overwriteChoice == 1 || overwriteChoice == 2 || overwriteChoice == 3 || overwriteChoice == 4 || overwriteChoice == 5))
                        {
                            MessageBox.Show("Please enter a valid input.");
                        }
                        else { break; }
                    }
                    catch (FormatException) { MessageBox.Show("Please enter a valid input."); }
                }

                //replace selected game save with new game save
                currentGameSavesDictionary.Remove(keys.Split(' ')[overwriteChoice - 1]);
                keys = keys.Replace(keys.Split(' ')[overwriteChoice - 1], gameSaveName);
                currentGameSavesDictionary.Add(gameSaveName, JsonConvert.SerializeObject(game, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));

                //overwrite game saves file
                File.WriteAllText("./gamesaves/game_data.json", $"~applicationRule~speech:{Convert.ToString(SpeechEnabled).ToLower()}~informationPanel:{Convert.ToString(labelGameInformation.Visible).ToLower()}~");
                foreach (string key in keys.Split(' '))
                {
                    if (key.Trim() == "") { continue; }
                    File.AppendAllText("./gamesaves/game_data.json", $"\n{key}:{currentGameSavesDictionary[key]}");
                }
                //enable the "Restore Game" menu option
                restoreGameToolStripMenuItem.Enabled = true;
                MessageBox.Show("Success");
                return;
            }
            //if none of the above conditions matched, append the game save to the game saves file
            gameSaveName = gameSaveName.Trim();
            File.AppendAllText("./gamesaves/game_data.json", $"\n{gameSaveName}:{JsonConvert.SerializeObject(game, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })}");
            //enable the "Restore Game" menu option
            restoreGameToolStripMenuItem.Enabled = true;
            MessageBox.Show("Success");
        }

        /// <summary>
        /// Creates a new game instance
        /// </summary>
        private void createNewGameInstance()
        {
            //destroy the current game class if there is one instantiated
            try
            { game.gameBoard.destroy(); }
            catch (NullReferenceException) { }

            //create new GameLogic instance, assign to game variable
            game = new GameLogic();

            //get player 1 and 2 names using input boxes and validate both
            string player1InputName = Interaction.InputBox("Player 1, please enter your name.\nLeave blank or press \"Cancel\" for default name.", "O'Neillo Game");
            string player2InputName = Interaction.InputBox("Player 2, please enter your name.\nLeave blank or press \"Cancel\" for default name.", "O'Neillo Game");

            //check for blank inputs, to set the player name to "Player [number]"
            if (player1InputName.Trim() == "")
            {
                player1InputName = "Player #1";
            }
            if (player2InputName.Trim() == "")
            {
                player2InputName = "Player #2";
            }

            //assign names to the window and to the respective game variables
            labelPlayer1Name.Text = player1InputName;
            labelPlayer2Name.Text = player2InputName;

            game.Player1Name = player1InputName;
            game.Player2Name = player2InputName;

            //draw the game board
            createBoard();

            //update tile numbers
            updateTileNumbers();


            //set Player 2 to play
            labelPlayer1ToPlay.Enabled = false;
            labelPlayer2ToPlay.Enabled = true;

            //create new GameBoardImageArray instance
            //align the board to the left to leave space for the information panel using the two Point objects
            game.gameBoard = new GameboardImageArray(this, game.gameBoardData, new Point(5, 29), new Point(253, 5), 1, game.imagePath);
            game.gameBoard.TileClicked += new GameboardImageArray.TileClickedEventDelegate(GameTileClicked);

            //restore application rule
            //set speech to off (assign false)
            SpeechEnabled = false;
            applicationRule = File.ReadAllLines("./gamesaves/game_data.json")[0];
            if (applicationRule.Split("speech:")[1].Split("~")[0] == "true" && !SpeechEnabled) { toggleSpeech(); }
            else if (applicationRule.Split("speech:")[1].Split("~")[0] == "false" && SpeechEnabled) { toggleSpeech(); }
            if (applicationRule.Split("informationPanel:")[1].Split("~")[0] == "false" && labelGameInformation.Visible) { toggleInformationPanel(); }
            else if (applicationRule.Split("informationPanel:")[1].Split("~")[0] == "true" && !labelGameInformation.Visible) { toggleInformationPanel(); toggleInformationPanel(); }

            //update the game board
            game.gameBoard.UpdateBoardGui(game.gameBoardData);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check if there is a game in progress and prompt user to save if so
            try
            {
                if (game.GameInProgress)
                {
                    saveGame();
                }
            }
            catch (NullReferenceException) { } //this error would be thrown if there is no game object instantiated, so there is no game in progress
            Application.Exit();
        }

        /// <summary>
        /// Event handler for if the user selects the "Save Game" menu option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check if there is a game in progress and prompt user to save if so
            try
            {
                if (game.GameInProgress)
                {
                    saveGame();
                }
                else { MessageBox.Show("No game in progress."); }
            }
            catch (NullReferenceException) { MessageBox.Show("No game in progress."); } //this error would be thrown if there is no game object instantiated, so there is no game in progress
        }

        /// <summary>
        /// Event handler for if the "Restore Game" menu option is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restoreGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            restoreGame();
        }

        private void O_Neill_Game_Window_Load(object sender, EventArgs e)
        {
            //if there is a game save already saved, then enable the "Restore Game" menu option
            if (File.ReadAllLines("./gamesaves/game_data.json").Length > 1) { restoreGameToolStripMenuItem.Enabled = true; }

            //restore application rule
            applicationRule = File.ReadAllLines("./gamesaves/game_data.json")[0];
            if (applicationRule.Split("speech:")[1].Split("~")[0] == "true" && !SpeechEnabled) { toggleSpeech(); }
            else if (applicationRule.Split("speech:")[1].Split("~")[0] == "false" && SpeechEnabled) { toggleSpeech(); }
            if (applicationRule.Split("informationPanel:")[1].Split("~")[0] == "false" && labelGameInformation.Visible) { toggleInformationPanel(); }
            else if (applicationRule.Split("informationPanel:")[1].Split("~")[0] == "true" && !labelGameInformation.Visible) { toggleInformationPanel(); toggleInformationPanel(); }
        }

        /// <summary>
        /// Event handler for if the user closes the form, calls the method to save a game if there is one in progress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void O_Neill_Game_Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            //check if there is a game in progress and prompt user to save if so
            try
            {
                if (game.GameInProgress)
                {
                    saveGame();
                }
            }
            catch (NullReferenceException) { } //this error would be thrown if there is no game object instantiated, so there is no game in progress
        }
    }
}