using Domain.Campaign;
using Domain.Order;
using Domain.Product;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Domain.Tests.Order
{
    public class OrderServiceTests
    {
        private readonly IOrderService orderService;
        public OrderServiceTests()
        {
            this.orderService = new OrderService();
        }

        [Fact]
        public void Order_Should_Add()
        {
            var product = new ProductDto("p1", 100, 1000);

            orderService.AddOrder(product, 5, new TimeSpan(0, 0, 0));

            var order = orderService.GetOrders().FirstOrDefault(x => x.Product.Id == product.Id);

            order.Product.Should().Be(product);
        }
        [Fact]
        public void Order_Should_CalculateTotalSalesByCampaign()
        {
            var product = new ProductDto("p1", 100, 1000);

            product.SetCampaign(new CampaignDto("c1", product, 10, 20, 10));

            orderService.AddOrder(product, 5, new TimeSpan(0, 0, 0));

            int totalSales = orderService.GetTotalSalesByCampaign("c1");

            totalSales.Should().Be(5);
        }
        [Fact]
        public void Order_Should_Calculate_Avarage_Item_Price_ByCampaign()
        {
            var product = new ProductDto("p1", 100, 1000);

            product.SetCampaign(new CampaignDto("c1", product, 10, 20, 10));

            orderService.AddOrder(product, 5, new TimeSpan(0, 0, 0));

            double avarageItemPrice = orderService.GetAvarageItemPriceByCampaign("c1");

            avarageItemPrice.Should().Be(20);
        }

    }
}
