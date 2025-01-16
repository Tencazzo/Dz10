using Dz10.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz10.Classes
{
    public class BankAccount : IBankAccount
    {
        public int AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public BankAccountType AccountType { get; private set; }

        public event Action<decimal> DepositOccurred;
        public event Action<decimal> WithdrawalOccurred;

        internal BankAccount(int accountNumber, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance >= 0 ? initialBalance : throw new ArgumentOutOfRangeException(nameof(initialBalance), "Начальный баланс не может быть отрицательным.");
        }

        internal BankAccount(int accountNumber, decimal initialBalance, BankAccountType accountType) : this(accountNumber, initialBalance)
        {
            AccountType = accountType;
        }

        public void Deposit(decimal amount)
        {
            ValidateAmount(amount);
            Balance += amount;
            DepositOccurred?.Invoke(amount);
        }

        public void Withdraw(decimal amount)
        {
            ValidateAmount(amount);
            EnsureSufficientFunds(amount);
            Balance -= amount;
            WithdrawalOccurred?.Invoke(amount);
        }

        private static void ValidateAmount(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Сумма должна быть положительной.", nameof(amount));
            }
        }

        private void EnsureSufficientFunds(decimal amount)
        {
            if (amount > Balance)
            {
                throw new InvalidOperationException("Недостаточно средств для выполнения операции.");
            }
        }
    }
}
