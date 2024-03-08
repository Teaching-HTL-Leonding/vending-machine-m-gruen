using System.ComponentModel;
using System.Linq.Expressions;

namespace VendingMachine;

public class CoinHandlingConsole
{
    public virtual void WriteLine(string s) => Console.WriteLine(s);
    public virtual string ReadLine() => Console.ReadLine()!;
    public int HandleCoins()
    {
        WriteLine("Price: ");
        var input = ReadLine();
        int price = (int)(double.Parse(input.Replace("E", "")) * 100);

        var coin = new Coin();
        var changeCalculator = new ChangeCalculator(price);

        while (!changeCalculator.IsEnoughMoney)
        {
            WriteLine("Coin: ");
            var text = ReadLine();

            try
            {
                var value = coin.Parse(text);
                changeCalculator.AddCoin(value);
                WriteLine($"Total: {changeCalculator.TotalAmount / 100d}E");
            }
            catch (Exception)
            {
                WriteLine("Invalid coin");
            }
        }

        WriteLine($"Change: {changeCalculator.GetChange() / 100d}E");
        return changeCalculator.GetChange();
    }
}