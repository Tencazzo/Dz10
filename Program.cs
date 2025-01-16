using Dz10.Classes;
using Dz10.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz10
{
    class Program
    {
        static void Main(string[] args)
        {
            IBankAccountFactory factory = new BankAccountFactory();

            int account1 = CreateAccount(factory, 1000);
            int account2 = CreateAccount(factory, 500);

            CloseAccount(factory, account1);
            ManageAccount(factory, account2);

            Creator.Homework11_1();
        }

        static int CreateAccount(IBankAccountFactory factory, decimal initialBalance)
        {
            int accountNumber = factory.CreateAccount(initialBalance);
            Console.WriteLine($"Создан счет: {accountNumber} с начальным балансом: {initialBalance}");
            return accountNumber;
        }

        static void CloseAccount(IBankAccountFactory factory, int accountNumber)
        {
            if (factory.CloseAccount(accountNumber))
            {
                Console.WriteLine($"Счет {accountNumber} закрыт.");
            }
            else
            {
                Console.WriteLine($"Не удалось закрыть счет {accountNumber}.");
            }
        }

        static void ManageAccount(IBankAccountFactory factory, int accountNumber)
        {
            var account = factory.GetAccount(accountNumber);
            if (account != null)
            {
                DepositToAccount(account, 200);
                WithdrawFromAccount(account, 100);
            }
        }

        static void DepositToAccount(IBankAccount account, decimal amount)
        {
            account.Deposit(amount);
            Console.WriteLine($"Баланс после депозита: {account.Balance}");
        }

        static void WithdrawFromAccount(IBankAccount account, decimal amount)
        {
            try
            {
                account.Withdraw(amount);
                Console.WriteLine($"Баланс после снятия: {account.Balance}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}


