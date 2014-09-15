using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NodaTime;

namespace Late.Domain
{
    public class ExpectedDelay : UnknownDelay
    {
        public DepartureTime ExpectedDeparture { get; set; }
        private string ExpectedDepartureXPath = "./a/span/small";

        public ExpectedDelay(HtmlNode departure) : base (departure)
        {
            Console.WriteLine("Oh " + departure.InnerHtml);
            var time = departure.SelectSingleNode(ExpectedDepartureXPath).ChildNodes[0].InnerText;
            ExpectedDeparture = new DepartureTime(time);
        }
    }
}
