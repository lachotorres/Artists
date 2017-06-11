using Artists.Core.Models;
using System.Collections.Generic;

namespace Artists.Core.Repositories
{
    public interface IUserNotificationRepository
    {
        IEnumerable<UserNotification> GetNewNotifications(string userId);
    }
}
