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
    public class QuestionnaireAnswerRepository: IQuestionnaireAnswerRepository
    {
        private readonly AplicationDbContext _context;
        public QuestionnaireAnswerRepository(AplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task SaveQuestionnaireAnswer(QuestionnaireAnswer questionnaireAnswer)
        {
            questionnaireAnswer.Active = 1;
            questionnaireAnswer.DateCreated = DateTime.Now;
            _context.Add(questionnaireAnswer);
            await _context.SaveChangesAsync();
        }

        public async Task<List<QuestionnaireAnswer>> ListQuestionnaireAnswers(int questionnaireId, int userId)
        {
            var listQuestionnaireAnswer = await _context.QuestionnaireAnswers
                .Where(x => x.QuestionnaireId == questionnaireId && x.Active == 1 && x.Questionnaire.UserID == userId)
                .OrderByDescending(x => x.DateCreated).ToListAsync();
            return listQuestionnaireAnswer;
        }

    }
}
