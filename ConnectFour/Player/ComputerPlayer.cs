namespace ConnectFour {
    
    /// <summary>
    /// Computer player playing random moves
    /// </summary>
    public class RandomComputerPlayer : Player
    {
        private readonly Random _randomNumberGenerator = new Random();

        public RandomComputerPlayer(int numberOfColumns)
            : base(numberOfColumns) {}

        /// <inheritdoc/>
        public override string Name => "RandomComputer";

        /// <inheritdoc/>
        public override int Number => 2;

        /// <inheritdoc/>
        public override int GetNextMove()
        {
            return _randomNumberGenerator.Next(1, _numberOfColumns);
        }
    }
}