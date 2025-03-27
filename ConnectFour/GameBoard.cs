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
            return false;
        }

        public bool PlaceToken(IPlayer player, int columnNumber)
        {
            columnNumber--;
            bool result = false;

            for (int row = Constants.NumberOfRows - 1; row >= 0; row--) {
                if (_gameBoardMatrix[row, columnNumber] == 0) {
                    _gameBoardMatrix[row, columnNumber] = player.Number;
                    result = true;
                    break;
                }
            }

            return result;
        }
    }
}