using Domain.Campaign;
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

        public OrderService()
        {
            if (OrderList == null)
                OrderList = new List<OrderDto>();
        }
        public void AddOrder(ProductDto product, int quantity, TimeSpan systemTime)
        {
            //var product = productService.GetProduct(productCode);
            if (product != null)
            {
                if (product.HasStock(quantity))
                {

                    product.Stock.DecraseStock(quantity);

                    var order = new OrderDto(product, quantity);

                    if (product.HasCampaign())
                    {
                        var existCampaign = product.GetCampaign();

                        if (existCampaign.HasDuration(systemTime) && !existCampaign.HasTargetSalesCountExceed(quantity))
                        {
                            existCampaign.IncraseTotalSalesCount(quantity);

                            order.SetCampaign(existCampaign);

                            order.SetSalesPrice(product.Price.Value);

                            OrderList.Add(order);
                            Logger.Log($"Order created; product {product.ProductCode.Value}, quantity {quantity}");

                        }
                    }
                    else
                    {
                        order.SetSalesPrice(product.Price.Value);
                        OrderList.Add(order);
                        Logger.Log($"Order created; product {product.ProductCode.Value}, quantity {quantity}");
                    }

                }
            }
        }

        public List<OrderDto> GetOrdersByCampaignName(string campaignName)
        {
            return OrderList.Where(x => x.Campaign?.Name?.Value == campaignName).ToList();
        }

        public List<OrderDto> GetOrders()
        {
            return OrderList;
        }
    }
}
