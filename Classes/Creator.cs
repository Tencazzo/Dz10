using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dz10.Interfaces;

namespace Dz10.Classes
{
    internal static class Creator
    {
        private static readonly Dictionary<int, IBankAccount> accounts = new Dictionary<int, IBankAccount>();
        private static int nextAccountNumber = 1;

        public static IBankAccount CreateSavingsAccount(decimal initialBalance)
        {
            return AddAccount(new BankAccount(nextAccountNumber++, initialBalance, BankAccountType.Savings));
        }

        public static IBankAccount CreateCheckingAccount(decimal initialBalance)
        {
            return AddAccount(new BankAccount(nextAccountNumber++, initialBalance, BankAccountType.Checking));
        }

        public static IBankAccount CreateDepositAccount(decimal initialBalance)
        {
            return AddAccount(new BankAccount(nextAccountNumber++, initialBalance, BankAccountType.Deposit));
        }

        private static IBankAccount AddAccount(BankAccount account)
        {
            accounts[account.AccountNumber] = account;
            return account;
        }

        public static bool RemoveAccount(int accountNumber) => accounts.Remove(accountNumber);

        public static IBankAccount GetAccount(int accountNumber)
        {
            accounts.TryGetValue(accountNumber, out var account);
            return account;
        }

        public static void Homework11_1()
        {
            var savingsAccount = CreateSavingsAccount(1000);
            var checkingAccount = CreateCheckingAccount(500);
            var depositAccount = CreateDepositAccount(2000);

            Console.WriteLine($"Счет {savingsAccount.AccountNumber}: баланс {savingsAccount.Balance}");
            Console.WriteLine($"Счет {checkingAccount.AccountNumber}: баланс {checkingAccount.Balance}");
            Console.WriteLine($"Счет {depositAccount.AccountNumber}: баланс {depositAccount.Balance}");

            savingsAccount.Withdraw(200);
            checkingAccount.Deposit(150);

            if (RemoveAccount(savingsAccount.AccountNumber))
            {
                Console.WriteLine($"Счет {savingsAccount.AccountNumber} успешно удален.");
            }

            if (GetAccount(savingsAccount.AccountNumber) == null)
            {
                Console.WriteLine($"Счет {savingsAccount.AccountNumber} не найден.");
            }
        }
    }
}

