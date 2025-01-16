using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dz10.Interfaces;

namespace Dz10.Classes
{
    public class BankAccountFactory : IBankAccountFactory
    {
        private readonly Dictionary<int, IBankAccount> accounts = new Dictionary<int, IBankAccount>();
        private int nextAccountNumber = 1;

        public int CreateAccount(decimal initialBalance)
        {
            ValidateInitialBalance(initialBalance);
            var account = new BankAccount(nextAccountNumber, initialBalance);
            accounts[nextAccountNumber] = account;
            return nextAccountNumber++;
        }

        public bool CloseAccount(int accountNumber)
        {
            if (!accounts.ContainsKey(accountNumber))
            {
                throw new KeyNotFoundException($"Счет с номером {accountNumber} не найден.");
            }
            return accounts.Remove(accountNumber);
        }

        public IBankAccount GetAccount(int accountNumber)
        {
            if (!accounts.TryGetValue(accountNumber, out var account))
            {
                throw new KeyNotFoundException($"Счет с номером {accountNumber} не найден.");
            }
            return account;
        }

        public IEnumerable<IBankAccount> GetAllAccounts()
        {
            return accounts.Values.ToList();
        }

        public string GetAccountInfo(int accountNumber)
        {
            var account = GetAccount(accountNumber);
            return account.ToString();
        }

        private static void ValidateInitialBalance(decimal initialBalance)
        {
            if (initialBalance < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(initialBalance), "Начальный баланс не может быть отрицательным.");
            }
        }
    }
}
