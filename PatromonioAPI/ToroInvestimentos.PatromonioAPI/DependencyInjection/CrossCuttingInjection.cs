using Microsoft.Extensions.DependencyInjection;


namespace ToroInvestimentos.PatromonioAPI
{ 
    public static class CrossCuttingInjection
    {
        public static IServiceCollection InjectioAllCrossCuttings(this IServiceCollection services)
        {
            return services;
        }
    }
}
