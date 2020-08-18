using BoxOfficeTestTask.Models.Shows;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoxOfficeTestTask.Repositories.EntityFramework.Configurations
{
    class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Show)
                .WithMany(x => x.Sessions)
                .HasForeignKey(x => x.ShowId);

            builder.HasMany(x => x.Reservations)
                .WithOne(x => x.Session)
                .HasForeignKey(x => x.SessionId);
        }
    }
}
