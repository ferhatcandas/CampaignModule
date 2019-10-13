using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Product
{
    public class ProductService : IProductService
    {
        private List<ProductDto> ProductList { get; set; }
        public ProductService()
        {
            if (ProductList == null)
                ProductList = new List<ProductDto>();
        }
        public void AddProduct(string productCode, double price, int stock)
        {
            if (ProductList.Any(x => x.ProductCode.Value == productCode))
            {
                throw new LogicException("This product already exists");
            }
            ProductList.Add(new ProductDto(productCode, price, stock));
        }

        public ProductDto DecraseProductStock(string productCode, int count)
        {
            var existProduct = GetProduct(productCode);
            existProduct.Stock.DecraseStock(count);
            return existProduct;
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
                throw new LogicException("Product not exits");
            }
        }
    }
}
