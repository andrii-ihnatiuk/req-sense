using ReqSense.Application.Common.Models.Gemini;

namespace ReqSense.Application.Common.DTOs.GeminiAPI.Request;

public class GeminiRequest
{
    public ICollection<GeminiContent> Contents { get; set; } = new List<GeminiContent>();

    public GenerationConfig GenerationConfig { get; set; }

    public ICollection<SafetySetting> SafetySettings { get; set; } = new List<SafetySetting>();
}