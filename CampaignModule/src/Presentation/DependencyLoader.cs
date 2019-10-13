using Application;
using Domain.Campaign;
using Domain.Order;
using Domain.Product;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation
{
    public class DependencyLoader
    {
        public ServiceProvider Init()
        {
            ServiceCollection serviceDescriptors = new ServiceCollection();
            serviceDescriptors.AddSingleton<IProductService, ProductService>();
            serviceDescriptors.AddSingleton<IOrderService, OrderService>();
            serviceDescriptors.AddSingleton<ICampaignService, CampaignService>();
            serviceDescriptors.AddSingleton<ICampaignService, CampaignService>();
            serviceDescriptors.AddSingleton<ICommand, CommandManager>();
            return serviceDescriptors.BuildServiceProvider();

        }
    }
}
