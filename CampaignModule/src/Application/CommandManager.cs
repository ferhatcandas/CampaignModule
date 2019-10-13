using Domain;
using Domain.Campaign;
using Domain.Order;
using Domain.Product;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Application
{
    public class CommandManager : ICommand
    {
        private static Dictionary<string, Action<string[]>> CommandList;
        private readonly IProductService productService;
        private readonly ICampaignService campaignService;
        private readonly IOrderService orderService;
        public CommandManager(IProductService productService, ICampaignService campaignService, IOrderService orderService)
        {
            this.productService = productService;
            this.campaignService = campaignService;
            this.orderService = orderService;
            Init();
        }
        public void Execute(string command, string[] arguments)
        {

            if (CommandList.ContainsKey(command))
            {
                CommandList[command].Invoke(arguments);
            }
            else
            {
                Logger.Log("Command is not found.");
            }
        }
        public void Init()
        {
            if (CommandList == null)
            {
                CommandList = new Dictionary<string, Action<string[]>>();

                CommandList.Add("create_product", CreateProductCommand);
                CommandList.Add("get_product_info", GetProductInfoCommand);
                CommandList.Add("create_order", CreateOrderCommand);
                CommandList.Add("create_campaign", CreateCampaignCommand);
                CommandList.Add("get_campaign_info", GetCampaignInfoCommand);
                CommandList.Add("increase_time", IncraseTimeCommand);
            }
        }
        public void CreateProductCommand(string[] arguments)
        {
            string productCode = GetParameter<string>(arguments, 0);
            double price = GetParameter<double>(arguments, 1);
            int stock = GetParameter<int>(arguments, 2);

            productService.AddProduct(productCode, price, stock);


        }
        public void GetProductInfoCommand(string[] arguments)
        {
            string productCode = GetParameter<string>(arguments, 0);

            var product = productService.GetProduct(productCode);

            Logger.Log($"Product {product.ProductCode.Value} info; price {product.Price.Value}, stock {product.Stock.Value}");


        }
        public void CreateOrderCommand(string[] arguments)
        {
            string productCode = GetParameter<string>(arguments, 0);
            int quantity = GetParameter<int>(arguments, 1);

            orderService.AddOrder(productCode, quantity);
        }
        public void CreateCampaignCommand(string[] arguments)
        {
            string campaignName = GetParameter<string>(arguments, 0);
            string productCode = GetParameter<string>(arguments, 1);
            int duration = GetParameter<int>(arguments, 2);
            int priceManipulationLimit = GetParameter<int>(arguments, 3);
            int targetSalesCount = GetParameter<int>(arguments, 4);

            campaignService.AddCampaing(campaignName, productCode, duration, priceManipulationLimit, targetSalesCount);
        }
        public void GetCampaignInfoCommand(string[] arguments)
        {
            string campaignName = GetParameter<string>(arguments, 0);

            campaignService.GetCampaignInfo(campaignName);

        }
        public void IncraseTimeCommand(string[] arguments)
        {
            int totalIncrase = GetParameter<int>(arguments, 0);
    
            productService.IncraseTime(totalIncrase);

        }
        private T GetParameter<T>(string[] values, int index)
        {
            try
            {
                return (T)Convert.ChangeType(values[index], typeof(T));
            }
            catch (Exception ex)
            {
                Logger.Log("Unexcepted paramater value.");
                return Activator.CreateInstance<T>();
            }
        }
    }
}
