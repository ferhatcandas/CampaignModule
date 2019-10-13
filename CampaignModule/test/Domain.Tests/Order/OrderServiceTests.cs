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
            var product = new ProductDto("p1",100,1000);

            orderService.AddOrder(product, 5, new TimeSpan(0, 0, 0));

            var order = orderService.GetOrders().FirstOrDefault(x => x.Product.Id == product.Id);

            order.Product.Should().Be(product);
        }

    }
}
