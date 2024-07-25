namespace ReqSense.Infrastructure.Gemini.DTOs.Response;

public class Candidate
{
    public Content Content { get; set; }

    public string FinishReason { get; set; }

    public int Index { get; set; }
}