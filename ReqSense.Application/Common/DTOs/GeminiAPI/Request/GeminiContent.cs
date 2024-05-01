namespace ReqSense.Application.Common.DTOs.GeminiAPI.Request;

public class GeminiContent
{
    public string Role { get; set; }

    public GeminiPart[] Parts { get; set; }
}