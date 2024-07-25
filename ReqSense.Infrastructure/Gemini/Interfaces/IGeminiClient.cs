using ReqSense.Infrastructure.Gemini.DTOs.Request;

namespace ReqSense.Infrastructure.Gemini.Interfaces;

public interface IGeminiClient
{
    Task<T> GenerateContentAsync<T>(GeminiRequest request, CancellationToken cancellationToken = default);

    Task<string> GenerateContentAsync(GeminiRequest request, CancellationToken cancellationToken = default);
}