using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment_Gateway
{
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
}
