using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain.Models
{
    public class Questionnaire
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public int Active { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }

        public List<Question> questionsList { get; set; }
        
    }
}
