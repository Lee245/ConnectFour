namespace ConnectFour {
    internal class GameEngine { 
        private readonly IList<IPlayer> _players;
        
        public GameEngine(IList<IPlayer> players) {
            _players = players;
        }
    }
}