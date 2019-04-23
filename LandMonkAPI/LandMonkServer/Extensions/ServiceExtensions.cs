using System;
using Microsoft.Extensions.DependencyInjection;


namespace LandMonkServer.Extensions
{
    public static class ServiceExtensions 
    {
        public static void ConfigureCors(this IServiceCollection services)

        {
            services.AddCors(options => {



            });

        }
    }
}