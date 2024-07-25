using ReqSense.Infrastructure.Gemini.Models;

namespace ReqSense.Infrastructure.Gemini.DTOs.Request;

public class GeminiRequest
{
    public ICollection<GeminiContent> Contents { get; set; } = new List<GeminiContent>();

    public GenerationConfig GenerationConfig { get; set; }

    public ICollection<SafetySetting> SafetySettings { get; set; } = new List<SafetySetting>();
}