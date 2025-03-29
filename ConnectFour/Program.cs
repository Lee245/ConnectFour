namespace ConnectFour {
    internal class Program {
        static void Main() {
            // Initialize
            PlayerFactory playerFactory = new PlayerFactory(Constants.NumberOfColumns);
            IList<IPlayer> players = [playerFactory.CreatePlayer(PlayerType.Human), playerFactory.CreatePlayer(PlayerType.RandomComputer)];
            TokenType[,] gameBoardMatrix = new TokenType[Constants.NumberOfRows, Constants.NumberOfColumns];
            IGameBoard gameBoard = new GameBoard(new GameBoardViewer(), gameBoardMatrix, Constants.TokensInLineForAWin);
            GameEngine gameEngine = new GameEngine(players, gameBoard);

            // Run
            gameEngine.Run();
        }
    }

}