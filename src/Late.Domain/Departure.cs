using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NodaTime;
using System.Text.RegularExpressions;

namespace Late.Domain
{
    public class Departure : IDeparture
    {
        public DepartureTime TimetabledDeparture { get; set; }
        public string StatusMessage { get { throw new NotImplementedException(); } }
        
        public string Platform { get; set; }

        private string TimetabledDepartureXPath = "./a/span";
        private string PlatformXPath = "//span[@class='platform']";

        public Departure(HtmlNode departure)
        {
            var time = departure.SelectSingleNode(TimetabledDepartureXPath).ChildNodes[0].InnerText;

            TimetabledDeparture = new DepartureTime(time);

            if (departure.SelectSingleNode(PlatformXPath) != null)
            {
                Platform = departure.SelectSingleNode(PlatformXPath).ChildNodes[2].InnerText;
            }
        }
    }
}
