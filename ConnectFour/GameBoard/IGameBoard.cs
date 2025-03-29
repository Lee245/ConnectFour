namespace ConnectFour {
    /// <summary>
    /// Interface for all game board logic
    /// </summary>
    public interface IGameBoard {
        /// <summary>
        /// The number of rows of the board
        /// </summary>
        public int NumberOfRows {get;}

        /// <summary>
        /// The number of columns of the board
        /// </summary>
        public int NumberOfColumns {get;}

        /// <summary>
        /// Get row index of the last placed token
        /// </summary>
        /// <param name="columnLastPlayed">The 1-based column index in which the token was placed</param>
        /// <returns>The 1-based index of the row</returns>
        int GetRowOfLastPlayedToken(int columnLastPlayed);

        /// <summary>
        /// Get token at a specific position
        /// </summary>
        /// <param name="row">1-based row index</param>
        /// <param name="column">1-based column index</param>
        /// <returns></returns>
        TokenType GetTokenAt(int row, int column);

        /// <summary>
        /// Place token on board
        /// </summary>
        /// <param name="tokenType">Token type</param>
        /// <param name="columnNumber">The 1-based column number to pick</param>
        /// <returns>True if successful, false if column is full.</returns>
        bool PlaceToken(TokenType tokenType, int columnNumber);
    }
}