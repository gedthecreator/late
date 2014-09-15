using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Late.Domain
{
    public static class DepartureExtensions
    {
        public static bool IsCancelled(this IDeparture departure)
        {
            if (departure.GetType() == typeof(Cancelled))
            {
                return true;
            }
            return false;
        }

        public static bool IsUnknownDelay(this IDeparture departure)
        {
            if (departure.GetType() == typeof(UnknownDelay))
            {
                return true;
            }
            return false;
        }

        public static bool IsExpectedDelay(this IDeparture departure)
        {
            if (departure.GetType() == typeof(ExpectedDelay))
            {
                return true;
            }
            return false;
        }

        public static bool IsOnTime(this IDeparture departure)
        {
            if (departure.GetType() == typeof(OnTime))
            {
                return true;
            }
            return false;
        }
    }
}
