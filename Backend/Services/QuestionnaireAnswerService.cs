using Backend.Domain.IRepositories;
using Backend.Domain.IServices;
using Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class QuestionnaireAnswerService: IQuestionnaireAnswerService
    {
        private readonly IQuestionnaireAnswerRepository _questionnaireAnswerRepository;
        public QuestionnaireAnswerService(IQuestionnaireAnswerRepository  questionnaireAnswerRepository)
        {
            _questionnaireAnswerRepository = questionnaireAnswerRepository;
        }

        public async Task<List<QuestionnaireAnswer>> ListQuestionnaireAnswers(int questionnaireId, int userId)
        {
            return await _questionnaireAnswerRepository.ListQuestionnaireAnswers(questionnaireId, userId);
        }

        public async Task SaveQuestionnaireAnswer(QuestionnaireAnswer questionnaireAnswer)
        {
            await _questionnaireAnswerRepository.SaveQuestionnaireAnswer(questionnaireAnswer);
        }


    }
}
