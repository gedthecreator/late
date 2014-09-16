using Nancy.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Nancy;
using NUnit.Framework;
using StoryQ;
using Nancy.TinyIoc;
using FakeItEasy;

namespace Late.Web.Tests
{
    [TestFixture]
    public class DepartureModuleTests 
    {
        TinyIoCContainer container;

        [SetUp]
        public void SetUp()
        {
            container = new TinyIoCContainer();
        }

        [Test]
        public void ValidHtmlShouldReturnAnOkHttpStatus()
        {
            new Story("Valid HTML should return an OK HTTP Status")
                .InOrderTo("know that I have received the correct response")
                .AsA("developer")
                .IWant("to call the Nancy service")
                .WithScenario("Valid HTML")
                .Given(IAskForSydenhamToLondonBridgeDepartures)
                .When(ICallTheNancyService)
                .Then(TheResponseShouldBeOk)
                .Execute();
        }

        public void IAskForSydenhamToLondonBridgeDepartures() 
        { 
            container.Register<string>("/SYD/LBG" , "DeparturesUrl"); 
        }
        
        public void ICallTheNancyService() 
        {
            var mobileClient = A.Fake<IMobileWebClient>();
            A.CallTo(() => mobileClient.GetHtml(A<string>.Ignored)).Returns(Resource.ExpectedDelayHtml);
            
            var browser = new Browser(with => {
                with.Module<DepartureModule>();
                with.Dependency<IMobileWebClient>(mobileClient);
            });

            var departuresUrl = container.Resolve<string>("DeparturesUrl");
                        
            var response =  browser.Get(
                        departuresUrl, 
                        with => {
                            with.HttpRequest();
                        });

            Console.WriteLine(response.Body.AsString());
            container.Register<BrowserResponse>(response);
        }
        public void TheResponseShouldBeOk() 
        {
            var response = container.Resolve<BrowserResponse>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
