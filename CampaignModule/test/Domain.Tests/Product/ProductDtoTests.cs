using Domain.Campaign;
using Domain.Product;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Domain.Tests.Product
{
    public class ProductDtoTests
    {
        [Fact]
        public void Product_Should_HasStock_ReturnFalse()
        {
            var product = GetMockData();
            product.HasStock(0).Should().BeTrue();
            product.HasStock(1001).Should().BeFalse();
        }
        [Fact]
        public void Product_Should_MakeDiscount_IsSuccess()
        {
            var product = GetMockData();
            product.Price.Value.Should().Be(100);
            product.SetCampaign(new CampaignDto("c1", product, 10, 10, 980));
            product.MakeDiscount(-5);
            product.Price.Value.Should().Be(95);
        }
        [Fact]
        public void Product_Should_MakeDiscount_IsFail()
        {
            var product = GetMockData();
            product.Price.Value.Should().Be(100);
            product.SetCampaign(new CampaignDto("c1", product, 10, 10, 980));
            product.MakeDiscount(-80);
            product.Price.Value.Should().Be(100);
        }
        private ProductDto GetMockData()
        {
            var product = new ProductDto("p1", 100, 1000);
            return product;
        }
    }
}
