using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Product
{
    public interface IProductService
    {
        TimeSpan LocalTime { get; set; }
        void AddProduct(string productCode, double price, int stock);
        ProductDto GetProduct(string productCode);
        void IncraseTime(int totalIncrase);
    }
}
