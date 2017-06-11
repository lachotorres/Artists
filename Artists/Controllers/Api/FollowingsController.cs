using Artists.Core.Dtos;
using Artists.Core.Models;
using Artists.Persistence;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace Artists.Controllers.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public FollowingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();
            if (_unitOfWork.Following.GetFollowing(userId, dto.FolloweeId)!=null)
                return BadRequest("Following already exists.");

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };

            _unitOfWork.Following.Add(following);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Unfollow(string Id)
        {
            var userId = User.Identity.GetUserId();
            var following = _unitOfWork.Following.GetFollowing(userId, Id);

            if (following == null)
                return NotFound();

            _unitOfWork.Following.Remove(following);
            _unitOfWork.Complete();
            return Ok(Id);
        }
    }
}
