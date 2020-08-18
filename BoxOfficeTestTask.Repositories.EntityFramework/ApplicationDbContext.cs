using BoxOfficeTestTask.Models.Reservations;
using BoxOfficeTestTask.Models.Shows;
using Microsoft.EntityFrameworkCore;

namespace BoxOfficeTestTask.Repositories.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Show> Shows { get; set; }
        
        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<UserReservations> UserReservations { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            
        }
    }
}
