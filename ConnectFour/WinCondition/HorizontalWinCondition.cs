namespace ConnectFour;

/// <summary>
/// Horizontal line win condition
/// </summary>
public class HorizontalWinCondition : WinCondition {
    
    public HorizontalWinCondition(IGameBoard gameBoard, int tokensInLineForAWin)
        : base(gameBoard, tokensInLineForAWin) {}

    /// <inheritdoc/>
    public override bool IsFulfilled(int columnLastPlayed){
        int rowIndexLastPlayed = GetRowOfLastPlayedToken(columnLastPlayed);
        TokenType token = GetToken(rowIndexLastPlayed, columnLastPlayed);
        
        int tokensInHorizontalLine = 1;
        // Check rightwards of last placed token
        int col = columnLastPlayed + 1;
        while (col <= NumberOfColumns && GetToken(rowIndexLastPlayed, col) == token) {
            col++;
            tokensInHorizontalLine++;
        }
        // Check leftwards of last placed token
        col = columnLastPlayed - 1;
        while (col > 0 && GetToken(rowIndexLastPlayed, col) == token) {
            col--;
            tokensInHorizontalLine++;
        }

        return IsLineBigEnoughForAWin(tokensInHorizontalLine);
    }
}