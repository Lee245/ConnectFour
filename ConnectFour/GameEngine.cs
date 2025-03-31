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
            GameState gameState = GameState.InProgress;
            _outputViewer.PrintGameBoard(_gameBoard);
            IPlayer? currentTurnPlayer = null;

            // Continue until either someone has won or the board is full
            while (gameState == GameState.InProgress) {
                turnNumber++;
                currentTurnPlayer = GetPlayerForTurn(turnNumber);
                int columnToPlay = currentTurnPlayer.GetNextMove(_gameBoard.NumberOfColumns);

                while (IsColumnFull(columnToPlay)) {
                    _outputViewer.ShowMessage($"Column {columnToPlay} is full, please select a different column");
                    columnToPlay = currentTurnPlayer.GetNextMove(_gameBoard.NumberOfColumns);
                }
                _gameBoard.PlaceToken(currentTurnPlayer.TokenType, columnToPlay);
                           
                _outputViewer.ShowMessage($"Player {currentTurnPlayer.Name} played column {columnToPlay}");
                _outputViewer.PrintGameBoard(_gameBoard);


                gameState = GetUpdatedGameState(turnNumber, columnToPlay);
            }

            if (gameState == GameState.PlayerHasWon) {
                _outputViewer.ShowMessage($"Player {currentTurnPlayer?.Name} has won!");
            }
            else if (gameState == GameState.Draw) {
                _outputViewer.ShowMessage("Board is full - it's a draw!");
            }
            else {
                throw new InvalidOperationException($"Error: Game has ended with unexpected state {gameState}");
            }
        }

        private IPlayer GetPlayerForTurn(int turnNumber) {
            int playerIndex = (turnNumber - 1) % _players.Count;
            return _players[playerIndex];
        }

        private bool HasPlayerWon(int columnLastPlayed) {
            return _winConditions.Any(i => i.IsFulfilled(columnLastPlayed));
        }

        private bool IsColumnFull(int columnToPlay) {
            return _gameBoard.GetTokenAt(_gameBoard.NumberOfRows, columnToPlay) != TokenType.None;
        }

        private GameState GetUpdatedGameState(int turnNumber, int columnToPlay) {
            GameState gameState = GameState.InProgress;
            if (turnNumber == _maxNumberOfTurns) {
                gameState = GameState.Draw;
            }
            if (HasPlayerWon(columnToPlay)) {
                gameState = GameState.PlayerHasWon;
            }

            return gameState;
        }
    }
}