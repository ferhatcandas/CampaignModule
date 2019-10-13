using Domain.Campaign;
using Domain.Order;
using Domain.Product;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Domain.Tests.Campaign
{
    public class CampaignServiceTests
    {
        private readonly ICampaignService campaignService;
        private readonly IProductService productService;

        public CampaignServiceTests()
        {
            productService = new ProductService();
            Init();
            this.campaignService = new CampaignService(productService, new OrderService());
        }

        [Fact]
        public void CampaignService_Should_AddNewCampaign()
        {
            campaignService.AddCampaing("c1", "p1", 10, 20, 100);

            var campaign = campaignService.GetCampaignInfo("c1");

            campaign.Count.Value.Should().Be(100);

            campaign.Limit.Value.Should().Be(20);

            campaign.Duration.Value.Should().Be(10);

            campaign.Name.Value.Should().Be("c1");

            campaign.Product.ProductCode.Value.Should().Be("p1");
        }
        [Fact]
        public void CampaignService_Should_ThrowLogicException_CampaignAlreadyExists()
        {
            campaignService.AddCampaing("c1", "p1", 10, 20, 100);

            Assert.Throws<LogicException>(() =>
            {
                campaignService.AddCampaing("c1", "p1", 10, 20, 100);
            });
        }
        [Fact]
        public void CampaignService_Should_GetCampaignByProductCode_IsSuccess()
        {
            campaignService.AddCampaing("c1", "p1", 10, 20, 100);

            var campaign = campaignService.GetCampaignByProductCode("p1");

            campaign.Count.Value.Should().Be(100);

            campaign.Limit.Value.Should().Be(20);

            campaign.Duration.Value.Should().Be(10);

            campaign.Name.Value.Should().Be("c1");

            campaign.Product.ProductCode.Value.Should().Be("p1");
        }

        private void Init()
        {
            productService.AddProduct("p1", 100, 1000);
        }
    }
}
