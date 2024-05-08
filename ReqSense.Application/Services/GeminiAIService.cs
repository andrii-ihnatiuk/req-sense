using Microsoft.EntityFrameworkCore;
using ReqSense.Application.Common.Exceptions;
using ReqSense.Application.Common.Interfaces;
using ReqSense.Application.Common.Models;
using ReqSense.Application.Common.Models.Gemini;
using ReqSense.Domain.Constants;
using ReqSense.Domain.Entities;

namespace ReqSense.Application.Services;

public class GeminiAiService(IGeminiClient geminiClient, IApplicationDbContext dbContext) : IGenerativeAiService
{
    public async Task<RequirementQuestions> GenerateQuestionsForRequirementAsync(string requirementText, long projectId)
    {
        var project = await dbContext.Projects.FirstOrDefaultAsync(e => e.Id.Equals(projectId));
        NotFoundException.ThrowIfNull(project, $"The project with id {projectId} was not found.");
        var context = FormatProjectContext(project!);

        var requestBuilder = new GeminiRequestBuilder();
        var request = requestBuilder
            .SetGenerationConfig(GenerationConfig.Defaults)
            .SetSafetySettings(SafetySetting.Defaults)
            .AddContent(GeminiRoles.User)
            .WithPart(GeminiPart.Text(
                "You are a business analyst and your task is to ask the stakeholder questions about his/her requirement for the project product to make the requirement more complete and detailed. " +
                "Your output is a JSON object with an array of questions (maximum 3 questions). The answer should be in the same language as the stakeholder's requirement. " +
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
        return questions;
    }

    private static string FormatProjectContext(Project project)
    {
        return $"Title: {project.Title}. " + (string.IsNullOrEmpty(project.Description)
            ? string.Empty
            : $"Description: {project.Description}.");
    }
}