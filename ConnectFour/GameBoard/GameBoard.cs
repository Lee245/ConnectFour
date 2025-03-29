namespace ConnectFour {
    /// <inheritdoc/>
    public class GameBoard : IGameBoard
    {
        private readonly TokenType[,] _gameBoardMatrix;
        private readonly int _rowIndexUpperBound;
        private readonly int _colIndexUpperBound;

        /// <inheritdoc/>
        public int NumberOfRows => _rowIndexUpperBound + 1;

        /// <inheritdoc/>
        public int NumberOfColumns => _colIndexUpperBound + 1;

        public GameBoard(TokenType[,] gameBoardMatrix) {          
            _gameBoardMatrix = gameBoardMatrix;
            _rowIndexUpperBound = gameBoardMatrix.GetLength(0) - 1;
            _colIndexUpperBound = gameBoardMatrix.Length / gameBoardMatrix.GetLength(0) - 1;
        }

        /// <inheritdoc/>
        public int GetRowOfLastPlayedToken(int columnLastPlayed)
        {
            int colIndexLastPlayed = CompensateForZeroBasedIndex(columnLastPlayed);

            int rowIndexLastPlayed = _rowIndexUpperBound;
            while (_gameBoardMatrix[rowIndexLastPlayed, colIndexLastPlayed] == TokenType.None) {
                rowIndexLastPlayed--;
            }

            return rowIndexLastPlayed + 1;
        }

        /// <inheritdoc/>
        public TokenType GetTokenAt(int row, int column)
        {
            int zeroBasedRow = CompensateForZeroBasedIndex(row);
            int zeroBasedColumn = CompensateForZeroBasedIndex(column);
            return _gameBoardMatrix[zeroBasedRow, zeroBasedColumn];
        }

        /// <inheritdoc/>
        public void PlaceToken(TokenType tokenType, int columnNumber)
        {
            int columnIndex = CompensateForZeroBasedIndex(columnNumber);

            for (int row = 0; row <= _rowIndexUpperBound; row++) {
                if (_gameBoardMatrix[row, columnIndex] == TokenType.None) {
                    _gameBoardMatrix[row, columnIndex] = tokenType;
                    return;
                }
            }

            throw new InvalidOperationException($"Column {columnNumber} is unexpectedly full");
        }

        private static int CompensateForZeroBasedIndex(int number) {
            return number - 1;
        }
    }
}