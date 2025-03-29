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
        IGameBoard gameBoard = new GameBoard(Mock.Of<IGameBoardViewer>(), gameBoardMatrix, 4);

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
        IGameBoard gameBoard = new GameBoard(Mock.Of<IGameBoardViewer>(), gameBoardMatrix, 4);

        // Act
        bool result = gameBoard.PlaceToken(TokenType.Yellow, 1);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsInWinningState_WhenCalledAndFalse_ReturnsFalse()
    {
        // Arrange
        TokenType[,] gameBoardMatrix = new TokenType[2, 1];
        gameBoardMatrix[0,0] = TokenType.Yellow;
        IGameBoard gameBoard = new GameBoard(Mock.Of<IGameBoardViewer>(), gameBoardMatrix, 2);

        // Act
        bool result = gameBoard.IsInWinningState(1);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsInWinningState_WhenCalledAndHorizontalLine_ReturnsTrue()
    {
        // Arrange
        TokenType[,] gameBoardMatrix = new TokenType[6, 7];
        gameBoardMatrix[0,0] = TokenType.Yellow;
        gameBoardMatrix[0,1] = TokenType.Yellow;
        gameBoardMatrix[0,2] = TokenType.Yellow;
        gameBoardMatrix[0,3] = TokenType.Yellow;
        IGameBoard gameBoard = new GameBoard(Mock.Of<IGameBoardViewer>(), gameBoardMatrix, 4);

        // Act
        bool result1 = gameBoard.IsInWinningState(1);
        bool result2 = gameBoard.IsInWinningState(2);
        bool result3 = gameBoard.IsInWinningState(3);
        bool result4 = gameBoard.IsInWinningState(4);

        // Assert
        Assert.IsTrue(result1);
        Assert.IsTrue(result2);
        Assert.IsTrue(result3);
        Assert.IsTrue(result4);
    }

    [TestMethod]
    public void IsInWinningState_WhenCalledAndNotTheCase_ReturnsFalse()
    {
        // Arrange
        TokenType[,] gameBoardMatrix = new TokenType[6, 7];
        gameBoardMatrix[0,0] = TokenType.Yellow;
        gameBoardMatrix[0,1] = TokenType.Yellow;
        gameBoardMatrix[0,2] = TokenType.Yellow;
        gameBoardMatrix[0,3] = TokenType.Yellow;
        IGameBoard gameBoard = new GameBoard(Mock.Of<IGameBoardViewer>(), gameBoardMatrix, 5);

        // Act
        bool result1 = gameBoard.IsInWinningState(1);

        // Assert
        Assert.IsFalse(result1);
    }

    [TestMethod]
    public void IsInWinningState_WhenCalledAndVerticalLine_ReturnsTrue()
    {
        // Arrange
        TokenType[,] gameBoardMatrix = new TokenType[6, 7];
        gameBoardMatrix[0,0] = TokenType.Yellow;
        gameBoardMatrix[1,0] = TokenType.Yellow;
        gameBoardMatrix[2,0] = TokenType.Yellow;
        gameBoardMatrix[3,0] = TokenType.Yellow;
        IGameBoard gameBoard = new GameBoard(Mock.Of<IGameBoardViewer>(), gameBoardMatrix, 4);

        // Act
        bool result = gameBoard.IsInWinningState(1);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsInWinningState_WhenCalledAndUpwardDiagonal_ReturnsTrue()
    {
        // Arrange
        TokenType[,] gameBoardMatrix = new TokenType[3, 3];
        gameBoardMatrix[0,0] = TokenType.Yellow;
        gameBoardMatrix[1,1] = TokenType.Yellow;
        gameBoardMatrix[2,2] = TokenType.Yellow;
        IGameBoard gameBoard = new GameBoard(Mock.Of<IGameBoardViewer>(), gameBoardMatrix, 3);

        // Act
        bool result1 = gameBoard.IsInWinningState(1);
        bool result2 = gameBoard.IsInWinningState(2);
        bool result3 = gameBoard.IsInWinningState(3);

        // Assert
        Assert.IsTrue(result1);
        Assert.IsTrue(result2);
        Assert.IsTrue(result3);
    }

    [TestMethod]
    public void IsInWinningState_WhenCalledAndDownwardDiagonal_ReturnsTrue()
    {
        // Arrange
        TokenType[,] gameBoardMatrix = new TokenType[3, 3];
        gameBoardMatrix[0,2] = TokenType.Yellow;
        gameBoardMatrix[1,1] = TokenType.Yellow;
        gameBoardMatrix[2,0] = TokenType.Yellow;
        IGameBoard gameBoard = new GameBoard(Mock.Of<IGameBoardViewer>(), gameBoardMatrix, 3);

        // Act
        bool result1 = gameBoard.IsInWinningState(1);
        bool result2 = gameBoard.IsInWinningState(2);
        bool result3 = gameBoard.IsInWinningState(3);

        // Assert
        Assert.IsTrue(result1);
        Assert.IsTrue(result2);
        Assert.IsTrue(result3);
    }
}
