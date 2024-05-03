using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReqSense.Application.Common.Interfaces;

namespace ReqSense.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class SuggestionsController(IGenerativeAiService genAiService) : ControllerBase
{
    [HttpGet("requirement/questions")]
    public async Task<IActionResult> GetQuestionsForRequirement([FromQuery] string requirementText)
    {
        // var questions = new List<string> { "Can user like others' comments?", "Can user reply to other comments?" };
        var questions = await genAiService.GenerateQuestionsForRequirementAsync(requirementText);
        return Ok(questions);
    }
}