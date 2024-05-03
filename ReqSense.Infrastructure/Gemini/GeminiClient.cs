﻿using System.Net.Mime;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ReqSense.Application.Common.DTOs.GeminiAPI.Request;
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
            NamingStrategy = new CamelCaseNamingStrategy()
        }
    };

    public async Task<T> GenerateContentAsync<T>(GeminiRequest request, CancellationToken cancellationToken = default)
    {
        var content = new StringContent(
            JsonConvert.SerializeObject(request, Formatting.None, _serializerSettings),
            Encoding.UTF8,
            MediaTypeNames.Application.Json);

        var response = await httpClient.PostAsync(string.Empty, content, cancellationToken);
        GeminiException.ThrowIfFalse(response.IsSuccessStatusCode, $"Received {response.StatusCode} status code.");

        var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
        var geminiResponse = JsonConvert.DeserializeObject<GeminiResponseDto>(responseBody);
        GeminiException.ThrowIfNull(geminiResponse, "Could not deserialize response body.");
        var resultObject = JsonConvert.DeserializeObject<T>(geminiResponse!.Candidates[0].Content.Parts[0].Text);
        GeminiException.ThrowIfNull(resultObject, "Could not deserialize response text to the given type.");

        return resultObject!;
    }
}