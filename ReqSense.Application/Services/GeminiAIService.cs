using Microsoft.EntityFrameworkCore;
using ReqSense.Application.Common.Errors;
using ReqSense.Application.Common.Interfaces;
using ReqSense.Application.Common.Models;
using ReqSense.Application.Common.Models.Gemini;
using ReqSense.Domain.Common;
using ReqSense.Domain.Constants;
using ReqSense.Domain.Entities;
using Result = ReqSense.Domain.Common.Result;

namespace ReqSense.Application.Services;

public class GeminiAiService(IGeminiClient geminiClient, IApplicationDbContext dbContext) : IGenerativeAiService
{
    public async Task<Result<RequirementQuestions>> GenerateQuestionsForRequirementAsync(string requirementText, long projectId)
    {
        var project = await dbContext.Projects.FirstOrDefaultAsync(e => e.Id.Equals(projectId));
        if (project is null)
        {
            return Result.Fail<RequirementQuestions>(ProjectErrors.NotFound(projectId));
        }

        var context = FormatProjectContext(project!);

        var requestBuilder = new GeminiRequestBuilder();
        var request = requestBuilder
            .SetGenerationConfig(GenerationConfig.Defaults)
            .SetSafetySettings(SafetySetting.Defaults)
            .AddContent(GeminiRoles.User)
            .WithPart(GeminiPart.Text(
                "You are a business analyst and your task is to ask the stakeholder questions about his/her requirement for the project product to make the requirement more complete and detailed. " +
                "Your output is a JSON object with an array of questions (maximum 3 questions). The answer must be in the same language as the stakeholder's requirement. " +
                $"This is some useful information about the project: {context}"))
            .WithPart(GeminiPart.Text(
                "requirement: As a user, I want to be able to create a personal account. " +
                "response: {\"questions\": [\"What do I need to create an account (email/login, name, password)?\", \"Is account confirmation required?\", \"Will there be automatic authorization after registration?\"]}"))
            .WithPart(GeminiPart.Text(
                "requirement: Як користувач блогу, я хочу мати можливість залишати коментарі під пости, щоб обмінюватися думками з іншими користувачами та автором. " +
                "response: {\"questions\": [\"Чи можуть коментарі містити медіаконтент (зображення, відео)?\", \"Чи будуть коментарі обмежені за довжиною або кількістю?\", \"Чи потрібна модерація чи затвердження коментарів перед публікацією?\"]}"))
            .WithPart(GeminiPart.Text(
                $"requirement: {requirementText} " +
                $"response:"))
            .Build();

        var questions = await geminiClient.GenerateContentAsync<RequirementQuestions>(request);
        return Result.Ok(questions);
    }

    public async Task<string> GenerateRequirementTitle(string requirementText)
    {
        var requestBuilder = new GeminiRequestBuilder();
        var request = requestBuilder
            .SetGenerationConfig(GenerationConfig.Defaults)
            .SetSafetySettings(SafetySetting.Defaults)
            .AddContent(GeminiRoles.User)
            .WithPart(GeminiPart.Text(
                "You are an intellectual system which generates title for requirement provided by stakeholder. " +
                "Title must be concise yet representing the core idea of the requirement. " +
                "Your output is a generated title as a text string. The answer must be in the same language as the stakeholder's requirement. "))
            .WithPart(GeminiPart.Text(
                "requirement: As a user, I want to receive email notification when the price of the starred product drops. " +
                "response: Price drop notifications"))
            .WithPart(GeminiPart.Text(
                "requirement: Як користувач блогу, я хочу мати можливість залишати коментарі під пости, щоб обмінюватися думками з іншими користувачами та автором. " +
                "response: Коментарі під постами блогу"))
            .WithPart(GeminiPart.Text(
                $"requirement: {requirementText} " +
                "response:"))
            .Build();

        var generatedTitle = await geminiClient.GenerateContentAsync(request);
        return generatedTitle;
    }

    private static string FormatProjectContext(Project project)
    {
        return $"Title: {project.Title}. " + (string.IsNullOrEmpty(project.Description)
            ? string.Empty
            : $"Description: {project.Description}.");
    }
}