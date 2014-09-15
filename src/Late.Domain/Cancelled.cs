using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Late.Domain
{
    public class Cancelled : Departure
    {
        public new string StatusMessage { get { return "Cancelled"; } }

        public Cancelled(HtmlNode departure) : base (departure)
        {

        }
    }
}
