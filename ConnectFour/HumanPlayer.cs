namespace ConnectFour {
    internal class HumanPlayer : IPlayer
    {
        public string Name => "Human";

        public int Number => 1;

        public int GetNextMove()
        {
            Console.WriteLine("Please select the column number for dropping your token (1-7)");
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