using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Late.Domain
{
    public class UnknownDelay : Departure
    {
        public new string StatusMessage { get { return "Delayed"; } }

        public UnknownDelay(HtmlNode departure) : base (departure)
        { }
    }
}
