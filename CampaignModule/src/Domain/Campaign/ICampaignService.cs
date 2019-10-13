using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Campaign
{
    public interface ICampaignService
    {
        void AddCampaing(string campaignName, string productCode, int duration, int priceManipulationLimit, int targetSalesCount);

        CampaignDto GetCampaignInfo(string name);

        CampaignDto GetCampaignByProductCode(string productCode);
    }
}
