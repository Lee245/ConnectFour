namespace ConnectFour {
    
    /// <summary>
    /// Human player
    /// </summary>
    public class HumanPlayer : Player
    {
        public HumanPlayer(int numberOfColumns) 
            : base(numberOfColumns) {}

        public override string Name => "Human";

        public override TokenType TokenType => TokenType.Yellow;

        public override int GetNextMove()
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