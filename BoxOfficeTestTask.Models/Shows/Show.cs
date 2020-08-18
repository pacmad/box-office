using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfficeTestTask.Models.Shows
{
    public class Show
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public short DurationInMinutes { get; set; }

        public byte MinAge { get; set; }

        public virtual IEnumerable<Session> Sessions { get; set; }
    }
}
