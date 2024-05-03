namespace ReqSense.Application.Common.Models.Gemini;

public class GeminiContent
{
    public string Role { get; set; }

    public ICollection<GeminiPart> Parts { get; set; } = new List<GeminiPart>();
}