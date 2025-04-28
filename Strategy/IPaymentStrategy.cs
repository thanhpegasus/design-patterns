namespace Strategy;

public interface IPaymentStrategy
{
    void ProcessPayment(decimal amount);
}
