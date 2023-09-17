using System;
using System.Collections.Generic;

public class PaymentGateway
{
    private Dictionary<string, decimal> accounts = new Dictionary<string, decimal>();

    public void CreateAccount(string accountId, decimal balance = 0)
    {
        if (accounts.ContainsKey(accountId))
        {
            throw new Exception("Account already exists");
        }
        accounts[accountId] = balance;
    }

    public decimal CheckBalance(string accountId)
    {
        if (!accounts.ContainsKey(accountId))
        {
            throw new Exception("Account not found");
        }
        return accounts[accountId];
    }

    public bool ProcessPayment(string senderAccountId, string recipientAccountId, decimal amount)
    {
        if (!accounts.ContainsKey(senderAccountId))
        {
            throw new Exception("Sender account not found");
        }
        if (!accounts.ContainsKey(recipientAccountId))
        {
            throw new Exception("Recipient account not found");
        }
        if (amount <= 0)
        {
            throw new Exception("Invalid amount");
        }

        decimal senderBalance = accounts[senderAccountId];
        if (amount > senderBalance)
        {
            throw new Exception("Insufficient funds");
        }

        // Simulate deducting the amount from the sender
        accounts[senderAccountId] -= amount;

        // Simulate adding the amount to the recipient
        accounts[recipientAccountId] += amount;

        // Simulate a successful transaction
        return true;
    }
}

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
