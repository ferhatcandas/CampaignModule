using Domain.ValueObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Domain.Tests.ValueObjects
{
    public class PriceTests
    {
        [Fact]
        public void ShouldBeCreatePriceValue()
        {

            var Price = new Price(1);

            Price.Value.Should().Be(1);

        }
        [Fact]
        public void ShouldBeThrowArgumentException()
        {

            Assert.Throws<ArgumentException>(() => { new Price(-1); });

        }
        [Fact]
        public void Price_ShouldReturn_Value_For_EqualityComponent()
        {
            var Price = new Price(5);

            var equalityComponent = new List<object> { Price.Value };

            Price.GetEqualityComponents().Should().BeEquivalentTo(equalityComponent);

        }
    }
}
