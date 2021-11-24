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

        public Task DeleteQuestionnaireAnswer(QuestionnaireAnswer questionnaireAnswer)
        {
            return _questionnaireAnswerRepository.DeleteQuestionnaireAnswer(questionnaireAnswer);
        }

        public async Task<QuestionnaireAnswer> FindQuestionnaireAnswer(int questionnanireAnswerId, int userId)
        {
            return await _questionnaireAnswerRepository.FindQuestionnaireAnswer(questionnanireAnswerId, userId);
        }

        public async Task<List<QuestionnaireAnswer>> ListQuestionnaireAnswers(int questionnaireId, int userId)
        {
            return await _questionnaireAnswerRepository.ListQuestionnaireAnswers(questionnaireId, userId);
        }

        public async Task SaveQuestionnaireAnswer(QuestionnaireAnswer questionnaireAnswer)
        {
            await _questionnaireAnswerRepository.SaveQuestionnaireAnswer(questionnaireAnswer);
        }

        public async Task<int> GetQuestionnaireIDByAnswerID(int questionnanireAnswerId)
        {
            return await _questionnaireAnswerRepository.GetQuestionnaireIDByAnswerID(questionnanireAnswerId);
        }

        public async Task<List<QuestionnaireAnswerDetail>> GetAnswerList(int questionnanireAnswerId)
        {
            return await _questionnaireAnswerRepository.GetAnswerList(questionnanireAnswerId);
        }
    }
}
