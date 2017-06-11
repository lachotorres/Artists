using Artists.Core.Dtos;
using Artists.Core.Models;
using Artists.Persistence;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace Artists.Controllers.Api
{

    [Authorize]
    public class AttendancesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public AttendancesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            if (dto == null)
                return NotFound();

            var userId = User.Identity.GetUserId();

            if (_unitOfWork.Attendance.GetAttendance(dto.GigId, userId) != null)
                return BadRequest("The attendance already exists");

            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };

            _unitOfWork.Attendance.Add(attendance);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteAttendance(int Id)
        {
            var userId = User.Identity.GetUserId();

            var attendance = _unitOfWork.Attendance.GetAttendance(Id, userId);

            if (attendance == null)
                return NotFound();

            _unitOfWork.Attendance.Remove(attendance);
            _unitOfWork.Complete();
            return Ok(Id);

        }
    }
}
