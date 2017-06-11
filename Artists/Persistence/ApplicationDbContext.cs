using Artists.Core.Models;
using Artists.Persistence.EntityConfigurations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Artists.Persistence
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>    
    /// This class implements IApplicationDbContext to enable unit testing on repositories.
    /// </remarks>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Following> Followings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <remarks>
        /// Utlizamos fluent API sobreescribiendo este metodo
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GigConfiguration());
            modelBuilder.Configurations.Add(new AttendanceConfiguration());
            modelBuilder.Configurations.Add(new FollowingConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());
            modelBuilder.Configurations.Add(new NotificationConfiguration());
            modelBuilder.Configurations.Add(new UserNotificationConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
                      
            base.OnModelCreating(modelBuilder);//esta linea debe ir
        }
    }
}
