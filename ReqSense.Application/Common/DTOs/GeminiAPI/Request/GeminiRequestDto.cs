namespace ReqSense.Application.Common.DTOs.GeminiAPI.Request;

public class GeminiRequestDto
{
    public GeminiContent[] Contents { get; set; }

    public GenerationConfig GenerationConfig { get; set; }

    public SafetySettings[] SafetySettings { get; set; }
}