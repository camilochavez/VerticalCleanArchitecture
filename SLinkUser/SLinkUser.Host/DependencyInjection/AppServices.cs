using SLinkUser.Host.BackgroundTaks;
using SLinkUser.Host.Services;

namespace SLinkUser.Host.DependencyInjection
{
    public static class AppServices
    {
        public static void RegisterApiServices(this IServiceCollection services)
        {
            services.AddRazorComponents()
                            .AddInteractiveServerComponents();            
            services.AddSignalR();
            services.AddSingleton<UserClientService>();
            services.AddSingleton<IUserImporter, UserImporter>();
            services.AddHostedService<UserImportRunningWorker>();
        }

    }
}
