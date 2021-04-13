﻿using Microsoft.Extensions.DependencyInjection;
using toroinvestimentos.patromonio.domain.Interfaces.Repositories;
using toroinvestimentos.patromonio.infra.data.Repository;

namespace ToroInvestimentos.PatromonioAPI
{
    public static class RepositoryInjection
    {
        public static IServiceCollection InjectioAllRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            return services;
        }
    }
}