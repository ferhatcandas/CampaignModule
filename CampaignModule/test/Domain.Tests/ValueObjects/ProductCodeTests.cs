using Domain.ValueObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Domain.Tests.ValueObjects
{
    public class ProductCodeTests
    {
        [Fact]
        public void ShouldBeCreateProductCodeValue()
        {

            var ProductCode = new ProductCode("p1");

            ProductCode.Value.Should().Be("p1");

        }
        [Fact]
        public void ShouldBeThrowArgumentException()
        {

            Assert.Throws<ArgumentException>(() => { new ProductCode(""); });

        }
        [Fact]
        public void ProductCode_ShouldReturn_Value_For_EqualityComponent()
        {
            var ProductCode = new ProductCode("p1");

            var equalityComponent = new List<object> { ProductCode.Value };

            ProductCode.GetEqualityComponents().Should().BeEquivalentTo(equalityComponent);

        }
    }
}
