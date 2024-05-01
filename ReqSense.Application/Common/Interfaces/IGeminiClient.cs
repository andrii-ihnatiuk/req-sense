namespace ReqSense.Application.Common.Interfaces;

public interface IGeminiClient
{
    Task<string> GenerateContentAsync(string prompt, CancellationToken cancellationToken = default);
}