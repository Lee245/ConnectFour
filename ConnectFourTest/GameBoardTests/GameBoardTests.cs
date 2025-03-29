using ConnectFour;

namespace ConnectFourTest;

[TestClass]
public sealed class GameBoardTests
{
    [TestMethod]
    public void PlaceToken_WhenCalledAndThereIsNoSpace_ThrowsException()
    {
        // Arrange
        TokenType[,] gameBoardMatrix = new TokenType[1, 1];
        gameBoardMatrix[0,0] = TokenType.Yellow;
        IGameBoard gameBoard = new GameBoard(gameBoardMatrix);

        // Act & Assert
        Assert.ThrowsException<InvalidOperationException>(() => gameBoard.PlaceToken(TokenType.Yellow, 1));
    }

    [TestMethod]
    public void PlaceToken_WhenCalledAndThereIsSpace_ThrowsNoException()
    {
        // Arrange
        TokenType[,] gameBoardMatrix = new TokenType[1, 1];
        IGameBoard gameBoard = new GameBoard(gameBoardMatrix);

        // Act & Assert
        // No Exception should be thrown
        gameBoard.PlaceToken(TokenType.Yellow, 1);
    }

    [TestMethod]
    public void IsFulfilled_WhenCalledAndFalse_ReturnsFalse()
    {
        // Arrange
        TokenType[,] gameBoardMatrix = new TokenType[2, 1];
        gameBoardMatrix[0,0] = TokenType.Yellow;
        IGameBoard gameBoard = new GameBoard(gameBoardMatrix);
        HorizontalWinCondition winCondition = new HorizontalWinCondition(gameBoard, 2);

        // Act
        bool result = winCondition.IsFulfilled(1);

        // Assert
        Assert.IsFalse(result);
    }
}
