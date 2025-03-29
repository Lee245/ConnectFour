using ConnectFour;
using Moq;

namespace ConnectFourTest;

[TestClass]
public sealed class VerticalWinConditionTests
{
    [TestMethod]
    public void IsFulfilled_WhenCalledAndVerticalLine_ReturnsTrue()
    {
        // Arrange
        TokenType[,] gameBoardMatrix = new TokenType[6, 7];
        gameBoardMatrix[0,0] = TokenType.Yellow;
        gameBoardMatrix[1,0] = TokenType.Yellow;
        gameBoardMatrix[2,0] = TokenType.Yellow;
        gameBoardMatrix[3,0] = TokenType.Yellow;
        IGameBoard gameBoard = new GameBoard(Mock.Of<IGameBoardViewer>(), gameBoardMatrix);
        VerticalWinCondition winCondition = new VerticalWinCondition(gameBoard, 4);

        // Act
        bool result = winCondition.IsFulfilled(1);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsFulfilled_WhenCalledAndFalse_ReturnsFalse()
    {
        // Arrange
        TokenType[,] gameBoardMatrix = new TokenType[6, 7];
        gameBoardMatrix[0,0] = TokenType.Yellow;
        gameBoardMatrix[1,0] = TokenType.Yellow;
        gameBoardMatrix[2,0] = TokenType.Yellow;
        gameBoardMatrix[3,0] = TokenType.Yellow;
        IGameBoard gameBoard = new GameBoard(Mock.Of<IGameBoardViewer>(), gameBoardMatrix);
        VerticalWinCondition winCondition = new VerticalWinCondition(gameBoard, 5);

        // Act
        bool result = winCondition.IsFulfilled(1);

        // Assert
        Assert.IsFalse(result);
    }
}