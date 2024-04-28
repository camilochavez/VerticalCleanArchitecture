using SLinkUser.Host.Common;
using SLinkUser.Host.Components;
using SLinkUser.Host.DependencyInjection;
using SLinkUser.Host.Hub;

internal class Program
{    
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddHttpClient(SLinkUserConst.HttpClientName, httpClient =>
        {
            httpClient.BaseAddress = new Uri(SLinkUserConst.ApiUrl);
        });

        // Add services to the container.
        builder.Services.RegisterApiServices();

        var app = builder.Build();        
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.MapHub<MessagingUserImportHub>("/signalr-messaging");
        app.MapRazorComponents<App>()
           .AddInteractiveServerRenderMode();        

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();
 

        app.Run();
    }
}