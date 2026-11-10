using DigiTax.Api;
using DigiTax_demo.Blazor.Components;
using DigiTax_demo.Blazor.Configuration;
using Microsoft.Extensions.Options;

namespace DigiTax_demo.Blazor;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        builder.Services.AddOptions<DigiTaxApiOptions>()
            .Bind(builder.Configuration.GetSection(DigiTaxApiOptions.SectionName))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        builder.Services.AddTransient<DigiTaxApiKeyHandler>();
        builder.Services.AddHttpClient<DigiTaxOpenApiClient>((serviceProvider, client) =>
            {
                var options = serviceProvider.GetRequiredService<IOptions<DigiTaxApiOptions>>().Value;
                client.BaseAddress = new Uri(options.BaseUrl, UriKind.Absolute);
            })
            .AddHttpMessageHandler<DigiTaxApiKeyHandler>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
        app.UseHttpsRedirection();

        app.UseAntiforgery();

        app.MapStaticAssets();
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}
