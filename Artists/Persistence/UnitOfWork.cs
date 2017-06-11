using Artists.Core;
using Artists.Core.Repositories;
using Artists.Persistence.Repositories;

namespace Artists.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IGigRepository Gigs { get; private set; }
        public IAttendanceRepository Attendance { get; private set; }        
        public IFollowingRepository Following { get; private set; }
        public IGenreRepository Genre { get; private set; }
        public INotificationRepository Notification { get; private set; }
        public IUserNotificationRepository UserNotification { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Gigs = new GigRepository(context);
            Attendance = new AttendanceRepository(context);
            Following = new FollowingRepository(context);
            Genre = new GenreRepository(context);
            Notification = new NotificationRepository(context);
            UserNotification = new UserNotificationRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}