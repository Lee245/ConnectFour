namespace ConnectFour {
    public interface IPlayer {
        string Name { get; }
        int Number { get; }

        /// <summary>
        /// Get player's next move
        /// </summary>
        /// <returns>Column number for next token</returns>
        int GetNextMove();
    }
}