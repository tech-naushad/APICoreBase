using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IdentityCore.AppSettings;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityCore.Extensions
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddIdentityCoreServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
