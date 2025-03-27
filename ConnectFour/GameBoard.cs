namespace ConnectFour {
    internal class GameBoard : IGameBoard
    {
        private readonly int[,] _gameBoardMatrix = new int[Constants.NumberOfRows, Constants.NumberOfColumns];
        private readonly IGameBoardViewer _gameBoardViewer;

        public GameBoard(IGameBoardViewer gameBoardViewer) {
            _gameBoardViewer = gameBoardViewer;
        }

        public bool IsInWinningState()
        {
            throw new NotImplementedException();
        }

        public bool PlaceToken(IPlayer player, int columnNumber)
        {
            throw new NotImplementedException();
        }
    }
}