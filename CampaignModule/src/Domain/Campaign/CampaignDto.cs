using Domain.Product;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Campaign
{
    public class CampaignDto : Entity
    {
        public Name Name { get; private set; }
        public ProductDto Product { get; private set; }
        public Duration Duration { get; private set; }
        public PriceManipulationLimit Limit { get; private set; }
        public TargetSalesCount Count { get; private set; }
    }
}
