using ReqSense.Application.Common.DTOs.GeminiAPI.Request;

namespace ReqSense.Infrastructure.Gemini;

internal sealed class GeminiRequestFactory
{
    public static GeminiRequestDto CreateRequest(string prompt)
    {
        return new GeminiRequestDto
        {
            Contents =
            [
                new GeminiContent
                {
                    Role = "user",
                    Parts =
                    [
                        new GeminiPart
                        {
                            Text = prompt
                        }
                    ]
                }
            ],
            GenerationConfig = new GenerationConfig
            {
                Temperature = 0,
                TopK = 1,
                TopP = 1,
                MaxOutputTokens = 2048,
                StopSequences = []
            },
            SafetySettings =
            [
                new SafetySettings
                {
                    Category = "HARM_CATEGORY_HARASSMENT",
                    Threshold = "BLOCK_ONLY_HIGH"
                },
                new SafetySettings
                {
                    Category = "HARM_CATEGORY_HATE_SPEECH",
                    Threshold = "BLOCK_ONLY_HIGH"
                },
                new SafetySettings
                {
                    Category = "HARM_CATEGORY_SEXUALLY_EXPLICIT",
                    Threshold = "BLOCK_ONLY_HIGH"
                },
                new SafetySettings
                {
                    Category = "HARM_CATEGORY_DANGEROUS_CONTENT",
                    Threshold = "BLOCK_ONLY_HIGH"
                }
            ]
        };
    }
}