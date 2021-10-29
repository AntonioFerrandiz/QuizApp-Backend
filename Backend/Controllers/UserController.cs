using Backend.Domain.IServices;
using Backend.Domain.Models;
using Backend.DTO;
using Backend.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService  _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]User user)
        {
            try
            {
                var validateExistence = await _userService.ValidateExistence(user);
                if (validateExistence)
                {
                    return BadRequest(new { message = "El usuario " + user.Username + " ya existe" });
                }
                user.Password = Encrypt.EncryptPassword(user.Password);
                await _userService.SaveUser(user);
                return Ok(new { message = "Usuario registrado con exito." });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // quizapp/api/User/ChangePassword
        [Route("ChangePassword")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO changePassword)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int userID = JwtConfigurator.GetTokenUserID(identity);
                string passwordEncrypt = Encrypt.EncryptPassword(changePassword.oldPassword);
                var user = await _userService.ValidatePassword(userID, passwordEncrypt);
                if(user == null)
                {
                    return BadRequest(new { message = "La password es incorrecta" });
                }
                else
                {
                    user.Password = Encrypt.EncryptPassword(changePassword.newPassword);
                    await _userService.UpdatePassword(user);
                    return Ok(new { message = "La password fue actualizada con exito" });
                }
                
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
