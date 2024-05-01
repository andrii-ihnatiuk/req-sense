using Microsoft.Extensions.Options;
using ReqSense.Domain.Options;

namespace ReqSense.Infrastructure.HttpHandlers;

internal sealed class GeminiHttpHandler(IOptions<GeminiOptions> geminiOptions)
    : DelegatingHandler
{
    private const string GeminiAuthHeader = "x-goog-api-key";
    private readonly GeminiOptions _geminiOptions = geminiOptions.Value;

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add(GeminiAuthHeader, _geminiOptions.ApiKey);
        return base.SendAsync(request, cancellationToken);
    }
}