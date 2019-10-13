using Domain.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Campaign
{
    public class CampaignService : ICampaignService
    {
        private readonly IProductService productService;
        public CampaignService(IProductService productService)
        {
            this.productService = productService;
        }
    }
}
