using Microsoft.Extensions.DependencyInjection;
using toroinvestimentos.patromonio.domain.Interfaces.CrossCutting;
using toroinvestimentos.patromonio.infra.crosscutting.ExternalServices;

namespace ToroInvestimentos.PatromonioAPI
{ 
    public static class CrossCuttingInjection
    {
        public static IServiceCollection InjectioAllCrossCuttings(this IServiceCollection services)
        {
            services.AddTransient<IConsultaBovespaService, ConsultaBovespaService>();
            return services;
        }
    }
}
