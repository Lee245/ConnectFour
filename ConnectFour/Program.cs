namespace ConnectFour {
    internal class Program {
        static void Main() {
            // Initialize
            PlayerFactory playerFactory = new PlayerFactory();
            IList<IPlayer> players = [playerFactory.CreatePlayer(PlayerType.Human), playerFactory.CreatePlayer(PlayerType.Computer)];
            IGameBoard gameBoard = new GameBoard(new GameBoardViewer());
            GameEngine gameEngine = new GameEngine(players, gameBoard);

            // Run
            gameEngine.Run();
        }
    }

}