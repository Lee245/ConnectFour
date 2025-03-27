namespace ConnectFour {
    public class Program {

        private const int RowCount = 6;
        private const int ColCount = 7;

        public static void Main(string[] args) {
            int[,] gameBoard = new int[RowCount, ColCount];
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
                        throw new ArgumentException($"Please select a number from 1 to {ColCount}");
                    }
                }
                else {
                    columnNumberInput = randomNumberGenerator.Next(0, ColCount);
                    Console.WriteLine($"Computer played column {columnNumberInput}");
                }
                            
                while (!PlaceToken(gameBoard, columnNumberInput, playerNumber)) {
                    Console.WriteLine($"Column {columnNumberInput} is full, please select a different column");
                    Console.WriteLine("Please select the column number for dropping your token (1-7)");
                    var userInput = Console.ReadLine();
                    if (!int.TryParse(userInput, out columnNumberInput)) {
                        throw new ArgumentException($"Please select a number from 1 to {ColCount}");
                    }
                }
                PrintGameBoard(gameBoard);

                winningState = CheckIfInWinningState();

                turnNumber++;
            }
        }

        public static bool PlaceToken(int[,] gameBoard, int columnNumber, int playerNumber) {
            columnNumber--;
            bool result = false;

            for (int row = RowCount - 1; row >= 0; row--) {
                if (gameBoard[row, columnNumber] == 0) {
                    gameBoard[row, columnNumber] = playerNumber;
                    result = true;
                    break;
                }
            }

            return result;
        }

        public static void PrintGameBoard(int[,] gameBoard) {
            for (int row = 0; row < RowCount; row++) {
                for (int col = 0; col < ColCount; col++) {
                    Console.Write(gameBoard[row,col]);
                }
                Console.WriteLine();
            }
        }

        public static bool CheckIfInWinningState() {
            return false;
        }
    }

}