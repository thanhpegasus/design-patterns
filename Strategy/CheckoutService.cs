namespace Strategy;

public class CheckoutService
{
    private readonly IPaymentStrategy _paymentStrategy;

    public CheckoutService(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void Checkout(decimal amount)
    {
        _paymentStrategy.ProcessPayment(amount);
    }
}