using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain.Models
{
    public class QuestionnaireAnswer
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Playername { get; set; }

        public DateTime DateCreated { get; set; }
        public int Active { get; set; }
        public int QuestionnaireId { get; set; }
        public Questionnaire Questionnaire { get; set; }
        public List<QuestionnaireAnswerDetail> ListQuestionnaireAnswerDetail { get; set; }


    }
}
