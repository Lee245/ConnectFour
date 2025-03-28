namespace ConnectFour {
    /// <summary>
    /// Class to visualize the gameboard
    /// </summary>
    public interface IGameBoardViewer {
        /// <summary>
        /// Show the gameboard
        /// </summary>
        /// <param name="gameBoardMatrix">Gameboard representation</param>
        void ShowGameBoard(int[,] gameBoardMatrix);
    }
}