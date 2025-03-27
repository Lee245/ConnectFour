namespace ConnectFour {
    public interface IGameBoard {
        bool PlaceToken(IPlayer player, int columnNumber);

        bool IsInWinningState();
    }
}