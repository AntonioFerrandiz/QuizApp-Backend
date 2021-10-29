using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTO
{
    public class ChangePasswordDTO
    {
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }
}
