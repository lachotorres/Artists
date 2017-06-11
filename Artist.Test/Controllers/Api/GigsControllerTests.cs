using FluentAssertions;
using Artists.Controllers.Api;
using Artists.Core.Models;
using Artists.Core.Repositories;
using Artists.Persistence;
using Artists.Test.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Http.Results;

namespace Artists.Test.Controllers.Api
{
    /// <summary>
    /// Summary description for GigsControllerTest
    /// </summary>
    [TestClass]
    public class GigsControllerTests
    {
        private GigsController _controller;
        private Mock<IGigRepository> _mockRepository;
        private string _userId;

        [TestInitialize]
        public void TestInitialize()
        {

            _mockRepository = new Mock<IGigRepository>();
            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.Setup(u => u.Gigs).Returns(_mockRepository.Object);
            _controller = new GigsController(mockUoW.Object);
            _controller.MockCurrentUser("1", "lbaro@scbacode.com");
            _userId = "1";

        }
        
        [TestMethod]
        public void Cancel_NoGigWithGivenIdExists_ShouldReturnNotFound()
        {
            var result = _controller.Cancel(1);
            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void Cancel_GigIsCanceled_ShouldReurnNotFound()
        {
            var gig = new Gig();
            gig.Cancel();
            _mockRepository.Setup(r => r.GetGigWithAttendees(1)).Returns(gig);

            var result = _controller.Cancel(1);
            result.Should().BeOfType<NotFoundResult>();
            
        }

        [TestMethod]
        public void Cancel_UserCancelingAnotherUsersGig_ShouldReturnUnauthorized()
        {
            var gig = new Gig { ArtistId  = _userId + "-" };
            _mockRepository.Setup(r => r.GetGigWithAttendees(1)).Returns(gig);
            var result = _controller.Cancel(1);
            result.Should().BeOfType<UnauthorizedResult>();
            
        }

        [TestMethod]
        public void Cancel_ValidRequest_ShouldReturnOk()
        {
            var gig = new Gig { ArtistId = _userId};
            _mockRepository.Setup(r => r.GetGigWithAttendees(1)).Returns(gig);
            var result = _controller.Cancel(1);
            result.Should().BeOfType<OkResult>();
        }
    }
}
