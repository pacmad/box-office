using System;

namespace BoxOfficeTestTask.Settings
{
    public class JwtSettings
    {
        public string Secret { get; set; }

        public int LifetimeInMinutes { get; set; }
    }
}
