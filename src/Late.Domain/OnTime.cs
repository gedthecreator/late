using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Late.Domain
{
    public class OnTime : Departure
    {
        public new string StatusMessage { get { return "On Time"; } }

        public OnTime(HtmlNode departure) : base (departure) 
        {
            
        }
    }
}
