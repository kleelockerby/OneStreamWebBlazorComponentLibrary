using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Radzen;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Syncfusion.Blazor;

namespace OneStreamWebBlazor.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Syncfusion 30 day trial license.
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjY3MDI1QDMxMzgyZTMxMmUzMEcvLzR2VEtGWHBSVkdTaWh3MzFTT0N4VVl0MzY4b0RPRDM2R2V0QzN3WjA9");
            
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            // Radzen specific services
            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();
            
            // Local storage service MIT lic
            builder.Services.AddBlazoredLocalStorage();
            
            builder.Services.AddAuthorizationCore();
            
            // Authentication service
            builder.Services.AddScoped<AuthenticationStateProvider, LocalAuthenticationStateProvider>();

            //
            builder.Services.AddSyncfusionBlazor();

            builder.Services.AddDevExpressBlazor();

            await builder.Build().RunAsync();
        }
    }
}
