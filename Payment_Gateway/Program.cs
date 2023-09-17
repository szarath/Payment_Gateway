using Payment_Gateway;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        PaymentGateway gateway = new PaymentGateway();

        // Create accounts for testing
        gateway.CreateAccount("user1", 1000);
        gateway.CreateAccount("user2", 500);

        try
        {
            // Check account balances
            Console.WriteLine("User1 Balance: $" + gateway.CheckBalance("user1"));
            Console.WriteLine("User2 Balance: $" + gateway.CheckBalance("user2"));

            // Process a payment (user1 pays user2)
            decimal paymentAmount = 200;
            if (gateway.ProcessPayment("user1", "user2", paymentAmount))
            {
                Console.WriteLine("Payment of $" + paymentAmount + " from user1 to user2 successful");
            }
            else
            {
                Console.WriteLine("Payment failed");
            }

            // Check updated balances
            Console.WriteLine("User1 Balance: $" + gateway.CheckBalance("user1"));
            Console.WriteLine("User2 Balance: $" + gateway.CheckBalance("user2"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
