namespace ConnectFour {
    
    /// <summary>
    /// Human player
    /// </summary>
    internal class HumanPlayer : IPlayer
    {
        private readonly int _numberOfColumns;

        public HumanPlayer(int numberOfColumns) {
            _numberOfColumns = numberOfColumns;
        }

        public string Name => "Human";

        public int Number => 1;

        public int GetNextMove()
        {
            // TODO: Wrap console in a new 'Input' class to account for other ways to get user input
            Console.WriteLine($"Please select the column number for dropping your token (1-{_numberOfColumns})");
            var userInput = Console.ReadLine();
            int columnNumberInput;
            while (!int.TryParse(userInput, out columnNumberInput) || columnNumberInput < 1 || columnNumberInput > _numberOfColumns) {
                Console.WriteLine($"Please select a number from 1 to {_numberOfColumns}");
                userInput = Console.ReadLine();
            }

            return columnNumberInput;
        }
    }
}