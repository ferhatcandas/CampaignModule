using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Model
{
    public class Product : BaseEntity, IEntity
    {
        public static List<Product> ProductList { get; private set; }
        public Product()
        {
            ProductList = new List<Product>();
        }
        public ProductCode ProductCode { get; private set; }
        public Price Price { get; private set; }
        public Stock Stock { get; private set; }
      
        public static Product GetProdcut(string productCode)
        {
            var product = ProductList.FirstOrDefault(x => x.ProductCode.Value == productCode);
            if (product != null)
            {
                return product;
            }
            else
            {
                throw new LogicException("Product not exits");
            }
        }

    }
}
