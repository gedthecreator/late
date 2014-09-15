using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;

namespace Late.Domain
{
    public class NodaTimeExtension
    {
        public LocalTime Time { get; set; }

        public override string ToString()
        {
 	        return string.Format("{0}:{1}", Time.Hour, Time.Minute);
        }
    }
}
