using ReqSense.Application.Common.DTOs.GeminiAPI.Request;

namespace ReqSense.Application.Common.Interfaces;

public interface IGeminiClient
{
    Task<T> GenerateContentAsync<T>(GeminiRequest request, CancellationToken cancellationToken = default);
}