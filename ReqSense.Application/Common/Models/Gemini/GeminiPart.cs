namespace ReqSense.Application.Common.Models.Gemini;

public abstract class GeminiPart
{
    public static GeminiPart Text(string text)
    {
        return new GeminiTextPart { Text = text };
    }
}