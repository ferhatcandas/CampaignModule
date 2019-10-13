using Domain.ValueObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Domain.Tests.ValueObjects
{
    public class PriceManipulationLimitTests
    {
        [Fact]
        public void ShouldBeCreatePriceManipulationLimitValue()
        {

            var PriceManipulationLimit = new PriceManipulationLimit(1);

            PriceManipulationLimit.Value.Should().Be(1);

        }
        [Fact]
        public void PriceManipulationLimit_ShouldReturn_Value_For_EqualityComponent()
        {
            var PriceManipulationLimit = new PriceManipulationLimit(5);

            var equalityComponent = new List<object> { PriceManipulationLimit.Value };

            PriceManipulationLimit.GetEqualityComponents().Should().BeEquivalentTo(equalityComponent);

        }
    }
}
