
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCoreCQRSAndMediatRExample.Infrastructure.Repositories;
using NetCoreCQRSAndMediatRExample.Infrastructure.Repositories.Abstracts;
using NetCoreCQRSAndMediatRExample.Infrastructure.Repositories.Concretes;

namespace NetCoreCQRSAndMediatRExample.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NetCoreCQRSAndMediatRExampleDbContext>((serviceProvider, dbContextBuilder) =>
            {
                dbContextBuilder.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection"),
                    optionsBuilder =>
                    {
                        optionsBuilder.MigrationsAssembly("NetCoreCQRSAndMediatRExample.Infrastructure");
                        optionsBuilder.MigrationsHistoryTable("__EFMigrationsHistory", "public");
                    }).UseSnakeCaseNamingConvention();
            });

            services.AddScoped(typeof(IRepository<>), typeof(LinqToSqlRepository<>));
        }
    }
}
