﻿using Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain.IServices
{
    public interface IQuestionnaireAnswerService
    {
        Task SaveQuestionnaireAnswer(QuestionnaireAnswer questionnaireAnswer);
        Task<List<QuestionnaireAnswer>> ListQuestionnaireAnswers(int questionnaireId, int userId);

    }
}
