﻿using ReqSense.Application.Common.Models;

namespace ReqSense.Application.Common.Interfaces;

public interface IGenerativeAiService
{
    Task<RequirementQuestions> GenerateQuestionsForRequirementAsync(string requirementText, long projectId);

    Task<string> GenerateRequirementTitle(string requirementText);
}