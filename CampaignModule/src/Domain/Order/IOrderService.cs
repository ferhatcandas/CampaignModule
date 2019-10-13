using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Order
{
    public interface IOrderService
    {
        void AddOrder(string productCode, int quantity);
        List<OrderDto> GetOrdersByCampaignName(string campaignName);
    }
}
