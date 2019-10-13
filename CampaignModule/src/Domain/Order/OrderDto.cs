using Domain.Campaign;
using Domain.Product;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Order
{
    public class OrderDto : Entity
    {
        public OrderDto(ProductDto product, int quantity)
        {
            Product = product;
            Quantity = new Quantity(quantity);
            Id = new Guid();
        }
        public Quantity Quantity { get; private set; }
        public Price SalesPrice { get; set; }
        public ProductDto Product { get; private set; }
        public CampaignDto Campaign { get; set; }
        public void SetSalesPrice(double price) => SalesPrice = new Price(price);
        public void SetCampaign(CampaignDto campaign) => Campaign = campaign;
    }
}
