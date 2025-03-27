namespace ConnectFour {
    internal class ComputerPlayer : IPlayer
    {
        private readonly Random _randomNumberGenerator = new Random();

        public string Name => "Computer";

        public int Number => 2;

        public int GetNextMove()
        {
            return _randomNumberGenerator.Next(0, Constants.NumberOfColumns - 1);
        }
    }
}