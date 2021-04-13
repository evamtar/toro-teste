using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using toroinvestimentos.patromonio.infra.data.Context;
using Microsoft.EntityFrameworkCore;

namespace ToroInvestimentos.PatromonioAPI
{
    public static class ConnectionInjection
    {
        public static IServiceCollection InjectionAllConnections(this IServiceCollection services, IConfiguration configuration) 
        {
            #region MySql Connection

            var connection = configuration["ConexaoMySql:MySqlConnectionString"];
            services.AddDbContext<MySqlContext>(options =>
                options.UseMySql(connection)
            );

            #endregion

            return services;
        }
    }
}
