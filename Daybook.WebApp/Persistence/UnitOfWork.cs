using Daybook.WebApp.Core;
using Daybook.WebApp.Repostories;

namespace Daybook.WebApp.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DaybookDbContext _context;

        public IMemberRepository MemberRepository { get; private set; }
        public IPlanRepository PlanRepository { get; private set; }

        public UnitOfWork(DaybookDbContext context)
        {
            _context = context;

            MemberRepository = new MemberRepository(context);
            PlanRepository = new PlanRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}