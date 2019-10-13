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
        }
        public CampaignDto Campaign { get; private set; }
        public Quantity Quantity { get; private set; }
        public ProductDto Product { get; private set; }
    }
}
