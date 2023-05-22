using ShopsRUs.API.Factories;
using ShopsRUs.API.Services;

namespace ShopsRUs.API.Infrastructure
{
    /// <summary>
    /// Represents extensions of IServiceCollection
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add services to the application and configure service provider
        /// </summary>
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IInvoiceService, InvoiceService>();
            services.AddSingleton<IDiscountFactory, DiscountFactory>();

            return services;
        }
    }
}
