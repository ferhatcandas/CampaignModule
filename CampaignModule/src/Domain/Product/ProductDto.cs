using Domain.Campaign;
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
            RealPrice = new Price(price);
            SetPrice(price);
            Stock = new Stock(stock);
            Id = new Guid();
        }
        public ProductCode ProductCode { get; private set; }
        public Price RealPrice { get; private set; }
        public Price Price { get; private set; }
        public Stock Stock { get; private set; }
        private CampaignDto Campaign { get; set; }
        public void SetCampaign(CampaignDto campaign) => Campaign = campaign;
        public bool HasStock(int quantity)
        {
            bool exist = Stock.Value - quantity >= 0;
            if (!exist)
            {
                Logger.Log($"Product stock is finished.");
            }

            return exist;
        }
        private void SetPrice(double price) => Price = new Price(price);
        public void MakeDiscount(double price)
        {
            if (HasCampaign())
            {
                if (Campaign.Status)
                {
                    Price.SetPrice(Price.Value + price);
                    if (Campaign.IsPriceManipulationLimitExceed())
                    {
                        Price.SetPrice(RealPrice.Value);
                        Campaign.CampaignClose();
                    }
                }
            }

        }

        internal bool HasCampaign() => Campaign != null;
        internal CampaignDto GetCampaign() => Campaign;
    }
}
