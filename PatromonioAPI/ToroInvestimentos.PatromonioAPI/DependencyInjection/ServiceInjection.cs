using Microsoft.Extensions.DependencyInjection;
using toroinvestimentos.patromonio.domain.Interfaces.Services;
using toroinvestimentos.patromonio.service.Services;

namespace ToroInvestimentos.PatromonioAPI
{
    public static class ServiceInjection
    {

        public static IServiceCollection InjectioAllServices(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            return services;
        }
    }
}
