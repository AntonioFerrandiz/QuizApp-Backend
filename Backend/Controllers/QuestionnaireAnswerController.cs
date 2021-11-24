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
        private readonly IQuestionnaireService _questionnaireService;
        public QuestionnaireAnswerController(IQuestionnaireAnswerService questionnaireAnswerService, IQuestionnaireService questionnaireService)
        {
            _questionnaireAnswerService = questionnaireAnswerService;
            _questionnaireService = questionnaireService;
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

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int userID = JwtConfigurator.GetTokenUserID(identity);

                var questionAnswer = await _questionnaireAnswerService.FindQuestionnaireAnswer(id, userID);
                if(questionAnswer == null)
                {
                    return BadRequest(new { message = "Error al buscar la respuesta al cuestionario" });
                }

                await _questionnaireAnswerService.DeleteQuestionnaireAnswer(questionAnswer);
                return Ok(new { message = "La respuesta al cuestionario fue eliminada con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetQuestionnaireByAnswerId/{answerId}")]
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetQuestionnaireByAnswerId(int answerId)
        {
            try
            {
                int questionnaireId = await _questionnaireAnswerService.GetQuestionnaireIDByAnswerID(answerId);
                var questionnaire = await _questionnaireService.GetQuestionnaire(questionnaireId);
                var answersList = await _questionnaireAnswerService.GetAnswerList(answerId);
                return Ok(new { questionnaire = questionnaire, answers = answersList });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
