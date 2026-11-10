using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace DigiTax_demo.Blazor.Configuration;

public sealed class DigiTaxApiOptions
{
    public const string SectionName = "DigiTaxApi";

    [Required, Url]
    public string BaseUrl { get; set; } = "";

    [Required, MinLength(1)]
    public string ApiKey { get; set; } = "";
}

public sealed class DigiTaxApiKeyHandler(IOptions<DigiTaxApiOptions> options) : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        request.Headers.Remove("X-API-Key");
        request.Headers.Add("X-API-Key", options.Value.ApiKey);

        return base.SendAsync(request, cancellationToken);
    }
}
