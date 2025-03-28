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

        // TODO: Wrap Console in a new 'Output' class
        public void Run() {
            int turnNumber = 0;
            bool winningState = false;
            _gameBoard.ShowGameBoard();

            // Continue until either someone has won or the board is full
            while (!winningState && turnNumber < _maxNumberOfTurns) {
                IPlayer currentTurnPlayer = WhosTurnIsIt(turnNumber);
                int columnToPlay = currentTurnPlayer.GetNextMove();

                while (!_gameBoard.PlaceToken(currentTurnPlayer, columnToPlay)) {
                    Console.WriteLine($"Column {columnToPlay} is full, please select a different column");
                    columnToPlay = currentTurnPlayer.GetNextMove();
                }
                           
                Console.WriteLine($"Player {currentTurnPlayer.Name} played column {columnToPlay}");
                _gameBoard.ShowGameBoard();

                winningState = _gameBoard.IsInWinningState(columnToPlay);
                if (winningState) {
                    Console.WriteLine($"Player {currentTurnPlayer.Name} has won!");
                }

                turnNumber++;
            }

            if (turnNumber == _maxNumberOfTurns) {
                Console.WriteLine("Board is full - it's a draw!");
            }
        }

        private IPlayer WhosTurnIsIt(int turnNumber) {
            int playerIndex = turnNumber % Constants.NumberOfPlayers;
            return _players[playerIndex];
        }
    }
}