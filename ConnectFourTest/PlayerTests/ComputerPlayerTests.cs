﻿using ConnectFour;

namespace ConnectFourTest;

[TestClass]
public sealed class ComputerPlayerTests
{
    [TestMethod]
    public void Name_WhenCalled_ReturnsComputer()
    {
        // Arrange
        IPlayer computerPlayer = new ComputerPlayer();

        // Act
        string result = computerPlayer.Name;

        // Assert
        Assert.AreEqual("Computer", result);
    }

    [TestMethod]
    public void Number_WhenCalled_ReturnsComputer()
    {
        // Arrange
        IPlayer computerPlayer = new ComputerPlayer();

        // Act
        int result = computerPlayer.Number;

        // Assert
        Assert.AreEqual(2, result);
    }

    [TestMethod]
    public void GetNextMove_WhenCalled_ReturnsNumberInRange()
    {
        // Arrange
        IPlayer computerPlayer = new ComputerPlayer();

        // Act
        int result = computerPlayer.GetNextMove();

        // Assert
        Assert.IsTrue(result >= 0);
        Assert.IsTrue(result < Constants.NumberOfColumns);
    }
}
