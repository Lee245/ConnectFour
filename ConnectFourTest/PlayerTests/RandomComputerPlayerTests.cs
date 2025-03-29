using ConnectFour;

namespace ConnectFourTest;

[TestClass]
public sealed class RandomComputerPlayerTests
{
    [TestMethod]
    public void Name_WhenCalled_ReturnsComputer()
    {
        // Arrange
        IPlayer computerPlayer = new RandomComputerPlayer(2);

        // Act
        string result = computerPlayer.Name;

        // Assert
        Assert.AreEqual("RandomComputer", result);
    }

    [TestMethod]
    public void TokenType_WhenCalled_ReturnsComputer()
    {
        // Arrange
        IPlayer computerPlayer = new RandomComputerPlayer(2);

        // Act
        TokenType tokenType = computerPlayer.TokenType;

        // Assert
        Assert.AreEqual(TokenType.Red, tokenType);
    }

    [TestMethod]
    public void GetNextMove_WhenCalled_ReturnsNumberInRange()
    {
        // Arrange
        IPlayer computerPlayer = new RandomComputerPlayer(2);

        // Act
        int result = computerPlayer.GetNextMove();

        // Assert
        Assert.IsTrue(result >= 0);
        Assert.IsTrue(result < 2);
    }
}
