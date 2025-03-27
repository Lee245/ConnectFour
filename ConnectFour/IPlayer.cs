namespace ConnectFour {
    public interface IPlayer {
        /// <summary>
        /// Get player's next move
        /// </summary>
        /// <returns>Column number for next token</returns>
        int GetNextMove();
    }
}