namespace ConnectFour {
    internal class PlayerFactory {
        public IPlayer CreatePlayer(PlayerType playerType) {
            switch (playerType) {
                case PlayerType.Human:
                    return new HumanPlayer();
                case PlayerType.Computer:
                    return new ComputerPlayer();
                default:
                    throw new ArgumentException($"Player type {playerType} not recognized");
            }
        }
    }
}