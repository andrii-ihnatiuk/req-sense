using ReqSense.Application.Common.DTOs.GeminiAPI.Request;
using ReqSense.Application.Common.Models.Gemini;
using ReqSense.Domain.Constants;

namespace ReqSense.Application.Services;

public class GeminiRequestBuilder
{
    private readonly GeminiRequest _request = new GeminiRequest();

    public GeminiRequestBuilder AddContent(string geminiRole)
    {
        _request.Contents.Add(new GeminiContent { Role = geminiRole });
        return this;
    }

    public GeminiRequestBuilder WithPart(GeminiPart part)
    {
        if (_request.Contents.Count == 0)
        {
            AddContent(GeminiRoles.User);
        }

        _request.Contents.Last().Parts.Add(part);
        return this;
    }

    public GeminiRequestBuilder SetGenerationConfig(GenerationConfig config)
    {
        _request.GenerationConfig = config;
        return this;
    }

    public GeminiRequestBuilder SetSafetySettings(ICollection<SafetySetting> settings)
    {
        _request.SafetySettings = settings;
        return this;
    }

    public GeminiRequest Build()
    {
        return _request;
    }
}