namespace ConnectFour {
    
    /// <summary>
    /// Human player
    /// </summary>
    internal class HumanPlayer : IPlayer
    {
        public string Name => "Human";

        public int Number => 1;

        public int GetNextMove()
        {
            Console.WriteLine($"Please select the column number for dropping your token (1-{Constants.NumberOfColumns})");
            var userInput = Console.ReadLine();
            int columnNumberInput;
            while (!int.TryParse(userInput, out columnNumberInput)) {
                Console.WriteLine($"Please select a number from 1 to {Constants.NumberOfColumns}");
                userInput = Console.ReadLine();
            }

            return columnNumberInput;
        }
    }
}