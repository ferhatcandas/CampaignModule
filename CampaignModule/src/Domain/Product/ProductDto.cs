using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Product
{
    public class ProductDto : Entity
    {
        public ProductDto(string productCode, double price, int stock)
        {
            ProductCode = new ProductCode(productCode);
            Price = new Price(price);
            Stock = new Stock(stock);
        }
        public ProductCode ProductCode { get; private set; }
        public Price Price { get; private set; }
        public Stock Stock { get; private set; }
    }
}
