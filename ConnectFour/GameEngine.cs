namespace ConnectFour {
    /// <summary>
    /// Class for running the actual m,n,k-game
    /// </summary>
    internal class GameEngine { 
        private readonly IList<IPlayer> _players;
        private readonly IGameBoard _gameBoard;
        private readonly IList<IWinCondition> _winConditions;
        private readonly int _maxNumberOfTurns = Constants.NumberOfColumns * Constants.NumberOfRows;
        
        public GameEngine(IList<IPlayer> players, IGameBoard gameBoard, IList<IWinCondition> winConditions) {
            _players = players;
            _gameBoard = gameBoard;
            _winConditions = winConditions;
        }

        // TODO: Wrap Console in a new 'Output' class
        public void Run() {
            int turnNumber = 0;
            bool winningState = false;
            _gameBoard.ShowGameBoard();
            IPlayer? currentTurnPlayer = null;

            // Continue until either someone has won or the board is full
            while (!winningState && turnNumber < _maxNumberOfTurns) {
                turnNumber++;
                currentTurnPlayer = GetPlayerForTurn(turnNumber);
                int columnToPlay = currentTurnPlayer.GetNextMove();

                while (!_gameBoard.PlaceToken(currentTurnPlayer.TokenType, columnToPlay)) {
                    Console.WriteLine($"Column {columnToPlay} is full, please select a different column");
                    columnToPlay = currentTurnPlayer.GetNextMove();
                }
                           
                Console.WriteLine($"Player {currentTurnPlayer.Name} played column {columnToPlay}");
                _gameBoard.ShowGameBoard();

                winningState = IsGameInWinningState(columnToPlay);
            }

            if (winningState) {
                Console.WriteLine($"Player {currentTurnPlayer?.Name} has won!");
            }
            else {
                Console.WriteLine("Board is full - it's a draw!");
            }
        }

        private IPlayer GetPlayerForTurn(int turnNumber) {
            int playerIndex = (turnNumber - 1) % _players.Count;
            return _players[playerIndex];
        }

        private bool IsGameInWinningState(int columnLastPlayed) {
            return _winConditions.Any(i => i.IsFulfilled(columnLastPlayed));
        }
    }
}