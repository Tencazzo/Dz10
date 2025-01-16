using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timakov12.Interfaces
{
    public interface IBankAccount
    {
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
    }
}
