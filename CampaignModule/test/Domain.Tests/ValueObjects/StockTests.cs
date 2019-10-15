using Domain.ValueObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Domain.Tests.ValueObjects
{
    public class StockTests
    {
        [Fact]
        public void ShouldBeCreateStockValue()
        {

            var Stock = new Stock(1);

            Stock.Value.Should().Be(1);

        }
        [Fact]
        public void Stock_ShouldReturn_Value_For_EqualityComponent()
        {
            var Stock = new Stock(5);

            var equalityComponent = new List<object> { Stock.Value };

            Stock.GetEqualityComponents().Should().BeEquivalentTo(equalityComponent);

        }
    }
}
