using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="varchar(20)")]
        public string Username { get; set; }
        //[Required]
        //[Column(TypeName ="varchar(100)")]
        //public string Email { get; set; }
        //[Column(TypeName ="varchar(50)")]
        [Required]
        public string Password { get; set; }
    }
}
