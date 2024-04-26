using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReqSense.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class SuggestionsController : ControllerBase
{
    public SuggestionsController()
    {
    }

    [HttpGet("requirement/questions")]
    public async Task<IActionResult> GetQuestionsForRequirement()
    {
        var questions = new List<string> { "Can user like others' comments?", "Can user reply to other comments?" };
        await Task.Delay(2000);
        return Ok(questions);
    }
}