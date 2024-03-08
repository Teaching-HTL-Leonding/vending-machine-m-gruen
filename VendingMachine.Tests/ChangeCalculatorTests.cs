namespace VendingMachine.Tests;

using VendingMachine;

public class ChangeCalculatorTests
{
    [Fact]
    public void TotalAmount_IsZero_WhenCreated()
    {
        // Arrange, Act
        var changeCalculator = new ChangeCalculator(100);

        // Assert
        Assert.Equal(0, changeCalculator.TotalAmount);
    }

    [Fact]
    public void TotalAmount_IsCorrect_AfterAddingCoins()
    {
        // Arrange
        var changeCalculator = new ChangeCalculator(100);

        // Act
        changeCalculator.AddCoin(50);
        changeCalculator.AddCoin(20);
        changeCalculator.AddCoin(20);
        changeCalculator.AddCoin(10);

        // Assert
        Assert.Equal(100, changeCalculator.TotalAmount);
    }

    [Fact]
    public void AddCoin_ThrowsOverflowException_WhenTotalAmountExceedsIntMaxValue()
    {
        // Arrange
        var changeCalculator = new ChangeCalculator(100);

        // Act
        changeCalculator.AddCoin(int.MaxValue);

        // Assert
        Assert.Throws<OverflowException>(() => changeCalculator.AddCoin(1));
    }

    [Fact]
    public void IsEnoughMoney_ReturnsTrue_WhenTotalAmountIsEqualOrGreaterThanProductPrice()
    {
        // Arrange
        var changeCalculator = new ChangeCalculator(100);

        // Act
        changeCalculator.AddCoin(100);
        var result = changeCalculator.IsEnoughMoney;

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsEnoughMoney_ReturnsFalse_WhenTotalAmountIsLessThanProductPrice()
    {
        // Arrange
        var changeCalculator = new ChangeCalculator(100);

        // Act
        changeCalculator.AddCoin(50);
        var result = changeCalculator.IsEnoughMoney;

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void GetChange_ReturnsCorrectValue()
    {
        // Arrange
        var changeCalculator = new ChangeCalculator(100);

        // Act
        changeCalculator.AddCoin(150);
        var result = changeCalculator.GetChange();

        // Assert
        Assert.Equal(50, result);
    }

    [Fact]
    public void GetChange_ThrowsInvalidOperationException_WhenTotalAmountIsLessThanProductPrice()
    {
        // Arrange
        var changeCalculator = new ChangeCalculator(100);

        // Act
        changeCalculator.AddCoin(50);

        // Assert
        Assert.Throws<InvalidOperationException>(() => changeCalculator.GetChange());
    }
}
