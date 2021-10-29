using Backend.Domain.IRepositories;
using Backend.Domain.IServices;
using Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class LoginService: ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginrepository)
        {
            _loginRepository = loginrepository;
        }

        public async Task<User> ValidateUser(User user)
        {
            return await _loginRepository.ValidateUser(user);
        }
    }
}
