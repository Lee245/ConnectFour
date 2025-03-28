namespace ConnectFour {
    internal class Program {
        static void Main() {
            // Initialize
            PlayerFactory playerFactory = new PlayerFactory();
            IList<IPlayer> players = [playerFactory.CreatePlayer(PlayerType.Human), playerFactory.CreatePlayer(PlayerType.RandomComputer)];
            int[,] gameBoardMatrix = new int[Constants.NumberOfRows, Constants.NumberOfColumns];
            IGameBoard gameBoard = new GameBoard(new GameBoardViewer(), gameBoardMatrix, Constants.TokensInLineForAWin);
            GameEngine gameEngine = new GameEngine(players, gameBoard);

            // Run
            gameEngine.Run();
        }
    }

}