using SLinkUser.API.Service;
using SLinkUser.Infrastructure;

namespace SLinkUser.API.DependencyInjection
{
    public static class AppServices
    {
        public static void RegisterApiServices(this IServiceCollection services)
        {
            services.AddScoped<IExternalUserService, ExternalUserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddAutoMapper(typeof(MapperProfile.MapperProfile));
        }

    }
}
