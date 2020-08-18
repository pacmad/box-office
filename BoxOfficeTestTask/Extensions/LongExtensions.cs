using System;

namespace BoxOfficeTestTask.Extensions
{
    public static class LongExtensions
    {
        public static DateTime FromUtcToLocalTime(this long seconds)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(seconds).ToLocalTime();
        }

        public static DateTime? FromUtcToLocalTime(this long? seconds)
        {
            if (seconds.HasValue)
            {
                return seconds.Value.FromUtcToLocalTime();
            }

            return null;
        }
    }
}
