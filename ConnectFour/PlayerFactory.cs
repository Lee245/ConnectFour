namespace ConnectFour {
    internal class PlayerFactory {
        public IPlayer CreatePlayer(PlayerType playerType) {
            switch (playerType) {
                case PlayerType.Human:
                case PlayerType.Computer:
                default:
                    throw new ArgumentException($"Player type {playerType} not recognized");
            }
        }
    }
}