namespace ReqSense.Infrastructure.Gemini.Models;

public class GeminiContent
{
    public string Role { get; set; }

    public ICollection<GeminiPart> Parts { get; set; } = new List<GeminiPart>();
}