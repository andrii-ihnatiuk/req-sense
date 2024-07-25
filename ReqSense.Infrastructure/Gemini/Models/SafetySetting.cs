namespace ReqSense.Infrastructure.Gemini.Models;

public class SafetySetting
{
    public string Category { get; set; }

    public string Threshold { get; set; }

    public static ICollection<SafetySetting> Defaults =>
    [
        new SafetySetting
        {
            Category = "HARM_CATEGORY_HARASSMENT",
            Threshold = "BLOCK_ONLY_HIGH"
        },
        new SafetySetting
        {
            Category = "HARM_CATEGORY_HATE_SPEECH",
            Threshold = "BLOCK_ONLY_HIGH"
        },
        new SafetySetting
        {
            Category = "HARM_CATEGORY_SEXUALLY_EXPLICIT",
            Threshold = "BLOCK_ONLY_HIGH"
        },
        new SafetySetting
        {
            Category = "HARM_CATEGORY_DANGEROUS_CONTENT",
            Threshold = "BLOCK_ONLY_HIGH"
        }
    ];
}