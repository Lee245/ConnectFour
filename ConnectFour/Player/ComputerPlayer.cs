namespace ConnectFour {
    /// <inheritdoc/>
    public class ComputerPlayer : IPlayer
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