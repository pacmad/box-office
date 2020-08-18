using BoxOfficeTestTask.Models.Reservations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoxOfficeTestTask.Repositories.EntityFramework.Configurations
{
    class UserReservationsConfiguration : IEntityTypeConfiguration<UserReservations>
    {
        public void Configure(EntityTypeBuilder<UserReservations> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.HasOne(x => x.Reservation);
        }
    }
}
