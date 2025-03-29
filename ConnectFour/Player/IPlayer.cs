namespace ConnectFour {
    /// <summary>
    /// Interface for player
    /// </summary>
    public interface IPlayer {
        /// <summary>
        /// Name of the player
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Token of the player
        /// </summary>
        TokenType TokenType { get; }

        /// <summary>
        /// Get player's next move
        /// </summary>
        /// <param name="numberOfColumns">Number of columns</param>
        /// <returns>Column number for next token</returns>
        int GetNextMove(int numberOfColumns);
    }
}