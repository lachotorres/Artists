using FluentAssertions;
using Artists.Controllers.Api;
using Artists.Core.Dtos;
using Artists.Core.Models;
using Artists.Core.Repositories;
using Artists.Persistence;
using Artists.Test.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Http.Results;

namespace Artists.Test.Controllers.Api
{
    [TestClass]
    public class AttendancesControllerTest
    {
        private AttendancesController _controller;
        private Mock<IAttendanceRepository> _mockRepository;
        private string _userId;

        [TestInitialize]
        public void TestInitialize()
        {

            _mockRepository = new Mock<IAttendanceRepository>();
            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.Setup(u => u.Attendance).Returns(_mockRepository.Object);
            _controller = new AttendancesController(mockUoW.Object);
            _controller.MockCurrentUser("1", "lbaro@scbacode.com");
            _userId = "1";

        }

        [TestMethod]
        public void Attend_NoAttendanceGivenExists_ShouldReturnNotFound()
        {
            var result = _controller.Attend(null);
            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void Attend_AttendanceAlreadyExists_ShouldReturnBadRequestErrorMessageResult()
        {
            var attendance = new Attendance();
            var attendacneDto = new AttendanceDto
            {
                GigId = 1
            };
            _mockRepository.Setup(a=> a.GetAttendance(1,"1")).Returns(attendance);
            var result = _controller.Attend(attendacneDto);
            result.Should().BeOfType<BadRequestErrorMessageResult>();
        }

        [TestMethod]
        public void Attend_ValidRequest_ShouldReturnOk()
        {   
            var attendacneDto = new AttendanceDto
            {
                GigId = 1
            };
            _mockRepository.Setup(a => a.GetAttendance(attendacneDto.GigId, "1")).Returns((Attendance)null);
            var result = _controller.Attend(attendacneDto);
            result.Should().BeOfType<OkResult>();
        }
        
    }
}
