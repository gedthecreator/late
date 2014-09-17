using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace Late.Web
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(Nancy.TinyIoc.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
        {
            StaticConfiguration.DisableErrorTraces = false;

            container.Register<IMobileWebClient>(new MobileWebClient());

            base.ApplicationStartup(container, pipelines);
        }
    }
}