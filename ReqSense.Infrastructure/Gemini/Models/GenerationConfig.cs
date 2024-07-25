namespace ReqSense.Infrastructure.Gemini.Models;

public class GenerationConfig
{
    public float Temperature { get; set; }

    public int TopK { get; set; }

    public float TopP { get; set; }

    public int MaxOutputTokens { get; set; }

    public List<object> StopSequences { get; set; }

    public static GenerationConfig Defaults => new()
    {
        Temperature = 0.7f,
        TopK = 2,
        TopP = 1,
        MaxOutputTokens = 2048,
        StopSequences = []
    };
}