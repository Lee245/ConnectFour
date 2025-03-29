namespace ConnectFour;

/// <summary>
/// Win condition base class
/// </summary>
public abstract class WinCondition : IWinCondition {

    private readonly IGameBoard _gameBoard;
    private readonly int _tokensInLineForAWin;

    protected WinCondition(IGameBoard gameBoard, int tokensInLineForAWin) {
        _gameBoard = gameBoard;
        _tokensInLineForAWin = tokensInLineForAWin;
    }

    protected int NumberOfRows => _gameBoard.NumberOfRows;

    protected int NumberOfColumns => _gameBoard.NumberOfColumns;

    /// <summary>
    /// Check if line is big enough for a win
    /// </summary>
    /// <param name="numberOfTokensInLine">Number of tokens in the line</param>
    /// <returns>True, if sufficient for a win. False, otherwise.</returns>
    protected bool IsLineBigEnoughForAWin(int numberOfTokensInLine) {
        return numberOfTokensInLine >= _tokensInLineForAWin;
    }

    /// <summary>
    /// Get row index of last placed token
    /// </summary>
    /// <param name="columnLastPlayed">Column index last played</param>
    /// <returns>Row index for the token</returns>
    protected int GetRowOfLastPlayedToken(int columnLastPlayed) {
        return _gameBoard.GetRowOfLastPlayedToken(columnLastPlayed);
    }

    /// <summary>
    /// Get token
    /// </summary>
    /// <param name="row">1-based row index</param>
    /// <param name="column">1-based column index</param>
    /// <returns>The token at that position</returns>
    protected TokenType GetToken(int row, int column) {
        return _gameBoard.GetTokenAt(row, column);
    }

    /// <summary>
    /// Check if the win condition is fulfilled
    /// </summary>
    /// <param name="columnLastPlayed">Last played column</param>
    /// <returns>True, if win condition is fulfilled. False, otherwise.</returns>
    public abstract bool IsFulfilled(int columnLastPlayed);
}