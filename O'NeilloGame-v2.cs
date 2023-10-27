using GameboardGUI;

namespace O_NeilloGame_v2
{
    public partial class O_Neill_Game_Window : Form
    {
        //global variables used in the game
        GameboardImageArray gameBoard;
        int[,] gameBoardData = new int[8, 8];
        string imagePath = Directory.GetCurrentDirectory() + "\\images\\";

        public O_Neill_Game_Window()
        {
            InitializeComponent();

            Point top = new(5, 5);
            Point bottom = new(253, 5);

            MakeBoardArray();

            gameBoard = new GameboardImageArray(this, gameBoardData, top, bottom, 1, imagePath);
            gameBoard.TileClicked += new GameboardImageArray.TileClickedEventDelegate(GameTileClicked);
        }

        private void GameTileClicked(object sender, EventArgs e)
        {
            int row = gameBoard.GetCurrentRowIndex(sender);
            int column = gameBoard.GetCurrentColumnIndex(sender);
            gameBoardData[row, column] = 1;
            gameBoard.UpdateBoardGui(gameBoardData);
        }

        //initialise board array - set all cells to blank, then add starter colours
        private void MakeBoardArray()
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    gameBoardData[r, c] = 10;
                }
            }
            gameBoardData[3, 3] = 0;
            gameBoardData[4, 4] = 0;
            gameBoardData[4, 3] = 1;
            gameBoardData[3, 4] = 1;
        }
    }
}