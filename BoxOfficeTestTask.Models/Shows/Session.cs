using BoxOfficeTestTask.Models.Reservations;
using System;
using System.Collections.Generic;

namespace BoxOfficeTestTask.Models.Shows
{
    public class Session
    {
        public long Id { get; set; }

        public int ShowId { get; set; }

        public virtual Show Show { get; set; }

        public DateTime StartTime { get; set; }

        public int MaxTickets { get; set; }

        public virtual IEnumerable<Reservation> Reservations { get; set; }
    }
}