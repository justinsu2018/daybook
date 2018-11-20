using Daybook.WebApp.Core;
using Daybook.WebApp.Persistence;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace Daybook.WebApp.Controllers.Api
{
    public class MemberController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public MemberController()
        {
            _unitOfWork = new UnitOfWork(new DaybookDbContext());
        }

        public MemberController(IUnitOfWork _uow)
        {
            _unitOfWork = _uow;
        }

        [HttpDelete]
        public IHttpActionResult DeletePayee(string payeeid)
        {
            var userid = User.Identity.GetUserId();
            var payee = _unitOfWork.MemberRepository.GetPayeeById(KeyGenerator.Decode(payeeid));

            //if (payee.UserID != userid)
            //    return Unauthorized();

            if (payee == null)
                return NotFound();

            _unitOfWork.MemberRepository.DeletePayee(KeyGenerator.Decode(payeeid));

            _unitOfWork.Complete();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetPayee()
        {
            var payees = _unitOfWork.MemberRepository.GetPayees(User.Identity.GetUserId());

            return Ok(Json(payees));
        }
    }
}
