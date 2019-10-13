using Domain.Order;
using Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Campaign
{
    public class CampaignService : ICampaignService
    {
        private List<CampaignDto> CampaignList { get; set; }


        private readonly IProductService productService;
        private readonly IOrderService orderService;
        public CampaignService(IProductService productService, IOrderService orderService)
        {
            if (CampaignList == null)
                CampaignList = new List<CampaignDto>();
            this.productService = productService;
            this.orderService = orderService;
        }

        public void AddCampaing(string campaignName, string productCode, int duration, int priceManipulationLimit, int targetSalesCount)
        {
            if (GetCampaignByName(campaignName) == null)
            {
                var product = productService.GetProduct(productCode);
                if (product != null)
                {
                    if (!product.HasCampaign())
                    {
                        var campaign = new CampaignDto(campaignName, product, duration, priceManipulationLimit, targetSalesCount);
                        product.SetCampaign(campaign);
                        CampaignList.Add(campaign);
                        Logger.Log($"Campaign created; name {campaign.Name.Value}, product {product.ProductCode.Value}, duration {campaign.Duration.Value}, limit {campaign.Limit.Value}, target sales count {campaign.Count.Value}");
                    }
                    else
                    {
                        Logger.Log("This product already have a campaign.");
                    }
                   
                }
            }
        }

        public CampaignDto GetCampaignInfo(string name)
        {
            var campaign = CampaignList.FirstOrDefault(x => x.Name.Value == name);
            if (campaign != null)
            {
                var orders = orderService.GetOrdersByCampaignName(campaign.Name.Value);
                int totalSales = 0;
                double avarageItemPrice = 0D;
                if (orders?.Count > 0)
                {
                    totalSales = orders.Sum(x => x.Quantity.Value);
                    avarageItemPrice = orders.Sum(y => y.SalesPrice.Value) / totalSales;
                }
                Logger.Log($"Campaign {campaign.Name.Value} info; Status {campaign.GetStatusString()}, Target Sales {campaign.Count.Value}, Total Sales {totalSales}, Turnover {totalSales * avarageItemPrice}, Average Item Price {avarageItemPrice}");
                return campaign;
            }
            else
            {
                Logger.Log("Campaign name is not found");
                return null;
            }
        }
        private CampaignDto GetCampaign(Func<CampaignDto, bool> predicate) => CampaignList.FirstOrDefault(predicate);

        public CampaignDto GetCampaignByProductCode(string productCode) => GetCampaign(x => x.Product.ProductCode.Value == productCode);
        public CampaignDto GetCampaignByName(string name) => GetCampaign(x => x.Name.Value == name);
    }
}
