using Artists.Core.Repositories;

namespace Artists.Persistence
{
    public interface IUnitOfWork
    {
        IGigRepository Gigs { get;  }
        IAttendanceRepository Attendance { get;  }
        IFollowingRepository Following { get; }
        IGenreRepository Genre { get; }
        INotificationRepository Notification { get; }
        IUserNotificationRepository UserNotification { get; }
        void Complete();
    }
}
