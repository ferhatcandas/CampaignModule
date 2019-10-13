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

        private readonly IProductService productService;
        public OrderService(IProductService productService)
        {
            if (OrderList == null)
                OrderList = new List<OrderDto>();

            this.productService = productService;
        }
        public void AddOrder(string productCode, int quantity)
        {
            var product = productService.GetProduct(productCode);
            if (product != null)
            {
                if (product.HasStock(quantity))
                {

                    product.Stock.DecraseStock(quantity);

                    var order = new OrderDto(product, quantity);

                    if (product.HasCampaign())
                    {
                        var existCampaign = product.GetCampaign();

                        if (existCampaign.HasDuration(productService.LocalTime) && !existCampaign.HasTargetSalesCountExceed(quantity))
                        {
                            existCampaign.IncraseTotalSalesCount(quantity);

                            order.SetCampaign(existCampaign);

                            order.SetSalesPrice(product.Price.Value);
                            OrderList.Add(order);
                            Logger.Log($"Order created; product {productCode}, quantity {quantity}");

                        }
                    }
                    else
                    {
                        order.SetSalesPrice(product.Price.Value);
                        OrderList.Add(order);
                        Logger.Log($"Order created; product {productCode}, quantity {quantity}");
                    }

                }
            }
        }

        public List<OrderDto> GetOrdersByCampaignName(string campaignName)
        {
            return OrderList.Where(x => x.Campaign?.Name?.Value == campaignName).ToList();
        }


    }
}
