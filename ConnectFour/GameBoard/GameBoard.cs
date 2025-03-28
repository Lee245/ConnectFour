using System.Runtime.CompilerServices;

namespace ConnectFour {
    /// <inheritdoc/>
    public class GameBoard : IGameBoard
    {
        private readonly int[,] _gameBoardMatrix;
        private readonly IGameBoardViewer _gameBoardViewer;
        private readonly int _rowIndexUpperBound;
        private readonly int _colIndexUpperBound;
        private readonly int _tokensInLineForAWin;

        public GameBoard(IGameBoardViewer gameBoardViewer, int[,] gameBoardMatrix, int tokensInLineForAWin) {          
            _gameBoardViewer = gameBoardViewer;
            _gameBoardMatrix = gameBoardMatrix;
            _rowIndexUpperBound = gameBoardMatrix.GetLength(0) - 1;
            _colIndexUpperBound = gameBoardMatrix.Length / gameBoardMatrix.GetLength(0) - 1;
            _tokensInLineForAWin = tokensInLineForAWin;
        }

        /// <inheritdoc/>
        public bool PlaceToken(IPlayer player, int columnNumber)
        {
            int columnIndex = CompensateForZeroBasedIndex(columnNumber);
            bool result = false;

            for (int row = 0; row <= _rowIndexUpperBound; row++) {
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
            _gameBoardViewer.ShowGameBoard(_gameBoardMatrix, _rowIndexUpperBound, _colIndexUpperBound);
        }

        /// <inheritdoc/>
        public bool IsInWinningState(int columnLastPlayed)
        {
            columnLastPlayed = CompensateForZeroBasedIndex(columnLastPlayed);

            int stackHeightInColumn = _rowIndexUpperBound;
            while (_gameBoardMatrix[stackHeightInColumn, columnLastPlayed] == 0) {
                stackHeightInColumn--;
            }

            int playerNumber = _gameBoardMatrix[stackHeightInColumn, columnLastPlayed];
            
            // Horizontal check
            int tokensInHorizontalLine = 1;
            // Check rightwards
            int col = columnLastPlayed + 1;
            while (col <= _colIndexUpperBound && _gameBoardMatrix[stackHeightInColumn, col] == playerNumber) {
                col++;
                tokensInHorizontalLine++;
            }
            // Check leftwards
            col = columnLastPlayed - 1;
            while (col >= 0 && _gameBoardMatrix[stackHeightInColumn, col] == playerNumber) {
                col--;
                tokensInHorizontalLine++;
            }
            if (tokensInHorizontalLine >= _tokensInLineForAWin) {
                return true;
            }

            // Vertical check
            int tokensInVerticalLine = 1;
            // Check upwards
            int row = stackHeightInColumn + 1;
            while (row <= _rowIndexUpperBound && _gameBoardMatrix[row, columnLastPlayed] == playerNumber) {
                row++;
                tokensInVerticalLine++;
            }
            // Check downwards
            row = stackHeightInColumn - 1;
            while (row >= 0 && _gameBoardMatrix[row, columnLastPlayed] == playerNumber) {
                row--;
                tokensInVerticalLine++;
            }
            if (tokensInVerticalLine >= _tokensInLineForAWin) {
                return true;
            }

            // Upward diagonal
            int tokensUpwardDiagonalLine = 1;
            // Check to the upper-right
            row = stackHeightInColumn + 1;
            col = columnLastPlayed + 1;
            while (row <= _rowIndexUpperBound && col <= _colIndexUpperBound && _gameBoardMatrix[row, col] == playerNumber) {
                row++;
                col++;
                tokensUpwardDiagonalLine++;
            }
            // Check to the lower-left
            row = stackHeightInColumn - 1;
            col = columnLastPlayed - 1;
            while (row >= 0 && col >= 0 && _gameBoardMatrix[row, col] == playerNumber) {
                row--;
                col--;
                tokensUpwardDiagonalLine++;
            }
            if (tokensUpwardDiagonalLine >= _tokensInLineForAWin) {
                return true;
            }

            // Downward diagonal
            int tokensDownwardDiagonalLine = 1;
            // Check to the upper-left
            row = stackHeightInColumn + 1;
            col = columnLastPlayed - 1;
            while (row <= _rowIndexUpperBound && col >= 0 && _gameBoardMatrix[row, col] == playerNumber) {
                row++;
                col--;
                tokensDownwardDiagonalLine++;
            }
            // Check to the lower-right
            row = stackHeightInColumn - 1;
            col = columnLastPlayed + 1;
            while (row >= 0 && col <= _colIndexUpperBound && _gameBoardMatrix[row, col] == playerNumber) {
                row--;
                col++;
                tokensDownwardDiagonalLine++;
            }
            if (tokensDownwardDiagonalLine >= _tokensInLineForAWin) {
                return true;
            }


            return false;
        }

        private static int CompensateForZeroBasedIndex(int number) {
            return number - 1;
        }
    }
}