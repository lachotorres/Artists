using AutoMapper;
using Artists.Core.Dtos;
using Artists.Core.Models;
using Artists.Persistence;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Artists.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
               
        public IEnumerable<NotificationDto> GetNewNotifications()
        {   
            var notifications = _unitOfWork.Notification.GetNewNotificationsWithArtist(User.Identity.GetUserId());
            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            
            var notifications = _unitOfWork.UserNotification.GetNewNotifications(User.Identity.GetUserId());

            foreach (var n in notifications)
            {
                n.Read();
            }
                        
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
