namespace ConnectFour;

/// <summary>
/// Upward diagonal line win condition
/// </summary>
public class UpwardDiagonalWinCondition : WinCondition {
    
    public UpwardDiagonalWinCondition(IGameBoard gameBoard, int tokensInLineForAWin)
        : base(gameBoard, tokensInLineForAWin) {}

    /// <inheritdoc/>
    public override bool IsFulfilled(int columnLastPlayed){
        int rowLastPlayed = GetRowOfLastPlayedToken(columnLastPlayed);
        TokenType token = GetToken(rowLastPlayed, columnLastPlayed);
        
        int tokensUpwardDiagonalLine = 1;
        // Check to the upper-right of last placed token
        int row = rowLastPlayed + 1;
        int col = columnLastPlayed + 1;
        while (row <= NumberOfRows && col <= NumberOfColumns && GetToken(row, col) == token) {
            row++;
            col++;
            tokensUpwardDiagonalLine++;
        }
        // Check to the lower-left of last placed token
        row = rowLastPlayed - 1;
        col = columnLastPlayed - 1;
        while (row > 0 && col > 0 && GetToken(row, col) == token) {
            row--;
            col--;
            tokensUpwardDiagonalLine++;
        }

        return IsLineBigEnoughForAWin(tokensUpwardDiagonalLine);
    }
}