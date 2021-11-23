using Backend.Domain.IServices;
using Backend.Domain.Models;
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
    public class QuestionnaireAnswerController : ControllerBase
    {
        private readonly IQuestionnaireAnswerService _questionnaireAnswerService;
        public QuestionnaireAnswerController(IQuestionnaireAnswerService questionnaireAnswerService)
        {
            _questionnaireAnswerService = questionnaireAnswerService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] QuestionnaireAnswer questionnaireAnswer)
        {
            try
            {
                await _questionnaireAnswerService.SaveQuestionnaireAnswer(questionnaireAnswer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{questionnaireId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get(int questionnaireId)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int userID = JwtConfigurator.GetTokenUserID(identity);
                var listQuestionnaireAnswer = await _questionnaireAnswerService.ListQuestionnaireAnswers(questionnaireId, userID);

                if(listQuestionnaireAnswer == null)
                {
                    return BadRequest(new { message = "Error al buscar el listado de respuesta" });
                }

                return Ok(listQuestionnaireAnswer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
