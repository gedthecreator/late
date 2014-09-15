using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using Late.Domain;
using HtmlAgilityPack;

namespace Late.Domain.Tests
{
    [TestFixture]
    public class OnTimeTests
    {
        [Test]
        public void OnTimeConstructorShouldSetTimetabledDeparture()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(Resources.Departures.OnTime);
            var departure = new OnTime(doc.DocumentNode.SelectSingleNode("/"));
            departure.TimetabledDeparture.Hour.Should().Be(11);
            departure.TimetabledDeparture.Minute.Should().Be(42);
        }

        [Test]
        public void OnTimeConstructorShouldSetPlatform()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(Resources.Departures.OnTime);
            var departure = new OnTime(doc.DocumentNode.SelectSingleNode("/"));
            departure.Platform.Should().Be("1");
        }

        [Test]
        public void OnTimeConstructorShouldReturnCorrectStatusMessage()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(Resources.Departures.OnTime);
            var departure = new OnTime(doc.DocumentNode.SelectSingleNode("/"));
            departure.StatusMessage.Should().Be("On Time");
        }
    }
}
