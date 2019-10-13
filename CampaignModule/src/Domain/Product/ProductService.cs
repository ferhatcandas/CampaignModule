using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Product
{
    public class ProductService : IProductService
    {
        private List<ProductDto> ProductList { get; set; }
        public TimeSpan LocalTime { get; set; }

        public ProductService()
        {
            if (ProductList == null)
                ProductList = new List<ProductDto>();
        }
        public void AddProduct(string productCode, double price, int stock)
        {
            if (ProductList.Any(x => x.ProductCode.Value == productCode))
            {
                Logger.Log("This product already exists");
            }
            else
            {
                ProductList.Add(new ProductDto(productCode, price, stock));
                Logger.Log($"Product created; code {productCode}, price {price}, stock {stock}");
            }

        }
        public ProductDto GetProduct(string productCode)
        {
            var product = ProductList.FirstOrDefault(x => x.ProductCode.Value == productCode);
            if (product != null)
            {
                return product;
            }
            else
            {
                Logger.Log("Product not exits");
                return null;
            }
        }
        private void MakeDiscount()
        {
            foreach (var item in ProductList)
            {
                item.MakeDiscount(-5);

            }
        }

        public void IncraseTime(int totalIncrase)
        {
            LocalTime = LocalTime.Add(new TimeSpan(totalIncrase, 0, 0));
            Logger.Log($"Time is {LocalTime.ToString("hh\\:mm")}");
            for (int i = 0; i < totalIncrase; i++)
            {
                MakeDiscount();
            }
        }
    }
}
