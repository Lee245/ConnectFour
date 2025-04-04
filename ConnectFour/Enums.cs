namespace ConnectFour {
    /// <summary>
    /// Enum differentiating the types of player
    /// </summary>
    public enum PlayerType {
        Human,
        RandomComputer
    }

    /// <summary>
    /// Enum representing the tokens
    /// </summary>
    public enum TokenType {
        None,
        Yellow,
        Red
    }

    /// <summary>
    /// State of the game
    /// </summary>
    public enum GameState {
        None,
        InProgress,
        PlayerHasWon,
        Draw
    }
}