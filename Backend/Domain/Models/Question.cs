using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain.Models
{
    public class Question
    {
        public int Id{ get; set; }

        [Required]
        [Column(TypeName ="varchar(100)")]
        public string Description { get; set; }

        public int QuestionnaireId { get; set; }
        public Questionnaire Questionnaire { get; set; }
        public List<Answer> answerList { get; set; }
    }
}
