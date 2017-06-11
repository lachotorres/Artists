using Artists.Core.Models;
using System.Data.Entity.ModelConfiguration;


namespace Artists.Persistence.EntityConfigurations
{
    public class NotificationConfiguration: EntityTypeConfiguration<Notification>
    {
        public NotificationConfiguration()
        {
            HasRequired(n => n.Gig);
        }
    }
}