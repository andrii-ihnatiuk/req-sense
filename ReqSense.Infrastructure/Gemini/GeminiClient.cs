using System.Net.Mime;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ReqSense.Application.Common.DTOs.GeminiAPI.Response;
using ReqSense.Application.Common.Exceptions;
using ReqSense.Application.Common.Interfaces;

namespace ReqSense.Infrastructure.Gemini;

internal sealed class GeminiClient(HttpClient httpClient)
    : IGeminiClient
{
    private readonly JsonSerializerSettings _serializerSettings = new()
    {
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        }
    };

    public async Task<string> GenerateContentAsync(string prompt, CancellationToken cancellationToken = default)
    {
        var requestBody = GeminiRequestFactory.CreateRequest(prompt);
        var content = new StringContent(
            JsonConvert.SerializeObject(requestBody, Formatting.None, _serializerSettings),
            Encoding.UTF8,
            MediaTypeNames.Application.Json);

        var response = await httpClient.PostAsync(string.Empty, content, cancellationToken);
        GeminiException.ThrowIfFalse(response.IsSuccessStatusCode, $"Received {response.StatusCode} status code.");

        var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
        var geminiResponse = JsonConvert.DeserializeObject<GeminiResponseDto>(responseBody);
        GeminiException.ThrowIfNull(geminiResponse, "Could not deserialize response body.");
        var geminiResponseText = geminiResponse!.Candidates[0].Content.Parts[0].Text;

        return geminiResponseText;
    }
}