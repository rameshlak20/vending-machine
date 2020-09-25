namespace Capstone
{
    using DomainLayer.Contract;
    using DomainLayer.Services;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<IMenu>().Display();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IMenu,Menu>();
            services.AddTransient<IVendingMachine, VendingMachine>();
            services.AddTransient<IOrderService,OrderService>();
            services.AddTransient<IFileHandler, FileHandler>();
            services.AddTransient<IMoney, Money>();
            services.AddTransient<ILoggerService, LoggerService>();

            return services;
        }
    }
}
