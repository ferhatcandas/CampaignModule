using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Model
{
    public class Order : BaseEntity, IEntity
    {
        public static List<Order> OrderList { get; private set; }
        public Quantity Quantity { get; private set; }
        public Product OrderedProduct { get; private set; }
        public Order()
        {
            OrderList = new List<Order>();
        }
        private Order(Product product, int quantity)
        {
            OrderedProduct = product;
            Quantity = new Quantity(quantity);
        }
        public void AddOrder(string productCode, int quantity)
        {
            //get exist product from productList
            var existProduct = Product.GetProdcut(productCode);
            //get exist order
            var existOrder = Order.GetOrder(productCode);
            //decrase stock count
            existProduct.Stock.DecraseStock(quantity);
            if (existOrder == null)
            {
                //add product to order
                OrderList.Add(new Order(existProduct, quantity));
            }
        }
        public static Order GetOrder(string productCode)
        {
            var order = OrderList.FirstOrDefault(x => x.OrderedProduct.ProductCode.Value == productCode);
            if (order == null)
            {
                return order;
            }
            else
            {
                throw new LogicException("This product has ordered");
            }
        }
    }
}
