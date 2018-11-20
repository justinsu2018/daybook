using Daybook.Core.Models;
using Daybook.WebApp.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Daybook.WebApp.Repostories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly DaybookDbContext _context;

        public MemberRepository(DaybookDbContext context)
        {
            _context = context;
        }

        public IEnumerable<USRCurrency> GetCurrencies()
        {
            return _context.USRCurrencies.ToList();
        }

        public IEnumerable<Payee> GetPayees(string userid)
        {
            return _context.Payees
                .Where(p => p.UserID == userid)
                .ToList();
        }

        public Payee GetPayeeById(string payeeid)
        {
            var payee = _context.Payees.SingleOrDefault(p => p.PayeeID == payeeid);

            if (payee == null)
            {
                throw new KeyNotFoundException();
            }

            return payee;
        }

        public void AddPayee(Payee payee)
        {
            _context.Payees.Add(payee);
        }

        public void DeletePayee(string payeeid)
        {
            var lockPayee = _context.Payees.SingleOrDefault(p => p.PayeeID == payeeid);
            if (lockPayee == null)
            {
                throw new KeyNotFoundException();
            }

            _context.Payees.Remove(lockPayee);
        }

        public void UpdatePayee(Payee payee)
        {
            var orgPayee = _context.Payees
                .SingleOrDefault(p => p.PayeeID == payee.PayeeID);
            if (orgPayee == null)
            {
                throw new KeyNotFoundException();
            }

            orgPayee.PayeeName = payee.PayeeName;
        }
    }
}