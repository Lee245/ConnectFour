namespace ConnectFour {
    /// <inheritdoc/>
    public class GameBoardViewer : IGameBoardViewer
    {
        /// <inheritdoc/>
        public void ShowGameBoard(TokenType[,] gameBoardMatrix, int rowIndexUpperBound, int colIndexUpperBound)
        {
            // Print from top to bottom
            Console.WriteLine("-----------------------------");
            for (int row = rowIndexUpperBound; row >=0; row--) {
                Console.Write("| ");
                for (int col = 0; col <= colIndexUpperBound; col++) {
                    TokenType tokenType = gameBoardMatrix[row,col];
                    string tokenString = GetStringRepresentation(tokenType);
                    Console.Write(tokenString);
                    Console.Write(" | ");
                }
                Console.WriteLine();
                Console.WriteLine("-----------------------------");
            }
            Console.WriteLine();
        }

        private static string GetStringRepresentation(TokenType tokenType) {
            string result;
            switch (tokenType) {
                case TokenType.None:
                    result = " ";
                    break;
                case TokenType.Red:
                    result = "R";
                    break;
                case TokenType.Yellow:
                    result = "Y";
                    break;
                default:
                    throw new ArgumentException($"TokenType {tokenType} not recognized");
            }
            
            return result;
        }
    }
}