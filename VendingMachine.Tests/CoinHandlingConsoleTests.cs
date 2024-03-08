namespace VendingMachine.Tests;

using VendingMachine;

public class CoinHandlingConsoleTests
{
    [Fact]
    public void HandleCoins_EntersValidCoins_ReachesTheProductPriceExactlyAndGetsNoChange()
    {
        // Arrange
        var chcm = new CoinHandlingConsoleMock(["1,5E", "1E", "50C"]);

        // Act
        var result = chcm.HandleCoins();

        // Assert
        Assert.Equal(0, result);
        Assert.Equal([
            "Price: ",
            "Coin: ",
            "Total: 1E",
            "Coin: ",
            "Total: 1,5E",
            "Change: 0E"
        ], chcm.Outputs);
    }

    [Fact]
    public void HandleCoins_EntersValidCoins_ReachesTheProductPriceAndGetsChange()
    {
        // Arrange
        var chcm = new CoinHandlingConsoleMock(["1,5E", "1E", "1E"]);

        // Act
        var result = chcm.HandleCoins();

        // Assert
        Assert.Equal(50, result);
        Assert.Equal([
            "Price: ",
            "Coin: ",
            "Total: 1E",
            "Coin: ",
            "Total: 2E",
            "Change: 0,5E"
        ], chcm.Outputs);
    }

    [Fact]
    public void HandleCoins_EntersInvalidCoin_ShouldPrintError()
    {
        // Arrange
        var chcm = new CoinHandlingConsoleMock(["1,5E", "Blablabla", "1E", "1E"]);

        // Act
        var result = chcm.HandleCoins();

        // Assert
        Assert.Equal(50, result);
        Assert.Equal([
            "Price: ",
            "Coin: ",
            "Invalid coin",
            "Coin: ",
            "Total: 1E",
            "Coin: ",
            "Total: 2E",
            "Change: 0,5E"
        ], chcm.Outputs);
    }
}