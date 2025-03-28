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
        /// Number of the player
        /// </summary>
        int Number { get; }

        /// <summary>
        /// Get player's next move
        /// </summary>
        /// <returns>Column number for next token</returns>
        int GetNextMove();
    }
}