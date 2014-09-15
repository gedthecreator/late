using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using HtmlAgilityPack;

namespace Late.Domain.Tests
{
    [TestFixture]
    public class SummaryTests
    {
        [Test]
        public void SummaryCreateShouldPopulateFrom()
        {
            var html = Summary.Create(Resources.Departures.ValidSummary);
            html.From.Should().Be("Sydenham (London)");
        }

        [Test]
        public void SummaryCreateShouldPopulateTo()
        {
            var html = Summary.Create(Resources.Departures.ValidSummary);
            html.To.Should().Be("London Bridge");
        }

        [Test]
        public void SummaryCreateShouldPopulateDepartures()
        {
            var html = Summary.Create(Resources.Departures.ValidSummary);
            html.Departures.Count().Should().Be(8);
        }
    }
}
