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
    public class LoginRepository: ILoginRepository
    {
        private readonly AplicationDbContext _context;
        public LoginRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> ValidateUser(User user)
        {
            var userL = await _context.Users.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefaultAsync();
            return userL;
        }
    }
}
