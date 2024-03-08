namespace VendingMachine.Tests;

using VendingMachine;

public class CoinTests
{
    [Fact]
    public void Parse_WhenInputIsCorrect_ShouldReturnCorrectValue()
    {
        // Arrange
        var coin = new Coin();
        string[] input = ["2E", "1E", "50C", "20C", "10C"];
        
        // Act
        var result = input.Select(coin.Parse).ToArray();
        
        // Assert
        Assert.Equal([200, 100, 50, 20, 10], result);
    }

    [Fact]
    public void Parse_WhenInputIsIncorrect_ShouldThrowFormatException()
    {
        // Arrange, Act
        var coin = new Coin();
        string[] input = ["3E", "1D", "50", "20Cents"];
        
        // Assert
        foreach (var i in input)
        {
            Assert.Throws<FormatException>(() => coin.Parse(i));
        }
    }
}