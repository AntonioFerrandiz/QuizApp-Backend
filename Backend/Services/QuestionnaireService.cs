using Backend.Domain.IRepositories;
using Backend.Domain.IServices;
using Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class QuestionnaireService: IQuestionnaireService
    {
        private readonly IQuestionnaireRepository _questionnaireRepository;
        public QuestionnaireService(IQuestionnaireRepository questionnaireRepository)
        {
            _questionnaireRepository = questionnaireRepository;
        }
        public async Task CreateQuestionnaire(Questionnaire questionnaire)
        {
            await _questionnaireRepository.CreateQuestionnaire(questionnaire);
        }

        public async Task<List<Questionnaire>> GetListQuestionnaireByUser(int userID)
        {
            return await _questionnaireRepository.GetListQuestionnaireByUser(userID);
        }

        public async Task<Questionnaire> GetQuestionnaire(int questionnaireID)
        {
            return await _questionnaireRepository.GetQuestionnaire(questionnaireID);
        }

        public async Task<Questionnaire> SearchQuestionnaire(int questionnaireID, int userID)
        {
            return await _questionnaireRepository.SearchQuestionnaire(questionnaireID, userID);
        }
        public async Task DeleteQuestionnaire(Questionnaire questionnaire)
        {
            await _questionnaireRepository.DeleteQuestionnaire(questionnaire);
        }

        public async Task<List<Questionnaire>> GetListQuestionnaires()
        {
            return await _questionnaireRepository.GetListQuestionnaires();
        }
    }
}
