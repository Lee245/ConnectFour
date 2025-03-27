namespace ConnectFour {
    internal class Program {

        private const int RowCount = 6;
        private const int ColCount = 7;

        static void Main(string[] args) {
            PlayerFactory playerFactory = new PlayerFactory();
            IList<IPlayer> players = [playerFactory.CreatePlayer(PlayerType.Human), playerFactory.CreatePlayer(PlayerType.Computer)];
            IGameBoard gameBoard = new GameBoard();

            GameEngine gameEngine = new GameEngine(players, gameBoard);
            gameEngine.Run();
        }
    }

}