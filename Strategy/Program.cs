namespace Strategy;

class Program
{
    private static readonly Dictionary<string, IPaymentStrategy> _paymentStrategies = new Dictionary<string, IPaymentStrategy>(){
        { "creditcard", new CreditCardPaymentStrategy() },
        { "paypal", new PayPalPaymentStrategy() },
        { "crypto", new CryptoPaymentStrategy() }
    };

    static void Main(string[] args)
    {
        var paymentMethod = "creditcard"; // This could be dynamically set based on user input
        if (!_paymentStrategies.ContainsKey(paymentMethod))
        {
            Console.WriteLine("Invalid payment method selected.");
            return;
        }
        var paymentStrategy = _paymentStrategies[paymentMethod];

        // Create a checkout service with a specific payment strategy
        var checkoutService = new CheckoutService(paymentStrategy);

        // Process a payment
        checkoutService.Checkout(100.00m); // Example amount
    }
}