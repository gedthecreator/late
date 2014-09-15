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
    public class DepartureFactoryTests
    {
        [Test]
        public void DepartureFactoryShouldCreateOnTimeDeparture()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(Resources.Departures.OnTime);
            
            IDeparture departure = DepartureFactory.Create(doc.DocumentNode.SelectSingleNode("/"));
            departure.Should().BeOfType<OnTime>();
        }

        [Test]
        public void DepartureFactoryShouldCreateExpectedDelay()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(Resources.Departures.ExpectedDelay);

            IDeparture departure = DepartureFactory.Create(doc.DocumentNode.SelectSingleNode("/"));
            departure.Should().BeOfType<ExpectedDelay>();
        }

        [Test]
        public void DepartureFactoryShouldCreateUnknownDelay()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(Resources.Departures.UnknownDelay);

            IDeparture departure = DepartureFactory.Create(doc.DocumentNode.SelectSingleNode("/"));
            departure.Should().BeOfType<UnknownDelay>();
        }

        [Test]
        public void DepartureFactoryShouldCreateCancelled()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(Resources.Departures.Cancelled);

            IDeparture departure = DepartureFactory.Create(doc.DocumentNode.SelectSingleNode("/"));
            departure.Should().BeOfType<Cancelled>();
        }

    }
}
