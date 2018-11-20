using Daybook.Core.Models;
using System.Collections.Generic;

namespace Daybook.Core.Repostories
{
    public interface IMemberRepository
    {
        void AddPayee(Payee payee);
        void DeletePayee(string payeeid);
        IEnumerable<Payee> GetPayees(string userid);
        void UpdatePayee(Payee payee);
    }
}