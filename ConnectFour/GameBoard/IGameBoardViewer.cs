namespace ConnectFour {
    /// <summary>
    /// Class to visualize the gameboard
    /// </summary>
    public interface IGameBoardViewer {
        /// <summary>
        /// Show the gameboard
        /// </summary>
        /// <param name="gameBoardMatrix">Gameboard representation</param>
        /// <param name="rowIndexUpperBound">Upper bound row index</param>
        /// <param name="colIndexUpperBound">Upper bound column index</param>
        void ShowGameBoard(TokenType[,] gameBoardMatrix, int rowIndexUpperBound, int colIndexUpperBound);
    }
}