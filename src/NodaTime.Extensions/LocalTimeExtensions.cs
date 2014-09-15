using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodaTime.Extensions
{
    public static class LocalTimeExtensions
    {
        public static LocalTime FromHourMinuteString(this string input)
        {
            var hour = int.Parse(input.Substring(0, 2));
            var minute = int.Parse(input.Substring(2, 2));
            return new LocalTime(hour, minute);
        }
    }
}
