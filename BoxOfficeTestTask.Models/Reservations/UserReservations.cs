namespace BoxOfficeTestTask.Models.Reservations
{
    public class UserReservations
    {
        public long Id { get; set; }

        public int UserId { get; set; }

        public long ReservationId { get; set; }

        public virtual Reservation Reservation { get; set; }
    }
}
