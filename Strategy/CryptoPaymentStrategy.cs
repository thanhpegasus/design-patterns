namespace Strategy;

public class CryptoPaymentStrategy : IPaymentStrategy
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing cryptocurrency payment of {amount:C}");
    }
}