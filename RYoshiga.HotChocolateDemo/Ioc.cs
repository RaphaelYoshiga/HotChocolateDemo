using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RYoshiga.HotChocolateDemo.DataLoaders;
using RYoshiga.HotChocolateDemo.QueryTypes;
using RYoshiga.HotChocolateDemo.Services;

namespace RYoshiga.HotChocolateDemo
{
    public class Ioc
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
        }

        public static void RegisterGraphDependencies(IRequestExecutorBuilder graphQl)
        {
            graphQl
                .AddQueryType<Query>()
                .AddDataLoader<ProductsByIdDataLoader>();
        }
    }
}