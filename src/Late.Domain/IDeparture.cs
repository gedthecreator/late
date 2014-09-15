using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Late.Domain
{
    public interface IDeparture
    {
        DepartureTime TimetabledDeparture { get; set; }
        string StatusMessage { get; }
        string Platform { get; set; }
    }
}
