using ConnectFour;
using Moq;

namespace ConnectFourTest;

[TestClass]
public sealed class DownwardDiagonalWinConditionTests
{
    [TestMethod]
    public void IsFulfilled_WhenCalledAndDownwardDiagonal_ReturnsTrue()
    {
        // Arrange
        TokenType[,] gameBoardMatrix = new TokenType[3, 3];
        gameBoardMatrix[0,2] = TokenType.Yellow;
        gameBoardMatrix[1,1] = TokenType.Yellow;
        gameBoardMatrix[2,0] = TokenType.Yellow;
        IGameBoard gameBoard = new GameBoard(Mock.Of<IGameBoardViewer>(), gameBoardMatrix);
        DownwardDiagonalWinCondition winCondition = new DownwardDiagonalWinCondition(gameBoard, 3);

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
    public void IsFulfilled_WhenCalledAndFalse_ReturnsFalse()
    {
        // Arrange
        TokenType[,] gameBoardMatrix = new TokenType[4, 4];
        gameBoardMatrix[0,2] = TokenType.Yellow;
        gameBoardMatrix[1,1] = TokenType.Yellow;
        gameBoardMatrix[2,0] = TokenType.Yellow;
        IGameBoard gameBoard = new GameBoard(Mock.Of<IGameBoardViewer>(), gameBoardMatrix);
        DownwardDiagonalWinCondition winCondition = new DownwardDiagonalWinCondition(gameBoard, 4);

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