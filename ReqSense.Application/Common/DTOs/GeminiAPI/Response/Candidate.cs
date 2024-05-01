namespace ReqSense.Application.Common.DTOs.GeminiAPI.Response;

public class Candidate
{
    public Content Content { get; set; }

    public string FinishReason { get; set; }

    public int Index { get; set; }
}