using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxOfficeTestTask.Extensions
{
    public static class DateTimeExtensions
    {
        public static long ToUnixEpochTime(this DateTime datetime)
        {
            return (long)(datetime - new DateTime(1970, 1, 1)).TotalSeconds;
        }
    }
}
