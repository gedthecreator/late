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
    public class UnknownDelayTests
    {
        [Test]
        public void UnknownDelayConstructorShouldSetTimetabledDeparture()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(Resources.Departures.UnknownDelay);
            var departure = new UnknownDelay(doc.DocumentNode.SelectSingleNode("/"));
            departure.TimetabledDeparture.Hour.Should().Be(13);
            departure.TimetabledDeparture.Minute.Should().Be(15);
        }

        [Test]
        public void UnknownConstructorShouldReturnCorrectStatusMessage()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(Resources.Departures.UnknownDelay);
            var departure = new UnknownDelay(doc.DocumentNode.SelectSingleNode("/"));
            departure.StatusMessage.Should().Be("Delayed");
        }
    }
}
