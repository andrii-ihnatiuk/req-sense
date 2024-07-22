using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReqSense.API.Extensions;
using ReqSense.Application.Common.Interfaces;

namespace ReqSense.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class SuggestionsController(IGenerativeAiService genAiService) : ControllerBase
{
    [HttpGet("requirement/questions")]
    public async Task<IActionResult> GetQuestionsForRequirement(
        [FromQuery] string requirementText,
        [FromQuery] long projectId)
    {
        var genAiResult = await genAiService.GenerateQuestionsForRequirementAsync(requirementText, projectId);
        return genAiResult.Match(onSuccess: Ok, onFail: this.FromError);
    }

    [HttpGet("requirement/title")]
    public async Task<IActionResult> GetSuggestedRequirementTitle([FromQuery] string requirementText)
    {
        var title = await genAiService.GenerateRequirementTitle(requirementText);
        return Ok(new { title });
    }
}