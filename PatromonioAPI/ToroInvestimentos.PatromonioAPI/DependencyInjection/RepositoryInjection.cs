using Microsoft.Extensions.DependencyInjection;
using toroinvestimentos.patromonio.domain.Interfaces.Repositories;
using toroinvestimentos.patromonio.infra.data.Repository;

namespace ToroInvestimentos.PatromonioAPI
{
    public static class RepositoryInjection
    {
        public static IServiceCollection InjectioAllRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IContaCorrenteRepository, ContaCorrenteRepository>();
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();
            services.AddScoped<IAtivoRepository, AtivoRepository>();
            return services;
        }
    }
}
