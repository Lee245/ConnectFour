using ConnectFour;

namespace ConnectFourTest;

[TestClass]
public sealed class HorizontalWinConditionTests
{
   [TestMethod]
    public void IsFulfilled_WhenCalledAndHorizontalLine_ReturnsTrue()
    {
        // Arrange
        TokenType[,] gameBoardMatrix = new TokenType[6, 7];
        gameBoardMatrix[0,0] = TokenType.Yellow;
        gameBoardMatrix[0,1] = TokenType.Yellow;
        gameBoardMatrix[0,2] = TokenType.Yellow;
        gameBoardMatrix[0,3] = TokenType.Yellow;
        IGameBoard gameBoard = new GameBoard(gameBoardMatrix);
        HorizontalWinCondition winCondition = new HorizontalWinCondition(gameBoard, 4);

        // Act
        bool result1 = winCondition.IsFulfilled(1);
        bool result2 = winCondition.IsFulfilled(2);
        bool result3 = winCondition.IsFulfilled(3);
        bool result4 = winCondition.IsFulfilled(4);

        // Assert
        Assert.IsTrue(result1);
        Assert.IsTrue(result2);
        Assert.IsTrue(result3);
        Assert.IsTrue(result4);
    }

    [TestMethod]
    public void IsFulfilled_WhenCalledAndNotTheCase_ReturnsFalse()
    {
        // Arrange
        TokenType[,] gameBoardMatrix = new TokenType[6, 7];
        gameBoardMatrix[0,0] = TokenType.Yellow;
        gameBoardMatrix[0,1] = TokenType.Yellow;
        gameBoardMatrix[0,2] = TokenType.Yellow;
        gameBoardMatrix[0,3] = TokenType.Yellow;
        IGameBoard gameBoard = new GameBoard(gameBoardMatrix);
        HorizontalWinCondition winCondition = new HorizontalWinCondition(gameBoard, 5);

        // Act
        bool result1 = winCondition.IsFulfilled(1);

        // Assert
        Assert.IsFalse(result1);
    }
}