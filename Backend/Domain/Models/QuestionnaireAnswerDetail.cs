using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain.Models
{
    public class QuestionnaireAnswerDetail
    {
        public int Id { get; set; }
        public int QuestionnaireAnswerId { get; set; }
        public QuestionnaireAnswer QuestionnaireAnswer { get; set; }
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
    }
}
