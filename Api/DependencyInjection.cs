using Application.Application;
using Domain.Interface.Application;
using Domain.Interface.Repository;
using Infrastructure.Repository;

namespace Api
{
    public static class DependencyInjection
    {
        public static void Inject(this IServiceCollection services)
        {
            services.AddScoped<IBancoApplication, BancoApplication>();
            services.AddScoped<IBancoRepository, BancoRepository>();
        }
    }
}
