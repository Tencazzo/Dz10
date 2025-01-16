using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timakov12.Interfaces;

namespace Timakov12.Classes
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
            Balance = initialBalance >= 0
                ? initialBalance
                : throw new ArgumentOutOfRangeException(nameof(initialBalance), "Начальный баланс не может быть отрицательным.");
        }

        internal BankAccount(int accountNumber, decimal initialBalance, BankAccountType accountType)
            : this(accountNumber, initialBalance)
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

        public override bool Equals(object obj)
        {
            if (obj is BankAccount other)
            {
                return AccountNumber == other.AccountNumber &&
                       Balance == other.Balance &&
                       AccountType == other.AccountType;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AccountNumber, Balance, AccountType);
        }

        public static bool operator ==(BankAccount left, BankAccount right)
        {
            if (left is null && right is null) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }

        public static bool operator !=(BankAccount left, BankAccount right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"Счет №{AccountNumber}, Баланс: {Balance:C}, Тип счета: {AccountType}";
        }
    }
}
