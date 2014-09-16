using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Nancy;
using Late.Domain;

namespace Late.Web
{
    public class DepartureModule : NancyModule
    {
        public DepartureModule(IMobileWebClient webClient)
        {
            Get["/{from}/{to}"] = _ =>
                {
                    var from = (string)_.from;
                    var to = (string)_.to;
                    if (string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to))
                    {
                        return HttpStatusCode.BadRequest;
                    }
                    
                    var departuresUrl = string.Format(ConfigurationManager.AppSettings["DeparturesUrl"], _.from, _.to);
                    
                    var summary = Summary.Create(webClient.GetHtml(departuresUrl));

                    return View["index.cshtml", summary];
                 };
        }
    }
}