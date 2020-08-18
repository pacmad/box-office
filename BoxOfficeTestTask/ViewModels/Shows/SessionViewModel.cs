using System;
using System.ComponentModel.DataAnnotations;

namespace BoxOfficeTestTask.ViewModels.Shows
{
    public class SessionViewModel
    {
        public long Id { get; set; }

        public int ShowId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public int MaxTickets { get; set; }
    }
}
