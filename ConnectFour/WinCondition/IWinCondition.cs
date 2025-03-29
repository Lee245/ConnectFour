namespace ConnectFour;

/// <summary>
/// Class representing the win condition on a board
/// </summary>
public interface IWinCondition {
    /// <summary>
    /// Check if the win condition is fulfilled
    /// </summary>
    /// <param name="columnLastPlayed">Last played column</param>
    /// <returns>True, if win condition is fulfilled. False, otherwise.</returns>
    bool IsFulfilled(int columnLastPlayed);
}