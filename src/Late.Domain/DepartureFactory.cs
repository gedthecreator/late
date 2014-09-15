using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Late.Domain
{
    public static class DepartureFactory
    {
        private const string StatusXPath = "./a/span/small";

        public static IDeparture Create(HtmlNode departure)
        {
            var statusNode = departure.SelectSingleNode(StatusXPath);
            switch (statusNode.InnerText.ToUpper())
	        {
                case "CANCELLED" :
                    return new Cancelled(departure);
                case "DELAYED" :
                    return new UnknownDelay(departure);
                case "ON TIME" :
                    return new OnTime(departure);
        		default:
                    return new ExpectedDelay(departure);
	        }
        }
    }
}