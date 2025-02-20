using APICore.Factoty.Token;
using APICore.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace APICore.Extensions
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddIdentityCoreServices(this IServiceCollection services)
        {
            services.AddTransient<TokenProviderFactory>();
            services.AddTransient<ITokenService, TokenService>();
            return services;
        }
    }
}
