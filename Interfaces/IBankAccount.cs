using Dz10.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz10.Interfaces
{
    public interface IBankAccount
    {
        int AccountNumber { get; }
        decimal Balance { get; }
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
    }
}

