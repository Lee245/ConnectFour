namespace ConnectFour {
    
    /// <summary>
    /// Computer player playing random moves
    /// </summary>
    public class RandomComputerPlayer : IPlayer
    {
        private readonly Random _randomNumberGenerator = new Random();

        /// <inheritdoc/>
        public string Name => "RandomComputer";

        /// <inheritdoc/>
        public TokenType TokenType => TokenType.Red;

        /// <inheritdoc/>
        public int GetNextMove(int numberOfColumns)
        {
            return _randomNumberGenerator.Next(1, numberOfColumns);
        }
    }
}