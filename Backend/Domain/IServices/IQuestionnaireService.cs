using Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain.IServices
{
    public interface IQuestionnaireService
    {
        Task CreateQuestionnaire(Questionnaire questionnaire);
        Task<List<Questionnaire>> GetListQuestionnaireByUser(int userID);
        Task<Questionnaire> GetQuestionnaire(int questionnaireID);
        Task<Questionnaire> SearchQuestionnaire(int questionnaireID, int userID);
        Task DeleteQuestionnaire(Questionnaire questionnaire);
        Task<List<Questionnaire>> GetListQuestionnaires();
    }
}
