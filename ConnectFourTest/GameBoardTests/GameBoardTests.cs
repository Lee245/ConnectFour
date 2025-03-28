using ConnectFour;

namespace ConnectFourTest;

[TestClass]
public sealed class GameBoardTests
{
    [TestMethod]
    public void PlaceToken_WhenCalledAndThereIsSpace_ReturnsTrue()
    {
        // Arrange
        int[,] gameBoardMatrix = new int[1, 1];
        IGameBoard gameBoard = new GameBoard(new GameBoardViewer(), gameBoardMatrix);
        IPlayer player = new RandomComputerPlayer();

        // Act
        bool result = gameBoard.PlaceToken(player, 1);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void PlaceToken_WhenCalledAndThereIsNoSpace_ReturnsFalse()
    {
        // Arrange
        int[,] gameBoardMatrix = new int[1, 1];
        gameBoardMatrix[0,0] = 1;
        IGameBoard gameBoard = new GameBoard(new GameBoardViewer(), gameBoardMatrix);
        IPlayer player = new RandomComputerPlayer();

        // Act
        bool result = gameBoard.PlaceToken(player, 1);

        // Assert
        Assert.IsFalse(result);
    }
}
