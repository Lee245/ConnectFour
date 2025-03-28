namespace ConnectFour {
    /// <inheritdoc/>
    public class GameBoardViewer : IGameBoardViewer
    {
        /// <inheritdoc/>
        public void ShowGameBoard(int[,] gameBoardMatrix, int rowIndexUpperBound, int colIndexUpperBound)
        {
            // Print from top to bottom
            Console.WriteLine("-----------------------------");
            for (int row = rowIndexUpperBound; row >=0; row--) {
                Console.Write("| ");
                for (int col = 0; col <= colIndexUpperBound; col++) {
                    Console.Write(gameBoardMatrix[row,col]);
                    Console.Write(" | ");
                }
                Console.WriteLine();
                Console.WriteLine("-----------------------------");
            }
        }
    }
}