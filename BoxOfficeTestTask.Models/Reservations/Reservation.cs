using BoxOfficeTestTask.Models.Shows;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfficeTestTask.Models.Reservations
{
    public class Reservation
    {
        public long Id { get; set; }

        public int UserId { get; set; }

        public long SessionId { get; set; }

        public virtual Session Session { get; set; }

        public int TicketAmount { get; set; }
    }
}
