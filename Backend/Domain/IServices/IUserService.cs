using Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain.IServices
{
    public interface IUserService
    {
        Task SaveUser(User user);
        Task<bool> ValidateExistence(User user);
        Task<User> ValidatePassword(int userID, string oldPassword);
        Task UpdatePassword(User user);
    }
}
