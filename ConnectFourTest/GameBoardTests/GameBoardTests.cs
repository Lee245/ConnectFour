using ConnectFour;
using Moq;

namespace ConnectFourTest;

[TestClass]
public sealed class GameBoardTests
{
    [TestMethod]
    public void PlaceToken_WhenCalledAndThereIsSpace_ReturnsTrue()
    {
        // Arrange
        TokenType[,] gameBoardMatrix = new TokenType[1, 1];
        IGameBoard gameBoard = new GameBoard(Mock.Of<IGameBoardViewer>(), gameBoardMatrix);

        // Act
        bool result = gameBoard.PlaceToken(TokenType.Yellow, 1);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void PlaceToken_WhenCalledAndThereIsNoSpace_ReturnsFalse()
    {
        // Arrange
        TokenType[,] gameBoardMatrix = new TokenType[1, 1];
        gameBoardMatrix[0,0] = TokenType.Yellow;
        IGameBoard gameBoard = new GameBoard(Mock.Of<IGameBoardViewer>(), gameBoardMatrix);

        // Act
        bool result = gameBoard.PlaceToken(TokenType.Yellow, 1);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsFulfilled_WhenCalledAndFalse_ReturnsFalse()
    {
        // Arrange
        TokenType[,] gameBoardMatrix = new TokenType[2, 1];
        gameBoardMatrix[0,0] = TokenType.Yellow;
        IGameBoard gameBoard = new GameBoard(Mock.Of<IGameBoardViewer>(), gameBoardMatrix);
        HorizontalWinCondition winCondition = new HorizontalWinCondition(gameBoard, 2);

        // Act
        bool result = winCondition.IsFulfilled(1);

        // Assert
        Assert.IsFalse(result);
    }
}
