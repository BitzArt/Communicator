using MudBlazor.SampleApp.Components;
using MudBlazor.Services;

namespace MudBlazor.SampleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddMudServices();
            builder.Services.AddRazorComponents()
                .AddInteractiveWebAssemblyComponents();

            builder.Services.AddFlux("http://localhost");

            var app = builder.Build();

            app.UseWebAssemblyDebugging();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapDataEndpoints();
            app.MapRazorComponents<App>()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            app.Run();
        }
    }
}
