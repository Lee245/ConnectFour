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
        public bool PlaceToken(int playerNumber, int columnNumber)
        {
            int columnIndex = CompensateForZeroBasedIndex(columnNumber);
            bool result = false;

            for (int row = 0; row <= _rowIndexUpperBound; row++) {
                if (_gameBoardMatrix[row, columnIndex] == 0) {
                    _gameBoardMatrix[row, columnIndex] = playerNumber;
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
            int colIndexLastPlayed = CompensateForZeroBasedIndex(columnLastPlayed);

            int rowIndexLastPlayed = _rowIndexUpperBound;
            while (_gameBoardMatrix[rowIndexLastPlayed, colIndexLastPlayed] == 0) {
                rowIndexLastPlayed--;
            }

            int playerNumber = _gameBoardMatrix[rowIndexLastPlayed, colIndexLastPlayed];
            
            // Horizontal check
            int tokensInHorizontalLine = 1;
            // Check rightwards of last placed token
            int col = colIndexLastPlayed + 1;
            while (col <= _colIndexUpperBound && _gameBoardMatrix[rowIndexLastPlayed, col] == playerNumber) {
                col++;
                tokensInHorizontalLine++;
            }
            // Check leftwards of last placed token
            col = colIndexLastPlayed - 1;
            while (col >= 0 && _gameBoardMatrix[rowIndexLastPlayed, col] == playerNumber) {
                col--;
                tokensInHorizontalLine++;
            }
            if (tokensInHorizontalLine >= _tokensInLineForAWin) {
                return true;
            }

            // Vertical check
            int tokensInVerticalLine = 1;
            // Check upwards of last placed token
            int row = rowIndexLastPlayed + 1;
            while (row <= _rowIndexUpperBound && _gameBoardMatrix[row, colIndexLastPlayed] == playerNumber) {
                row++;
                tokensInVerticalLine++;
            }
            // Check downwards of last placed token
            row = rowIndexLastPlayed - 1;
            while (row >= 0 && _gameBoardMatrix[row, colIndexLastPlayed] == playerNumber) {
                row--;
                tokensInVerticalLine++;
            }
            if (tokensInVerticalLine >= _tokensInLineForAWin) {
                return true;
            }

            // Upward diagonal
            int tokensUpwardDiagonalLine = 1;
            // Check to the upper-right of last placed token
            row = rowIndexLastPlayed + 1;
            col = colIndexLastPlayed + 1;
            while (row <= _rowIndexUpperBound && col <= _colIndexUpperBound && _gameBoardMatrix[row, col] == playerNumber) {
                row++;
                col++;
                tokensUpwardDiagonalLine++;
            }
            // Check to the lower-left of last placed token
            row = rowIndexLastPlayed - 1;
            col = colIndexLastPlayed - 1;
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
            // Check to the upper-left of last placed token
            row = rowIndexLastPlayed + 1;
            col = colIndexLastPlayed - 1;
            while (row <= _rowIndexUpperBound && col >= 0 && _gameBoardMatrix[row, col] == playerNumber) {
                row++;
                col--;
                tokensDownwardDiagonalLine++;
            }
            // Check to the lower-right of last placed token
            row = rowIndexLastPlayed - 1;
            col = colIndexLastPlayed + 1;
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