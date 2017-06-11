using Artists.Persistence;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace Artists.Controllers
{
    public class FolloweesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FolloweesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {            
            var artists = _unitOfWork.Following.GetFollowees(User.Identity.GetUserId());
            return View(artists);
        }
    }
}