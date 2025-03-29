namespace ConnectFour {
    internal class Program {
        static void Main() {
            // Initialize
            PlayerFactory playerFactory = new PlayerFactory();
            IList<IPlayer> players = [playerFactory.CreatePlayer(PlayerType.Human), playerFactory.CreatePlayer(PlayerType.RandomComputer)];
            TokenType[,] gameBoardMatrix = new TokenType[Constants.NumberOfRows, Constants.NumberOfColumns];
            IGameBoard gameBoard = new GameBoard(gameBoardMatrix);
            int tokensInLineForAWin = Constants.TokensInLineForAWin;
            IList<IWinCondition> winConditions = [
                new HorizontalWinCondition(gameBoard, tokensInLineForAWin),
                new VerticalWinCondition(gameBoard, tokensInLineForAWin),
                new UpwardDiagonalWinCondition(gameBoard, tokensInLineForAWin),
                new DownwardDiagonalWinCondition(gameBoard, tokensInLineForAWin)
            ];
            IOutputViewer outputViewer = new OutputViewer();
            GameEngine gameEngine = new GameEngine(players, gameBoard, winConditions, outputViewer);

            // Run
            gameEngine.Run();
        }
    }

}