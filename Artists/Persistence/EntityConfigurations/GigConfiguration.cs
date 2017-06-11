using Artists.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Artists.Persistence.EntityConfigurations
{
    public class GigConfiguration: EntityTypeConfiguration<Gig>
    {
        public GigConfiguration()
        {
            
            Property(g => g.ArtistId)
            .IsRequired();

            Property(g => g.GenreId)
           .IsRequired();

            Property(g => g.Venue)
            .IsRequired()
            .HasMaxLength(255);

            /* 
                //removes delete-cascade between Attendance and  Gig
                modelBuilder.Entity<Attendance>()
                .HasRequired(a => a.Gig)
                .WithMany(g => g.Attendances)
                .WillCascadeOnDelete(false); 
            */

            HasMany(g => g.Attendances)
                .WithRequired(a => a.Gig)
                .WillCascadeOnDelete(false);

        }
    }
}