namespace ConnectFour {
    /// <summary>
    /// Class for running the actual m,n,k-game
    /// </summary>
    internal class GameEngine { 
        private readonly IList<IPlayer> _players;
        private readonly IGameBoard _gameBoard;
        private readonly IList<IWinCondition> _winConditions;
        private readonly int _maxNumberOfTurns = Constants.NumberOfColumns * Constants.NumberOfRows;
        private readonly IOutputViewer _outputViewer;
        
        public GameEngine(IList<IPlayer> players, IGameBoard gameBoard, IList<IWinCondition> winConditions,
            IOutputViewer outputViewer) {
            _players = players;
            _gameBoard = gameBoard;
            _winConditions = winConditions;
            _outputViewer = outputViewer;
        }

        public void Run() {
            int turnNumber = 0;
            bool winningState = false;
            _outputViewer.PrintGameBoard(_gameBoard);
            IPlayer? currentTurnPlayer = null;

            // Continue until either someone has won or the board is full
            while (!winningState && turnNumber < _maxNumberOfTurns) {
                turnNumber++;
                currentTurnPlayer = GetPlayerForTurn(turnNumber);
                int columnToPlay = currentTurnPlayer.GetNextMove();

                while (!_gameBoard.PlaceToken(currentTurnPlayer.TokenType, columnToPlay)) {
                    _outputViewer.ShowMessage($"Column {columnToPlay} is full, please select a different column");
                    columnToPlay = currentTurnPlayer.GetNextMove();
                }
                           
                _outputViewer.ShowMessage($"Player {currentTurnPlayer.Name} played column {columnToPlay}");
                _outputViewer.PrintGameBoard(_gameBoard);

                winningState = IsGameInWinningState(columnToPlay);
            }

            if (winningState) {
                _outputViewer.ShowMessage($"Player {currentTurnPlayer?.Name} has won!");
            }
            else {
                _outputViewer.ShowMessage("Board is full - it's a draw!");
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