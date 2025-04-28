# Strategy Pattern

## Step 1: Example Problem
It’s used when you want to swap behaviors at runtime, and it's all about flexibility and composability. Imagine you're building a checkout service that users can pay with different methods:

* Credit Card
* Paypal
* Cryptocurrency

Let's take a look at the implementation below and find out the problems
```csharp
public class CheckoutService
{
    public void ProcessPayment(string method, decimal amount)
    {
        if (method == "CreditCard")
        {
            Console.WriteLine($"Charging {amount} to credit card.");
        }
        else if (method == "PayPal")
        {
            Console.WriteLine($"Sending {amount} via PayPal.");
        }
        else if (method == "Crypto")
        {
            Console.WriteLine($"Processing {amount} in crypto.");
        }
    }
}
```
### ✅ Violates Open/Closed Principle:

* The CheckoutService class is not closed for modification — every time a new payment method comes, you must edit it.
* That editing risks breaking working payment methods (like CreditCard or PayPal) even if you only intend to add a new one.

### ✅ Hard to Test and Maintain:

* Every method is mixed in one place, making unit testing messy.
* Adding, changing, or removing payment logic becomes a risky operation.

## Step 2: Solution + Basic Implementation

Instead of one giant if-else block, we'll encapsulate each payment method into its own class.

👉 Strategy Pattern lets you:

* Define a family of algorithms (payment strategies),

* Encapsulate them separately,

* Make them interchangeable inside CheckoutService.

🔍 Strategy Interface
```csharp
public interface IPaymentStrategy
{
    void ProcessPayment(decimal amount);
}
```

⌨️ Different Strategies
```csharp
public class CreditCardPaymentStrategy : IPaymentStrategy
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing credit card payment of {amount:C}");
    }
}

public class PayPalPaymentStrategy : IPaymentStrategy
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing PayPal payment of {amount:C}");
    }
}  

public class CryptoPaymentStrategy : IPaymentStrategy
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing cryptocurrency payment of {amount:C}");
    }
}
```

📝Refactored CheckoutService
```csharp
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
```

🧑‍💻Example usage
```csharp
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
```

## Step 3: Definition + UML Diagram

### 📘 Definition
> Strategy Pattern defines a family of algorithms, encapsulates each one, and makes them interchangeable. Strategy lets the algorithm vary independently from the clients that use it.

In simple words: "Separate different behaviors into their own classes, and allow choosing them dynamically."

### 🎯 Simple UML Diagram for Strategy Pattern
```lua
+------------------+     uses      +--------------------+
|  CheckoutService |  -----------> |    IPaymentStrategy |
+------------------+                +--------------------+
         |
         |
   +-----------------------------------------------+
   |                     |                        |
+------------------+ +------------------+ +------------------+
| CreditCardPayment| | PayPalPayment     | | CryptoPayment     |
+------------------+ +------------------+ +------------------+
```

* CheckoutService depends on IPaymentStrategy.
* CreditCardPaymentStrategy, PayPalPaymentStrategy, CryptoPaymentStrategy all implement IPaymentStrategy.

## Step 4: Real Problem + Implementation
Let’s now work through a small real-world implementation you write yourself.
Here’s your challenge 👇

### 💼 Real-World Exercise
You're designing a report generator for a system that supports different types of financial records:
* Invoice
* Receipt
* Refund

Each record needs to support:
* Export to PDF
* Export to CSV

Implement this using the **Strategy Pattern**.

💡HINT: the implementation is in the Strategy.Exercise project

## Step 5: Pros & Cons

### 👍Pros of Strategy Pattern
* Open for extension, closed for modification (✔️ Open/Closed Principle)
* Runtime flexibility — easily switch or decide strategy based on user input, settings, or environment.
* Single Responsibility Principle (SRP) — each strategy only focuses on how to do one thing.
* Unit-testable — strategies can be tested independently, no big if-else logic to test.
* Easier maintenance — adding/changing behavior doesn’t risk breaking others.

### 👎Cons of Strategy Pattern
* More classes — every new strategy is a new class (small overhead if too many).
* Client must know about strategies — the caller must pick the right strategy somehow.

## Step 6: When TO and When NOT TO use Strategy Pattern

### 🎯 When to Use Strategy Pattern
* When you have multiple ways of doing the same task (payment, validation, compression, sorting).
* When you want to switch behavior at runtime.
* When you want to follow SOLID Principles — especially Single Responsibility and Open/Closed.
* When you want to avoid big if-else or switch statements.

### ⚠️ When NOT to Use Strategy Pattern
* If behaviors don't change often (YAGNI: You Aren't Gonna Need It — don't overengineer).
* If there are only 2–3 simple cases that won't grow.
* If choosing the strategy dynamically is unnecessary (e.g., if it's always the same behavior).
* If performance is critical and the extra indirection (interfaces, dynamic dispatch) adds measurable overhead.