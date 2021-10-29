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
    public class UserRepository: IUserRepository
    {
        private readonly AplicationDbContext _context;
        public UserRepository(AplicationDbContext context)
        {
            _context = context;
        }
        public async Task SaveUser(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistence(User user)
        {
            var validateExistence = await _context.Users.AnyAsync(x => x.Username == user.Username);
            return validateExistence;
        }

        public async Task<User> ValidatePassword(int userID, string oldPassword)
        {
            var user = await _context.Users.Where(x => x.Id == userID && x.Password == oldPassword).FirstOrDefaultAsync();
            return user;
        }
        public async Task UpdatePassword(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
