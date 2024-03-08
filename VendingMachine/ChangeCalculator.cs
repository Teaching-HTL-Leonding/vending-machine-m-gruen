namespace VendingMachine;

public class ChangeCalculator(int productPrice)
{
    public int ProductPrice { get; set; } = productPrice;
    public int TotalAmount { get; private set; } = 0;
    public bool IsEnoughMoney => TotalAmount >= ProductPrice;
    public int AddCoin(int coin) => checked(TotalAmount += coin);

    public int GetChange()
    {
        if (!IsEnoughMoney) { throw new InvalidOperationException("Not enough money."); }

        return checked(TotalAmount - ProductPrice);
    }
}