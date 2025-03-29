namespace ConnectFour;

/// <summary>
/// Class for viewing user-facing output
/// </summary>
public interface IOutputViewer {
    /// <summary>
    /// Show message
    /// </summary>
    /// <param name="message">The message</param>
    void ShowMessage(string message);

    /// <summary>
    /// Print game board
    /// </summary>
    /// <param name="gameBoard">The game board</param>
    void PrintGameBoard(IGameBoard gameBoard);
}