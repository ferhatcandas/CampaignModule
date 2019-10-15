using Domain.ValueObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Domain.Tests.ValueObjects
{
    public class NameTests
    {
        [Fact]
        public void ShouldBeCreateNameValue()
        {

            var Name = new Name("c2");

            Name.Value.Should().Be("c2");

        }
        [Fact]
        public void ShouldBeThrowArgumentException()
        {

            Assert.Throws<ArgumentException>(() => { new Name(""); });

        }
        [Fact]
        public void Name_ShouldReturn_Value_For_EqualityComponent()
        {
            var Name = new Name("c2");

            var equalityComponent = new List<object> { Name.Value };

            Name.GetEqualityComponents().Should().BeEquivalentTo(equalityComponent);

        }
    }
}
