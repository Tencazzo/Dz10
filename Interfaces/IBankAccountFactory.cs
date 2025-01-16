using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz10.Interfaces
{
    public interface IBankAccountFactory
    {
        int CreateAccount(decimal initialBalance);
        bool CloseAccount(int accountNumber);
        IBankAccount GetAccount(int accountNumber);
    }
}
