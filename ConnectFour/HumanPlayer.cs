namespace ConnectFour {
    internal class HumanPlayer : IPlayer
    {
        public string Name => "Human";

        public int Number => 1;

        public int GetNextMove()
        {
            throw new NotImplementedException();
        }
    }
}