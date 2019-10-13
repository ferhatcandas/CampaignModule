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
            CommandList[command].Invoke(arguments);
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

            productService.GetProduct(productCode);
        }
        public void CreateOrderCommand(string[] arguments)
        {
            string productCode = GetParameter<string>(arguments, 0);
            int quantity = GetParameter<int>(arguments, 1);

            orderService.AddOrder(productCode, quantity);
        }
        public void CreateCampaignCommand(string[] arguments)
        {

        }
        public void GetCampaignInfoCommand(string[] arguments)
        {

        }
        public void IncraseTimeCommand(string[] arguments)
        {

        }
        private T GetParameter<T>(string[] values, int index)
        {
            try
            {
                return (T)Convert.ChangeType(values[index], typeof(T));
            }
            catch (Exception ex)
            {
                throw new LogicException("Unexcepted paramater value.");
            }
        }
    }
}
