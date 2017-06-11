using Artists.Core.Models;
using System.Data.Entity;
namespace Artists.Persistence
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Crated for unit testing repositories.
    /// </remarks>
    public interface IApplicationDbContext
    {
        DbSet<Gig> Gigs { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Attendance> Attendances { get; set; }
        DbSet<Following> Followings { get; set; }
        DbSet<Notification> Notifications { get; set; }
        DbSet<UserNotification> UserNotifications { get; set; }
        IDbSet<ApplicationUser> Users { get; set; }

    }
}
