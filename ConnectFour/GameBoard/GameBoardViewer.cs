namespace ConnectFour {
    /// <inheritdoc/>
    internal class GameBoardViewer : IGameBoardViewer
    {
        /// <inheritdoc/>
        public void ShowGameBoard(int[,] gameBoardMatrix)
        {
            // Print from top to bottom
            for (int row = Constants.NumberOfRows - 1; row >=0; row--) {
                Console.Write("| ");
                for (int col = 0; col < Constants.NumberOfColumns; col++) {
                    Console.Write(gameBoardMatrix[row,col]);
                    Console.Write(" | ");
                }
                Console.WriteLine();
                Console.WriteLine("-----------------------------");
            }
        }
    }
}