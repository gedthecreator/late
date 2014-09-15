using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using HtmlAgilityPack;
using Late.Domain;
using NodaTime;

namespace Late.Domain.Tests
{
    [TestFixture]
    public class DepartureTests
    {
        [Test]
        public void DepartureConstructorShouldSetTimetabledDeparture()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(Resources.Departures.OnTime);
            var departure = new Departure(doc.DocumentNode.SelectSingleNode("/"));
            departure.TimetabledDeparture.Hour.Should().Be(11);
            departure.TimetabledDeparture.Minute.Should().Be(42);
        }

        [Test]
        public void DepartureConstructorShouldSetPlatform()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(Resources.Departures.OnTime);
            var departure = new Departure(doc.DocumentNode.SelectSingleNode("/"));
            departure.Platform.Should().Be("1");
        }
    }
}
