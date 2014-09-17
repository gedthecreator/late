using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using System.Text.RegularExpressions;

namespace Late.Domain
{
    public class DepartureTime
    {
        private LocalTime Time { get; set; }

        private string TimeRegex = @"([01]?[0-9]|2[0-3]):[0-5][0-9]";
        public int Hour { get { return Time.Hour; } }
        public int Minute { get { return Time.Minute; } }

        public DepartureTime(string time)
        {
            var regex = new Regex(TimeRegex);
            if (!regex.IsMatch(time))
            {
                throw new ArgumentException("Incorrect format - should be hh:mm");
            }
            
            var hour = int.Parse(time.Split(':')[0]);
            var min = int.Parse(time.Split(':')[1]);
            Time = new LocalTime(hour, min);
        }

        public override string ToString()
        {
            return string.Format("{0:D2}:{1:D2}", Hour, Minute);
        }
    }
}
