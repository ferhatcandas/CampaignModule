using Domain.ValueObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Domain.Tests.ValueObjects
{
    public class DurationTests
    {
        [Fact]
        public void ShouldBeCreateDurationValue()
        {

            var duration = new Duration(1);

            duration.Value.Should().Be(1);

        }
        [Fact]
        public void ShouldBeThrowArgumentException()
        {

            Assert.Throws<ArgumentException>(() => { new Duration(-1); });

        }
        [Fact]
        public void Duration_ShouldReturn_Value_For_EqualityComponent()
        {
            var duration = new Duration(5);

            var equalityComponent = new List<object> { duration.Value };

            duration.GetEqualityComponents().Should().BeEquivalentTo(equalityComponent);

        }
    }
}
