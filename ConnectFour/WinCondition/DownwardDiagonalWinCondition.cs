namespace ConnectFour;

/// <summary>
/// Down diagonal line win condition
/// </summary>
public class DownwardDiagonalWinCondition : WinCondition {
    
    public DownwardDiagonalWinCondition(IGameBoard gameBoard, int tokensInLineForAWin)
        : base(gameBoard, tokensInLineForAWin) {}

    /// <inheritdoc/>
    public override bool IsFulfilled(int columnLastPlayed){
        int rowLastPlayed = GetRowOfLastPlayedToken(columnLastPlayed);
        TokenType token = GetToken(rowLastPlayed, columnLastPlayed);
        
        int tokensDownwardDiagonalLine = 1;
        // Check to the upper-left of last placed token
        int row = rowLastPlayed + 1;
        int col = columnLastPlayed - 1;
        while (row <= NumberOfRows && col > 0 && GetToken(row, col) == token) {
            row++;
            col--;
            tokensDownwardDiagonalLine++;
        }
        // Check to the lower-right of last placed token
        row = rowLastPlayed - 1;
        col = columnLastPlayed + 1;
        while (row > 0 && col <= NumberOfColumns && GetToken(row, col) == token) {
            row--;
            col++;
            tokensDownwardDiagonalLine++;
        }

        return IsLineBigEnoughForAWin(tokensDownwardDiagonalLine);
    }
}