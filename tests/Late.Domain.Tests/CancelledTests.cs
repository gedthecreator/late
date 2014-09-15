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
    public class CancelledTests
    {
        [Test]
        public void CancelledConstructorShouldReturnCorrectStatusMessage()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(Resources.Departures.Cancelled);
            var departure = new Cancelled(doc.DocumentNode.SelectSingleNode("/"));
            departure.StatusMessage.Should().Be("Cancelled");
        }
    }
}
