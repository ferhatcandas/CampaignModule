using Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Order
{
    public class OrderService : IOrderService
    {
        private List<OrderDto> OrderList { get; set; }
        private readonly IProductService productService;
        public OrderService(IProductService productService)
        {
            if (OrderList == null)
                OrderList = new List<OrderDto>();

            this.productService = productService;
        }
        public void AddOrder(string productCode, int quantity)
        {
            var existOrder = GetOrder(productCode);
            var product = productService.DecraseProductStock(productCode, quantity);
            //campaign rules must add here
            if (existOrder != null)
            {
                existOrder.Quantity.Incrase(quantity);
            }
            else
            {
                OrderList.Add(new OrderDto(product, quantity));
            }
        }

        public OrderDto GetOrder(string productCode)
        {

            return OrderList.FirstOrDefault(x => x.Product.ProductCode.Value == productCode);
        }
    }
}
