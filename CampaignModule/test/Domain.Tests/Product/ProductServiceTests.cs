using Domain.Product;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Domain.Tests.Product
{
    public class ProductServiceTests
    {
        private readonly IProductService productService;
        public ProductServiceTests()
        {
            this.productService = new ProductService();
        }

        [Fact]
        public void Product_Should_Add()
        {
            productService.AddProduct("p1", 100, 1000);

            var product = productService.GetProduct("p1");

            product.ProductCode.Value.Should().Be("p1");

            product.Price.Value.Should().Be(100);

            product.Stock.Value.Should().Be(1000);
        }

        [Fact]
        public void Product_Should_MakeDiscount()
        {
            productService.AddProduct("p1", 100, 1000);

            var product = productService.GetProduct("p1");

            product.SetCampaign(new Domain.Campaign.CampaignDto("c1", product, 10, 70, 200));

            productService.IncraseTime(3);

            product.Price.Value.Should().NotBe(100);

            product.RealPrice.Value.Should().Be(100);

        }
    }
}
