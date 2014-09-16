using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Late.Domain
{
    public class Summary
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Alert { get; set; }
        public string Suggestion { get; set; }
        public IDeparture NextDeparture { get; set; }
        public List<IDeparture> Departures { get; set; }

        private static string FromXPath = "//div[@class='pageCont']/table/tbody/*[1]/*[2]";
        private static string ToXPath = "//div[@class='pageCont']/table/tbody/*[2]/*[2]";

        private static string DeparturesXPath = "//div[@class='pageCont']/ul/li";

        public static Summary Create(string html)
        {
            var summary = new Summary();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            
            summary.From = doc.DocumentNode.SelectSingleNode(FromXPath).InnerText;
            summary.To = doc.DocumentNode.SelectSingleNode(ToXPath).InnerText;

            var departureNodes = doc.DocumentNode.SelectNodes(DeparturesXPath);

            summary.Departures = new List<IDeparture>();
            foreach (var departure in departureNodes)
            {
                summary.Departures.Add(DepartureFactory.Create(departure));
            }

            summary.RunRules();

            return summary;
        }

        public void RunRules()
        {
            var first = this.Departures[0];
            var second = this.Departures[1];
            var third = this.Departures[2];
            var fourth = this.Departures[3];

            //O	O	O	O		Minutes until next train
            if (first.IsOnTime() && second.IsOnTime()) { }
            //O	U/E				Minutes until next train	Hurry as the next train is delayed
            if (first.IsOnTime() && second.IsUnknownDelay()) {  }
            if (first.IsOnTime() && second.IsExpectedDelay()) { Suggestion = "Hurry, the next train is delayed"; }
            //O	C				Minutes until next train	Hurry as the next train is cancelled
            if (first.IsOnTime() && second.IsCancelled()) { Suggestion = "Hurry, the next train is cancelled"; }
            //C	O	O	O	The xx:xx is cancelled	Minutes until next train
            if (first.IsCancelled() && second.IsOnTime() && third.IsOnTime()) { Alert = "The next train is cancelled"; }
            //C	C	O	O	The next 2 trains are cancelled	Minutes until next train	You might want to find a different route
            if (first.IsCancelled() && second.IsCancelled() && third.IsOnTime()) { Alert = "The next 2 trains are cancelled"; Suggestion = "Find an alternate route"; }
            //C	C	C	O	All trains are cancelled	Minutes until next train	You might want to find a different route
            if (first.IsCancelled() && second.IsCancelled() && third.IsCancelled() && fourth.IsOnTime()) { Alert = "The next 3 trains are cancelled"; Suggestion = "Find an alternate route"; }
            //E	O	O	O		Minutes until next train	Hurry as this train is delayed
            if (first.IsExpectedDelay() && second.IsOnTime()) { Suggestion = "Slight delay"; }
            //E	E			There are some delays	Minutes until next train	
            if (first.IsExpectedDelay() && (second.IsExpectedDelay() || second.IsUnknownDelay()) && third.IsOnTime()) { Alert = "Trains are delayed"; Suggestion = "Find an alternate route"; }
            //U	O	O	O	The next train is delayed	Minutes until next train	You might want to find a different route
            if (first.IsUnknownDelay() && second.IsOnTime() && third.IsOnTime()) { Suggestion = "Unknown delays"; }
            //U	U	O	O	The next 2 trains are delayed	Minutes until next train	You might want to find a different route
            if (first.IsUnknownDelay() && second.IsUnknownDelay()) { Alert = "Trains are severely delayed"; Suggestion = "Find an alternate route"; }
            //U	E	O	O	The next train is delayed	Minutes until next train	You might want to find a different route
            if (first.IsUnknownDelay() && second.IsExpectedDelay()) { Alert = "Trains are delayed"; Suggestion = "Find an alternate route"; }

            foreach (var departure in Departures)
            {
                if (departure is ExpectedDelay || departure is OnTime)
                {
                    NextDeparture = departure;
                    break;
                }
            }
        }
    }
}
