namespace ConnectFour;

/// <summary>
/// Vertical line win condition
/// </summary>
public class VerticalWinCondition : WinCondition {
    
    public VerticalWinCondition(IGameBoard gameBoard, int tokensInLineForAWin)
        : base(gameBoard, tokensInLineForAWin) {}

    /// <inheritdoc/>
    public override bool IsFulfilled(int columnLastPlayed){
        int rowIndexLastPlayed = GetRowOfLastPlayedToken(columnLastPlayed);
        TokenType token = GetToken(rowIndexLastPlayed, columnLastPlayed);
        
        int tokensInVerticalLine = 1;
        // Check upwards of last placed token
        int row = rowIndexLastPlayed + 1;
        while (row <= NumberOfRows && GetToken(row, columnLastPlayed) == token) {
            row++;
            tokensInVerticalLine++;
        }
        // Check downwards of last placed token
        row = rowIndexLastPlayed - 1;
        while (row > 0 && GetToken(row, columnLastPlayed) == token) {
            row--;
            tokensInVerticalLine++;
        }
        return IsLineBigEnoughForAWin(tokensInVerticalLine);
    }
}