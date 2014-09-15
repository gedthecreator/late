using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using NodaTime;
using Late.Domain;
using HtmlAgilityPack;

namespace Late.Domain.Tests
{
    [TestFixture]
    public class ExpectedDelayTests
    {
        [Test]
        public void ExpectedDelayConstructorShouldSetTimetabledDeparture()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(Resources.Departures.ExpectedDelay);
            var departure = new ExpectedDelay(doc.DocumentNode.SelectSingleNode("/"));
            departure.TimetabledDeparture.Hour.Should().Be(17);
            departure.TimetabledDeparture.Minute.Should().Be(17);
        }

        [Test]
        public void ExpectedDelayConstructorShouldSetExpectedDeparture()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(Resources.Departures.ExpectedDelay);
            var departure = new ExpectedDelay(doc.DocumentNode.SelectSingleNode("/"));
            departure.ExpectedDeparture.Hour.Should().Be(17);
            departure.ExpectedDeparture.Minute.Should().Be(19);
        }

        [Test]
        public void ExpectedDelayConstructorShouldSetPlatform()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(Resources.Departures.ExpectedDelay);
            var departure = new ExpectedDelay(doc.DocumentNode.SelectSingleNode("/"));
            departure.Platform.Should().Be("2");
        }

        [Test]
        public void OnTimeConstructorShouldReturnCorrectStatusMessage()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(Resources.Departures.ExpectedDelay);
            var departure = new ExpectedDelay(doc.DocumentNode.SelectSingleNode("/"));
            departure.StatusMessage.Should().Be("Delayed");
        }
    }
}
