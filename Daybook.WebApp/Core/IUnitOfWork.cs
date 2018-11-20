using Daybook.WebApp.Repostories;

namespace Daybook.WebApp.Core
{
    public interface IUnitOfWork
    {
        IMemberRepository MemberRepository { get; }
        IPlanRepository PlanRepository { get; }

        void Complete();
    }
}
