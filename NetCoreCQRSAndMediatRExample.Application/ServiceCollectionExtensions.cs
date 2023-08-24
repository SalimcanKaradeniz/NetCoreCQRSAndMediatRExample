using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreCQRSAndMediatRExample.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void ApplicationServiceCollection(this IServiceCollection services)
        {
            services.AddMediatR(x =>
            {
                x.RegisterServicesFromAssemblyContaining(typeof(ServiceCollectionExtensions));
            });
        }
    }
}
