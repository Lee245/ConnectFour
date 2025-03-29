namespace ConnectFour {
    
    /// <summary>
    /// Human player
    /// </summary>
    public class HumanPlayer : IPlayer
    {
        /// <inheritdoc/>
        public string Name => "Human";

        /// <inheritdoc/>
        public TokenType TokenType => TokenType.Yellow;

        /// <inheritdoc/>
        public int GetNextMove(int numberOfColumns)
        {
            // TODO: Wrap console in a new 'Input' class to account for other ways to get user input
            Console.WriteLine($"Please select the column number for dropping your token (1-{numberOfColumns})");
            var userInput = Console.ReadLine();
            int columnNumberInput;
            while (!int.TryParse(userInput, out columnNumberInput) || columnNumberInput < 1 || columnNumberInput > numberOfColumns) {
                Console.WriteLine($"Please select a number from 1 to {numberOfColumns}");
                userInput = Console.ReadLine();
            }

            return columnNumberInput;
        }
    }
}