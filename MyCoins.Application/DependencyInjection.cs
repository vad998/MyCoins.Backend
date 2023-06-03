using Microsoft.Extensions.DependencyInjection;
using MyCoins.Application.Common.Mappings;

namespace MyCoins.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.ConfigureAutoMapper();

            return services;
        }
    }
}
