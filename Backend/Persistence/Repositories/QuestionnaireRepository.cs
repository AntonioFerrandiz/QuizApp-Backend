using Backend.Domain.IRepositories;
using Backend.Domain.Models;
using Backend.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Persistence.Repositories
{
    
    public class QuestionnaireRepository: IQuestionnaireRepository
    {
        private readonly AplicationDbContext _context;
        public QuestionnaireRepository(AplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateQuestionnaire(Questionnaire questionnaire)
        {
            _context.Add(questionnaire);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Questionnaire>> GetListQuestionnaireByUser(int userID)
        {
            var listQuestionnaire = await _context.Questionnaires.Where(x => x.Active == 1 && x.UserID == userID).ToListAsync();
            return listQuestionnaire;

        }

        public async Task<Questionnaire> GetQuestionnaire(int questionnaireID)
        {
            var questionnanire = await _context.Questionnaires.Where(x => x.Id == questionnaireID && x.Active == 1)
                .Include(x => x.questionsList)
                .ThenInclude(x => x.answerList)
                .FirstOrDefaultAsync();
            return questionnanire;
        }

        public async Task<Questionnaire> SearchQuestionnaire(int questionnaireID, int userID)
        {
            var questionnaire = await _context.Questionnaires.Where(x => x.Id == questionnaireID && x.Active == 1 && x.UserID == userID).FirstOrDefaultAsync();
            return questionnaire;
        }

        public async Task DeleteQuestionnaire(Questionnaire questionnaire)
        {
            questionnaire.Active = 0;
            _context.Entry(questionnaire).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Questionnaire>> GetListQuestionnaires()
        {
            var questionnaireList = await _context.Questionnaires.Where(x => x.Active == 1).Select(o => new Questionnaire
            {
                Id = o.Id,
                Name = o.Name,
                Description = o.Description,
                DateCreated = o.DateCreated,
                User = new User { Username = o.User.Username }
            }).ToListAsync();
            
            return questionnaireList;
        }

    }
}
