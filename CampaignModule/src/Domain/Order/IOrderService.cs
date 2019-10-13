using Domain.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Order
{
    public interface IOrderService
    {
        void AddOrder(ProductDto product, int quantity,TimeSpan systemTime);

        List<OrderDto> GetOrdersByCampaignName(string campaignName);

        List<OrderDto> GetOrders();
    }
}
