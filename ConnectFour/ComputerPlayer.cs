namespace ConnectFour {
    internal class ComputerPlayer : IPlayer
    {
        public string Name => "Computer";

        public int Number => 2;

        public int GetNextMove()
        {
            throw new NotImplementedException();
        }
    }
}