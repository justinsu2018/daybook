using Daybook.Core.Models;
using System.Collections.Generic;

namespace Daybook.WebApp.Repostories
{
    public interface IMemberRepository
    {
        Payee GetPayeeById(string payeeid);
        void AddPayee(Payee payee);
        void DeletePayee(string payeeid);
        IEnumerable<Payee> GetPayees(string userid);
        IEnumerable<USRCurrency> GetCurrencies();
        void UpdatePayee(Payee payee);
    }
}