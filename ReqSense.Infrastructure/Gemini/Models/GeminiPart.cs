namespace ReqSense.Infrastructure.Gemini.Models;

public abstract class GeminiPart
{
    public static GeminiPart Text(string text)
    {
        return new GeminiTextPart { Text = text };
    }
}