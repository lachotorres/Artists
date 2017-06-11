using Artists.Core.Models;
using System.Collections.Generic;

namespace Artists.Core.Repositories
{
    public interface INotificationRepository
    {   
        IEnumerable<Notification> GetNewNotificationsWithArtist(string userId);
    }
}
