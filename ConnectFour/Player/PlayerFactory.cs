namespace ConnectFour {
    
    /// <summary>
    /// Factory for creating <see cref="IPlayer"/>s
    /// </summary>
    internal class PlayerFactory {
        /// <summary>
        /// Create player of type
        /// </summary>
        /// <param name="playerType">The player type</param>
        /// <returns>A <see cref="IPlayer"/></returns>
        /// <exception cref="ArgumentException">If player type is not recognized.</exception>
        public IPlayer CreatePlayer(PlayerType playerType) {
            switch (playerType) {
                case PlayerType.Human:
                    return new HumanPlayer();
                case PlayerType.RandomComputer:
                    return new RandomComputerPlayer();
                default:
                    throw new ArgumentException($"Player type {playerType} not recognized");
            }
        }
    }
}