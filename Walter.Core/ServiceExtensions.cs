using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walter.Core.Services;

namespace Walter.Core
{
    public static class ServiceExtensions
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddTransient<UserService>();
        }
    }
}
