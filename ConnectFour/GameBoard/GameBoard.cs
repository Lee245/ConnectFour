namespace ConnectFour {
    /// <inheritdoc/>
    internal class GameBoard : IGameBoard
    {
        private readonly int[,] _gameBoardMatrix = new int[Constants.NumberOfRows, Constants.NumberOfColumns];
        private readonly IGameBoardViewer _gameBoardViewer;

        public GameBoard(IGameBoardViewer gameBoardViewer) {
            _gameBoardViewer = gameBoardViewer;
        }

        /// <inheritdoc/>
        public bool IsInWinningState(int columnLastPlayed)
        {
            columnLastPlayed = CompensateForZeroBasedIndex(columnLastPlayed);

            int stackHeightInColumn = Constants.NumberOfRows - 1;
            while (_gameBoardMatrix[stackHeightInColumn, columnLastPlayed] == 0) {
                stackHeightInColumn--;
            }

            int playerNumber = _gameBoardMatrix[stackHeightInColumn, columnLastPlayed];
            
            // Horizontal check
            int tokensInHorizontalLine = 1;
            // Check rightwards
            int col = columnLastPlayed + 1;
            while (col < Constants.NumberOfColumns - 1 && _gameBoardMatrix[stackHeightInColumn, col] == playerNumber) {
                col++;
                tokensInHorizontalLine++;
            }
            // Check leftwards
            col = columnLastPlayed - 1;
            while (col >= 0 && _gameBoardMatrix[stackHeightInColumn, col] == playerNumber) {
                col--;
                tokensInHorizontalLine++;
            }
            if (tokensInHorizontalLine >= Constants.TokensInLineForAWin) {
                return true;
            }

            // Vertical check
            int tokensInVerticalLine = 1;
            // Check upwards
            int row = stackHeightInColumn + 1;
            while (row < Constants.NumberOfRows - 1 && _gameBoardMatrix[row, columnLastPlayed] == playerNumber) {
                row++;
                tokensInVerticalLine++;
            }
            // Check downwards
            row = stackHeightInColumn - 1;
            while (row >= 0 && _gameBoardMatrix[row, columnLastPlayed] == playerNumber) {
                row--;
                tokensInVerticalLine++;
            }
            if (tokensInHorizontalLine >= Constants.TokensInLineForAWin) {
                return true;
            }

            // Upward diagonal
            int tokensUpwardDiagonalLine = 1;
            // Check to the upper-right
            row = stackHeightInColumn + 1;
            col = columnLastPlayed + 1;
            while (row < Constants.NumberOfRows - 1 && col < Constants.NumberOfColumns - 1 && _gameBoardMatrix[row, col] == playerNumber) {
                row++;
                col++;
                tokensUpwardDiagonalLine++;
            }
            // Check to the lower-left
            row = stackHeightInColumn - 1;
            col = columnLastPlayed - 1;
            while (row >= 0 && col >= 0 && _gameBoardMatrix[row, columnLastPlayed] == playerNumber) {
                row--;
                col--;
                tokensUpwardDiagonalLine++;
            }
            if (tokensUpwardDiagonalLine >= Constants.TokensInLineForAWin) {
                return true;
            }

            // Downward diagonal
            int tokensDownwardDiagonalLine = 1;
            // Check to the upper-left
            row = stackHeightInColumn + 1;
            col = columnLastPlayed - 1;
            while (row < Constants.NumberOfRows - 1 && col >= 0 && _gameBoardMatrix[row, col] == playerNumber) {
                row++;
                col--;
                tokensDownwardDiagonalLine++;
            }
            // Check to the lower-right
            row = stackHeightInColumn - 1;
            col = columnLastPlayed + 1;
            while (row >= 0 && col < Constants.NumberOfColumns - 1 && _gameBoardMatrix[row, columnLastPlayed] == playerNumber) {
                row--;
                col++;
                tokensDownwardDiagonalLine++;
            }
            if (tokensDownwardDiagonalLine >= Constants.TokensInLineForAWin) {
                return true;
            }


            return false;
        }

        /// <inheritdoc/>
        public bool PlaceToken(IPlayer player, int columnNumber)
        {
            int columnIndex = CompensateForZeroBasedIndex(columnNumber);
            bool result = false;

            for (int row = 0; row < Constants.NumberOfRows; row++) {
                if (_gameBoardMatrix[row, columnIndex] == 0) {
                    _gameBoardMatrix[row, columnIndex] = player.Number;
                    result = true;
                    break;
                }
            }

            return result;
        }

        /// <inheritdoc/>
        public void ShowGameBoard()
        {
            _gameBoardViewer.ShowGameBoard(_gameBoardMatrix);
        }

        private static int CompensateForZeroBasedIndex(int number) {
            return number - 1;
        }
    }
}