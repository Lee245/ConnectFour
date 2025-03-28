namespace ConnectFour {
    
    /// <summary>
    /// Computer player playing random moves
    /// </summary>
    public class RandomComputerPlayer : IPlayer
    {
        private readonly Random _randomNumberGenerator = new Random();

        /// <inheritdoc/>
        public string Name => "Computer";

        /// <inheritdoc/>
        public int Number => 2;

        /// <inheritdoc/>
        public int GetNextMove()
        {
            return _randomNumberGenerator.Next(1, Constants.NumberOfColumns);
        }
    }
}