namespace ConnectFour {
    /// <summary>
    /// Class for running the actual m,n,k-game
    /// </summary>
    internal class GameEngine { 
        private readonly IList<IPlayer> _players;
        private readonly IGameBoard _gameBoard;
        
        public GameEngine(IList<IPlayer> players, IGameBoard gameBoard) {
            _players = players;
            _gameBoard = gameBoard;
        }

        public void Run() {
            int[,] gameBoard = new int[Constants.NumberOfRows, Constants.NumberOfColumns];
            PrintGameBoard(gameBoard);
        
            Random randomNumberGenerator = new Random();

            int turnNumber = 0;
            bool winningState = false;
            while (!winningState) {

                int playerNumber = (turnNumber % 2) + 1;
                int columnNumberInput;
                if (playerNumber == 1) {
                    Console.WriteLine("Please select the column number for dropping your token (1-7)");
                    var userInput = Console.ReadLine();
                    if (!int.TryParse(userInput, out columnNumberInput)) {
                        throw new ArgumentException($"Please select a number from 1 to {Constants.NumberOfColumns}");
                    }
                }
                else {
                    columnNumberInput = randomNumberGenerator.Next(0, Constants.NumberOfColumns);
                    Console.WriteLine($"Computer played column {columnNumberInput}");
                }
                            
                while (!PlaceToken(gameBoard, columnNumberInput, playerNumber)) {
                    Console.WriteLine($"Column {columnNumberInput} is full, please select a different column");
                    Console.WriteLine("Please select the column number for dropping your token (1-7)");
                    var userInput = Console.ReadLine();
                    if (!int.TryParse(userInput, out columnNumberInput)) {
                        throw new ArgumentException($"Please select a number from 1 to {Constants.NumberOfColumns}");
                    }
                }
                PrintGameBoard(gameBoard);

                winningState = CheckIfInWinningState();

                turnNumber++;
            }
        }

        public bool PlaceToken(int[,] gameBoard, int columnNumber, int playerNumber) {
            columnNumber--;
            bool result = false;

            for (int row = Constants.NumberOfRows - 1; row >= 0; row--) {
                if (gameBoard[row, columnNumber] == 0) {
                    gameBoard[row, columnNumber] = playerNumber;
                    result = true;
                    break;
                }
            }

            return result;
        }

        public void PrintGameBoard(int[,] gameBoard) {
            for (int row = 0; row < Constants.NumberOfRows; row++) {
                Console.Write("| ");
                for (int col = 0; col < Constants.NumberOfColumns; col++) {
                    Console.Write(gameBoard[row,col]);
                    Console.Write(" | ");
                }
                Console.WriteLine();
                Console.WriteLine("-----------------------------");
            }
        }

        public bool CheckIfInWinningState() {
            return false;
        }

        private IPlayer WhosTurnIsIt(int turnNumber) {
            int playerIndex = turnNumber % 2;
            return _players[playerIndex];
        }
    }
}