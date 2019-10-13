using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Campaign : BaseEntity, IEntity
    {
        public static List<Campaign> Campaigns { get; set; }
        public Name Name { get; private set; }
        public Product Product { get; private set; }
        public Duration Duration { get; private set; }
        public PriceManipulationLimit Limit { get; private set; }
        public TargetSalesCount Count { get; private set; }
        public Campaign()
        {
            Campaigns = new List<Campaign>();
        }
        private Campaign(Product product, string name, int duration, int limit, int count)
        {
            product.Stock.CheckStockExist(count);
            Product = product;
            Name = new Name(name);
            Duration = new Duration(duration);
            Limit = new PriceManipulationLimit(limit);
            Count = new TargetSalesCount(count);
            Product = product;
        }
        public void AddCampaign(string name,string productCode, int duration, int limit, int count)
        {

        }
        public void SetDuration()
        {

        }
    }
}
