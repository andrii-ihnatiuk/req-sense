using ReqSense.Application.Common.Models;
using ReqSense.Domain.Common;

namespace ReqSense.Application.Common.Interfaces;

public interface IGenerativeAiService
{
    Task<Result<RequirementQuestions>> GenerateQuestionsForRequirementAsync(string requirementText, long projectId);

    Task<string> GenerateRequirementTitle(string requirementText);
}