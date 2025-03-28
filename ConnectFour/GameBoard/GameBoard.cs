namespace ConnectFour {
    internal class GameBoard : IGameBoard
    {
        private readonly int[,] _gameBoardMatrix = new int[Constants.NumberOfRows, Constants.NumberOfColumns];
        private readonly IGameBoardViewer _gameBoardViewer;

        public GameBoard(IGameBoardViewer gameBoardViewer) {
            _gameBoardViewer = gameBoardViewer;
        }

        public bool IsInWinningState(int columnLastPlayed)
        {
            int stackHeightInColumn = Constants.NumberOfRows - 1;
            while (_gameBoardMatrix[stackHeightInColumn, columnLastPlayed] == 0) {
                stackHeightInColumn--;
            }

            // TODO: Implement horizontal, vertical and diagonal checks.
            int playerNumber = _gameBoardMatrix[stackHeightInColumn, columnLastPlayed];

            return false;
        }

        public bool PlaceToken(IPlayer player, int columnNumber)
        {
            columnNumber--;
            bool result = false;

            for (int row = 0; row < Constants.NumberOfRows; row++) {
                if (_gameBoardMatrix[row, columnNumber] == 0) {
                    _gameBoardMatrix[row, columnNumber] = player.Number;
                    result = true;
                    break;
                }
            }

            return result;
        }

        public void ShowGameBoard()
        {
            // Print from top to bottom
            for (int row = Constants.NumberOfRows - 1; row >=0; row++) {
                Console.Write("| ");
                for (int col = 0; col < Constants.NumberOfColumns; col++) {
                    Console.Write(_gameBoardMatrix[row,col]);
                    Console.Write(" | ");
                }
                Console.WriteLine();
                Console.WriteLine("-----------------------------");
            }
        }
    }
}