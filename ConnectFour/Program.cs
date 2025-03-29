namespace ConnectFour {
    internal class Program {
        static void Main() {
            // Initialize
            PlayerFactory playerFactory = new PlayerFactory(Constants.NumberOfColumns);
            IList<IPlayer> players = [playerFactory.CreatePlayer(PlayerType.Human), playerFactory.CreatePlayer(PlayerType.RandomComputer)];
            TokenType[,] gameBoardMatrix = new TokenType[Constants.NumberOfRows, Constants.NumberOfColumns];
            IGameBoard gameBoard = new GameBoard(new GameBoardViewer(), gameBoardMatrix);
            int tokensInLineForAWin = Constants.TokensInLineForAWin;
            IList<IWinCondition> winConditions = [
                new HorizontalWinCondition(gameBoard, tokensInLineForAWin),
                new VerticalWinCondition(gameBoard, tokensInLineForAWin),
                new UpwardDiagonalWinCondition(gameBoard, tokensInLineForAWin),
                new DownwardDiagonalWinCondition(gameBoard, tokensInLineForAWin)
            ];
            GameEngine gameEngine = new GameEngine(players, gameBoard, winConditions);

            // Run
            gameEngine.Run();
        }
    }

}