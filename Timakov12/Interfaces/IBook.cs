using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timakov12.Interfaces
{
    public interface IBook : IComparable<IBook>
    {
        string Title { get; }
        string Author { get; }
        string Publisher { get; }
        int Year { get; }
        string ISBN { get; }
    }
}
