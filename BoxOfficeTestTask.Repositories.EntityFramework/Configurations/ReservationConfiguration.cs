using BoxOfficeTestTask.Models.Reservations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfficeTestTask.Repositories.EntityFramework.Configurations
{
    class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Session)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.SessionId);
        }
    }
}
