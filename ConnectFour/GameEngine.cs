namespace ConnectFour {
    /// <summary>
    /// Class for running the actual m,n,k-game
    /// </summary>
    internal class GameEngine { 
        private readonly IList<IPlayer> _players;
        private readonly IGameBoard _gameBoard;
        private readonly int _maxNumberOfTurns = Constants.NumberOfColumns * Constants.NumberOfRows;
        
        public GameEngine(IList<IPlayer> players, IGameBoard gameBoard) {
            _players = players;
            _gameBoard = gameBoard;
        }

        public void Run() {
            int[,] gameBoard = new int[Constants.NumberOfRows, Constants.NumberOfColumns];
            PrintGameBoard(gameBoard);          

            int turnNumber = 0;
            bool winningState = false;
            while (!winningState && turnNumber < _maxNumberOfTurns) {
                IPlayer currentTurnPlayer = WhosTurnIsIt(turnNumber);
                int columnToPlay = currentTurnPlayer.GetNextMove();

                while (!_gameBoard.PlaceToken(currentTurnPlayer, columnToPlay)) {
                    Console.WriteLine($"Column {columnToPlay} is full, please select a different column");
                    columnToPlay = currentTurnPlayer.GetNextMove();
                }
                           
                PrintGameBoard(gameBoard);

                winningState = _gameBoard.IsInWinningState();
                if (winningState) {
                    Console.WriteLine($"Player {currentTurnPlayer.Name} has won!");
                }

                turnNumber++;
            }

            if (turnNumber == _maxNumberOfTurns) {
                Console.WriteLine("Board is full and there is no winner");
            }
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

        private IPlayer WhosTurnIsIt(int turnNumber) {
            int playerIndex = turnNumber % 2;
            return _players[playerIndex];
        }
    }
}