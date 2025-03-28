namespace ConnectFour {
    /// <summary>
    /// Interface for all game board logic
    /// </summary>
    public interface IGameBoard {
        /// <summary>
        /// Place token on board
        /// </summary>
        /// <param name="playerNumber">The player number</param>
        /// <param name="columnNumber">The column number to pick</param>
        /// <returns>True if successful, false if column is full.</returns>
        bool PlaceToken(int playerNumber, int columnNumber);

        /// <summary>
        /// Check if the board is in winning state
        /// </summary>
        /// <param name="columnLastPlayed">Index of column last played</param>
        /// <returns></returns>
        bool IsInWinningState(int columnLastPlayed);

        /// <summary>
        /// Show the game board
        /// </summary>
        void ShowGameBoard();
    }
}