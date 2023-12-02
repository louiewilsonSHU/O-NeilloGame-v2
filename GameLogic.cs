//game logic class

using GameboardGUI;
using System.Text.Json.Serialization;

namespace O_NeilloGame_v2
{
    public class GameLogic
    {
        private bool gameInProgress; //game in progress, default is "no"
        public bool GameInProgress { get { return this.gameInProgress; } set { this.gameInProgress = value; } }

        //declare variable to store next player to play
        private int player;
        //0 - black
        //1 - white
        public int Player { get { return this.player; } set { this.player = value; } }

        //create a game board and a 2-dimensional array to store the game data
        [JsonIgnore]
        public GameboardImageArray gameBoard;

        public int[,] gameBoardData;

        [JsonIgnore]
        //declare the readonly image path
        public readonly string imagePath;

        //declare variables to store the players' names, this is used when storing the game in the game saves file
        private string player1Name; //player 1 name, default is "Player 1"
        public string Player1Name { get { return this.player1Name; } set { this.player1Name = value; } }

        private string player2Name; //player 2 name, default is "Player 1"
        public string Player2Name { get { return this.player2Name; } set { this.player2Name = value; } }

        public GameLogic()
        {
            //assign default values to Boolean flags and other variables
            GameInProgress = true;
            Player = 0;
            gameBoardData = new int[8, 8];
            imagePath = Directory.GetCurrentDirectory() + "\\images\\";
        }

        /// <summary>
        /// Check if a move is illegal or not
        /// </summary>
        /// <param name="board">The game board array, before the move was made (i.e., without the new tile)</param>
        /// <param name="row">Row of the move</param>
        /// <param name="column">Column of the move</param>
        /// <param name="player">Current player number, 1 or 0</param>
        /// <returns>true --> illegal move, false --> legal move</returns>
        internal static bool CheckForIllegalMove(int[,] board, int row, int column, int player)
        {
            //take a note of the inverse of the current player, i.e., the player who did not make the move
            int inversePlayer = player == 1 ? 0 : 1;

            //check the 8 possibilities for any adjacent 10 tiles
            //1 - north of move
            //2 - northeast of move
            //etc

            //possibility 1
            if (!CheckForValidMovePossibility1(board, row, column, player, inversePlayer))
            {
                return false;
            }

            //possibility 2
            if (!CheckForValidMovePossibility2(board, row, column, player, inversePlayer))
            {
                return false;
            }

            //possibility 3
            if (!CheckForValidMovePossibility3(board, row, column, player, inversePlayer))
            {
                return false;
            }

            //possibility 4
            if (!CheckForValidMovePossibility4(board, row, column, player, inversePlayer))
            {
                return false;
            }

            //possibility 5
            if (!CheckForValidMovePossibility5(board, row, column, player, inversePlayer))
            {
                return false;
            }

            //possibility 6
            if (!CheckForValidMovePossibility6(board, row, column, player, inversePlayer))
            {
                return false;
            }

            //possibility 7
            if (!CheckForValidMovePossibility7(board, row, column, player, inversePlayer))
            {
                return false;
            }

            //possibility 8
            if (!CheckForValidMovePossibility8(board, row, column, player, inversePlayer))
            {
                return false;
            }

            //if none of the above conditions were met, return true
            return true;
        }

        /// <summary>
        /// Check if possibility 1 contains a valid move
        /// </summary>
        /// <param name="board">The game board array, before the move was made (i.e., without the new tile)</param>
        /// <param name="row">Row of the move</param>
        /// <param name="column">Column of the move</param>
        /// <param name="player">Current player number, 1 or 0</param>
        /// <param name="inversePlayer">Inverse of current player, 1 or 0</param>
        /// <returns>true --> illegal move, false --> legal move</returns>
        static bool CheckForValidMovePossibility1(int[,] board, int row, int column, int player, int inversePlayer)
        {
            //possibility 1
            //two variables used in the while loops to check the move
            int rowCounter = row - 1;
            int columnCounter = column;
            try
            {
                while (board[rowCounter, columnCounter] == inversePlayer)
                {
                    if (board[rowCounter - 1, columnCounter] == player)
                    {
                        return false;
                    }
                    rowCounter--;
                }
                return true;
            }
            catch (Exception) { return true; } //if the end of the board was reached, continue to next possibility
        }

        /// <summary>
        /// Check if possibility 2 contains a valid move
        /// </summary>
        /// <param name="board">The game board array, before the move was made (i.e., without the new tile)</param>
        /// <param name="row">Row of the move</param>
        /// <param name="column">Column of the move</param>
        /// <param name="player">Current player number, 1 or 0</param>
        /// <param name="inversePlayer">Inverse of current player, 1 or 0</param>
        /// <returns>true --> illegal move, false --> legal move</returns>
        static bool CheckForValidMovePossibility2(int[,] board, int row, int column, int player, int inversePlayer)
        {
            //possibility 2
            //two variables used in the while loops to check the move
            int rowCounter = row - 1;
            int columnCounter = column + 1;
            try
            {
                while (board[rowCounter, columnCounter] == inversePlayer)
                {
                    if (board[rowCounter - 1, columnCounter + 1] == player)
                    {
                        return false;
                    }
                    rowCounter--;
                    columnCounter++;
                }
                return true;
            }
            catch (Exception) { return true; } //if the end of the board was reached, continue
        }

        /// <summary>
        /// Check if possibility 3 contains a valid move
        /// </summary>
        /// <param name="board">The game board array, before the move was made (i.e., without the new tile)</param>
        /// <param name="row">Row of the move</param>
        /// <param name="column">Column of the move</param>
        /// <param name="player">Current player number, 1 or 0</param>
        /// <param name="inversePlayer">Inverse of current player, 1 or 0</param>
        /// <returns>true --> illegal move, false --> legal move</returns>
        static bool CheckForValidMovePossibility3(int[,] board, int row, int column, int player, int inversePlayer)
        {
            //possibility 3
            //two variables used in the while loops to check the move
            int rowCounter = row;
            int columnCounter = column + 1;
            try
            {
                while (board[rowCounter, columnCounter] == inversePlayer)
                {
                    if (board[rowCounter, columnCounter + 1] == player)
                    {
                        return false;
                    }
                    columnCounter++;
                }
                return true;
            }
            catch (Exception) { return true; } //if the end of the board was reached, continue
        }

        /// <summary>
        /// Check if possibility 4 contains a valid move
        /// </summary>
        /// <param name="board">The game board array, before the move was made (i.e., without the new tile)</param>
        /// <param name="row">Row of the move</param>
        /// <param name="column">Column of the move</param>
        /// <param name="player">Current player number, 1 or 0</param>
        /// <param name="inversePlayer">Inverse of current player, 1 or 0</param>
        /// <returns>true --> illegal move, false --> legal move</returns>
        static bool CheckForValidMovePossibility4(int[,] board, int row, int column, int player, int inversePlayer)
        {
            //possibility 4
            //two variables used in the while loops to check the move
            int rowCounter = row + 1;
            int columnCounter = column + 1;
            try
            {
                while (board[rowCounter, columnCounter] == inversePlayer)
                {
                    if (board[rowCounter + 1, columnCounter + 1] == player)
                    {
                        return false;
                    }
                    rowCounter++;
                    columnCounter++;
                }
                return true;
            }
            catch (Exception) { return true; } //if the end of the board was reached, continue
        }

        /// <summary>
        /// Check if possibility 5 contains a valid move
        /// </summary>
        /// <param name="board">The game board array, before the move was made (i.e., without the new tile)</param>
        /// <param name="row">Row of the move</param>
        /// <param name="column">Column of the move</param>
        /// <param name="player">Current player number, 1 or 0</param>
        /// <param name="inversePlayer">Inverse of current player, 1 or 0</param>
        /// <returns>true --> illegal move, false --> legal move</returns>
        static bool CheckForValidMovePossibility5(int[,] board, int row, int column, int player, int inversePlayer)
        {
            //possibility 5
            //two variables used in the while loops to check the move
            int rowCounter = row + 1;
            int columnCounter = column;
            try
            {
                while (board[rowCounter, columnCounter] == inversePlayer)
                {
                    if (board[rowCounter + 1, columnCounter] == player)
                    {
                        return false;
                    }
                    rowCounter++;
                }
                return true;
            }
            catch (Exception) { return true; } //if the end of the board was reached, continue
        }

        /// <summary>
        /// Check if possibility 6 contains a valid move
        /// </summary>
        /// <param name="board">The game board array, before the move was made (i.e., without the new tile)</param>
        /// <param name="row">Row of the move</param>
        /// <param name="column">Column of the move</param>
        /// <param name="player">Current player number, 1 or 0</param>
        /// <param name="inversePlayer">Inverse of current player, 1 or 0</param>
        /// <returns>true --> illegal move, false --> legal move</returns>
        static bool CheckForValidMovePossibility6(int[,] board, int row, int column, int player, int inversePlayer)
        {
            //possibility 6
            //two variables used in the while loops to check the move
            int rowCounter = row + 1;
            int columnCounter = column - 1;
            try
            {
                while (board[rowCounter, columnCounter] == inversePlayer)
                {
                    if (board[rowCounter + 1, columnCounter - 1] == player)
                    {
                        return false;
                    }
                    rowCounter++;
                    columnCounter--;
                }
                return true;
            }
            catch (Exception) { return true; } //if the end of the board was reached, continue
        }

        /// <summary>
        /// Check if possibility 7 contains a valid move
        /// </summary>
        /// <param name="board">The game board array, before the move was made (i.e., without the new tile)</param>
        /// <param name="row">Row of the move</param>
        /// <param name="column">Column of the move</param>
        /// <param name="player">Current player number, 1 or 0</param>
        /// <param name="inversePlayer">Inverse of current player, 1 or 0</param>
        /// <returns>true --> illegal move, false --> legal move</returns>
        static bool CheckForValidMovePossibility7(int[,] board, int row, int column, int player, int inversePlayer)
        {
            //possibility 7
            //two variables used in the while loops to check the move
            int rowCounter = row;
            int columnCounter = column - 1;
            try
            {
                while (board[rowCounter, columnCounter] != 10 && board[row, column - 1] == inversePlayer)
                {
                    if (board[rowCounter, columnCounter - 1] == player)
                    {
                        return false;
                    }
                    columnCounter--;
                }
                return true;
            }
            catch (Exception) { return true; } //if the end of the board was reached, continue
        }

        /// <summary>
        /// Check if possibility 8 contains a valid move
        /// </summary>
        /// <param name="board">The game board array, before the move was made (i.e., without the new tile)</param>
        /// <param name="row">Row of the move</param>
        /// <param name="column">Column of the move</param>
        /// <param name="player">Current player number, 1 or 0</param>
        /// <param name="inversePlayer">Inverse of current player, 1 or 0</param>
        /// <returns>true --> illegal move, false --> legal move</returns>
        static bool CheckForValidMovePossibility8(int[,] board, int row, int column, int player, int inversePlayer)
        {
            //possibility 8
            //two variables used in the while loops to check the move
            int rowCounter = row - 1;
            int columnCounter = column - 1;
            try
            {
                while (board[rowCounter, columnCounter] != 10 && board[row - 1, column - 1] == inversePlayer)
                {
                    if (board[rowCounter - 1, columnCounter - 1] == player)
                    {
                        return false;
                    }
                    rowCounter--;
                    columnCounter--;
                }
                return true;
            }
            catch (Exception) { return true; } //if the end of the board was reached, continue
        }

        /// <summary>
        /// Checks if there are any tiles to flip, based on a move
        /// </summary>
        /// <param name="board">The game board array, before the move was made (i.e., without the new tile)</param>
        /// <param name="row">Row of the move</param>
        /// <param name="column">Column of the move</param>
        /// <param name="player">Current player number, 1 or 0</param>
        /// <returns>A 2-dimensional list of board tiles to change to the player's tile colour</returns>
        internal static List<List<int>> ProcessMove(int[,] board, int row, int column, int player)
        {
            //run through each of the eight possibilities and flip any relevant tiles (numbered the same as above)

            //declare an empty 2-dimensional array; each tile that requires changing to the player's colour will be added to this
            List<List<int>> tilesToChange = new List<List<int>>();

            //take a note of the inverse of the current player, i.e., the player who did not make the move
            int inversePlayer = player == 1 ? 0 : 1;

            //two variables used in the while loops to check the move
            int rowCounter;
            int columnCounter;

            //possibility 1
            rowCounter = row - 1;
            columnCounter = column;
            try
            {
                while (board[rowCounter, columnCounter] == inversePlayer)
                {
                    if (board[rowCounter - 1, columnCounter] == player)
                    {
                        do { tilesToChange.Add(new List<int>() { rowCounter, columnCounter }); rowCounter++; }
                        while (rowCounter != row);
                        break;
                    }
                    rowCounter--;
                }
            }
            catch (Exception) { } //if the end of the board was reached, continue

            //possibility 2
            rowCounter = row - 1;
            columnCounter = column + 1;
            try
            {
                while (board[rowCounter, columnCounter] == inversePlayer)
                {
                    if (board[rowCounter - 1, columnCounter + 1] == player)
                    {
                        do { tilesToChange.Add(new List<int>() { rowCounter, columnCounter }); rowCounter++; columnCounter--; }
                        while (rowCounter != row);
                        break;
                    }
                    rowCounter--;
                    columnCounter++;
                }
            }
            catch (Exception) { } //if the end of the board was reached, continue

            //possibility 3
            rowCounter = row;
            columnCounter = column + 1;
            try
            {
                while (board[rowCounter, columnCounter] == inversePlayer)
                {
                    if (board[rowCounter, columnCounter + 1] == player)
                    {
                        do { tilesToChange.Add(new List<int>() { rowCounter, columnCounter }); columnCounter--; }
                        while (columnCounter != column);
                        break;
                    }
                    columnCounter++;
                }
            }
            catch (Exception) { } //if the end of the board was reached, continue

            //possibility 4
            rowCounter = row + 1;
            columnCounter = column + 1;
            try
            {
                while (board[rowCounter, columnCounter] == inversePlayer)
                {
                    if (board[rowCounter + 1, columnCounter + 1] == player)
                    {
                        do { tilesToChange.Add(new List<int>() { rowCounter, columnCounter }); rowCounter--; columnCounter--; }
                        while (rowCounter != row);
                        break;
                    }
                    rowCounter++;
                    columnCounter++;
                }
            }
            catch (Exception) { } //if the end of the board was reached, continue

            //possibility 5
            rowCounter = row + 1;
            columnCounter = column;
            try
            {
                while (board[rowCounter, columnCounter] == inversePlayer)
                {
                    if (board[rowCounter + 1, columnCounter] == player)
                    {
                        do { tilesToChange.Add(new List<int>() { rowCounter, columnCounter }); rowCounter--; }
                        while (rowCounter != row);
                        break;
                    }
                    rowCounter++;
                }
            }
            catch (Exception) { } //if the end of the board was reached, continue

            //possibility 6
            rowCounter = row + 1;
            columnCounter = column - 1;
            try
            {
                while (board[rowCounter, columnCounter] == inversePlayer)
                {
                    if (board[rowCounter + 1, columnCounter - 1] == player)
                    {
                        do { tilesToChange.Add(new List<int>() { rowCounter, columnCounter }); rowCounter--; columnCounter++; }
                        while (rowCounter != row);
                        break;
                    }
                    rowCounter++;
                    columnCounter--;
                }
            }
            catch (Exception) { } //if the end of the board was reached, continue

            //possibility 7
            rowCounter = row;
            columnCounter = column - 1;
            try
            {
                while (board[rowCounter, columnCounter] == inversePlayer)
                {
                    if (board[rowCounter, columnCounter - 1] == player)
                    {
                        do { tilesToChange.Add(new List<int>() { rowCounter, columnCounter }); columnCounter++; }
                        while (columnCounter != column);
                        break;
                    }
                    columnCounter--;
                }
            }
            catch (Exception) { } //if the end of the board was reached, continue

            //possibility 8
            rowCounter = row - 1;
            columnCounter = column - 1;
            try
            {
                while (board[rowCounter, columnCounter] == inversePlayer)
                {
                    if (board[rowCounter - 1, columnCounter - 1] == player)
                    {
                        do { tilesToChange.Add(new List<int>() { rowCounter, columnCounter }); rowCounter++; columnCounter++; }
                        while (rowCounter != row);
                        break;
                    }
                    rowCounter--;
                    columnCounter--;
                }
            }
            catch (Exception) { } //if the end of the board was reached, continue

            return tilesToChange;
        }

        /// <summary>
        /// Evaluates if the current player has any valid moves available
        /// </summary>
        /// <param name="gameBoardData">Game board array</param>
        /// <param name="player">Current player number</param>
        /// <returns>Boolean value, corresponding with if the player has any valid moves available</returns>
        internal static bool CheckForValidMove(int[,] gameBoardData, int player)
        {
            //run through each tile on the board, and only process "10" tiles
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    if (gameBoardData[row, column] == 10)
                    {
                        //assume that the player goes here, check if this would be a legal move
                        //(no actual move is made here, just re-using the illegal move checking method code)
                        if (!CheckForIllegalMove(gameBoardData, row, column, player))
                        {
                            //if any of the potential moves made are legal, then the player has a valid move
                            return true;
                        }
                    }
                }
            }
            //if no valid moves were found
            return false;
        }

        /// <summary>
        /// Outputs a relevant message, based on the game outcome
        /// </summary>
        /// <param name="player1NumberOfTokens">Player 1 number of tokens</param>
        /// <param name="player2NumberOfTokens">Player 2 number of tokens</param>
        internal void GameOver(int player1NumberOfTokens, int player2NumberOfTokens)
        {
            //set gameInProgress to false
            gameInProgress = false;

            //Process token counts and output relevant message
            MessageBox.Show($"{(player1NumberOfTokens > player2NumberOfTokens ? "Player 1 wins!" : (player1NumberOfTokens == player2NumberOfTokens ? "Draw!" : "Player 2 wins!"))}");
        }
    }
}