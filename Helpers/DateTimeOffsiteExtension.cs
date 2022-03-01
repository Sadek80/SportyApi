using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Helpers
{
    public static class DateTimeOffsiteExtension
    {
        public static string GetDateFormatted(this DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.ToString("MMM dd, yyyy");
        }
    }
}
