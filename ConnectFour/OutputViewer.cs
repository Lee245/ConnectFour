namespace ConnectFour;


/// <inheritdoc/>
public class OutputViewer : IOutputViewer
{
    /// <inheritdoc/>
    public void PrintGameBoard(IGameBoard gameBoard)
    {
        // Print from top to bottom
        WriteSeparatorLine(gameBoard.NumberOfColumns);
        for (int row = gameBoard.NumberOfRows; row >0; row--) {
            Console.Write("| ");
            for (int col = 1; col <= gameBoard.NumberOfColumns; col++) {
                TokenType tokenType = gameBoard.GetTokenAt(row,col);
                string tokenString = GetStringRepresentation(tokenType);
                Console.Write(tokenString);
                Console.Write(" | ");
            }
            Console.WriteLine();
            WriteSeparatorLine(gameBoard.NumberOfColumns);
        }
        Console.WriteLine();
    }

    /// <inheritdoc/>
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    private static void WriteSeparatorLine(int numberOfColumns) {
        Console.Write("-----");
        for (int col = 1; col < numberOfColumns; col++) {
            Console.Write("----");
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