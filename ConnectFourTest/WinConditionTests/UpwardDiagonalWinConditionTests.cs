using ConnectFour;
using Moq;

namespace ConnectFourTest;

[TestClass]
public sealed class UpwardDiagonalWinConditionTests
{
    [TestMethod]
    public void IsFulfilled_WhenCalledAndUpwardDiagonal_ReturnsTrue()
    {
        // Arrange
        TokenType[,] gameBoardMatrix = new TokenType[3, 3];
        gameBoardMatrix[0,0] = TokenType.Yellow;
        gameBoardMatrix[1,1] = TokenType.Yellow;
        gameBoardMatrix[2,2] = TokenType.Yellow;
        IGameBoard gameBoard = new GameBoard(Mock.Of<IGameBoardViewer>(), gameBoardMatrix);
        UpwardDiagonalWinCondition winCondition = new UpwardDiagonalWinCondition(gameBoard, 3);

        // Act
        bool result1 = winCondition.IsFulfilled(1);
        bool result2 = winCondition.IsFulfilled(2);
        bool result3 = winCondition.IsFulfilled(3);

        // Assert
        Assert.IsTrue(result1);
        Assert.IsTrue(result2);
        Assert.IsTrue(result3);
    }

    [TestMethod]
    public void IsFulfilled_WhenCalledAndUFalse_ReturnsFalse()
    {
        // Arrange
        TokenType[,] gameBoardMatrix = new TokenType[4, 4];
        gameBoardMatrix[0,0] = TokenType.Yellow;
        gameBoardMatrix[1,1] = TokenType.Yellow;
        gameBoardMatrix[2,2] = TokenType.Yellow;
        IGameBoard gameBoard = new GameBoard(Mock.Of<IGameBoardViewer>(), gameBoardMatrix);
        UpwardDiagonalWinCondition winCondition = new UpwardDiagonalWinCondition(gameBoard, 4);

        // Act
        bool result1 = winCondition.IsFulfilled(1);
        bool result2 = winCondition.IsFulfilled(2);
        bool result3 = winCondition.IsFulfilled(3);

        // Assert
        Assert.IsFalse(result1);
        Assert.IsFalse(result2);
        Assert.IsFalse(result3);
    }
}