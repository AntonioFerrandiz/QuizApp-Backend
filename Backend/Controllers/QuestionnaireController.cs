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
    public class QuestionnaireController : ControllerBase
    {
        private readonly IQuestionnaireService _questionnaireService;
        public QuestionnaireController(IQuestionnaireService questionnaireService)
        {
            _questionnaireService = questionnaireService;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Post([FromBody]Questionnaire questionnaire)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int userID = JwtConfigurator.GetTokenUserID(identity);
                questionnaire.UserID = userID;
                questionnaire.Active = 1;
                questionnaire.DateCreated = DateTime.Now;
                await _questionnaireService.CreateQuestionnaire(questionnaire);
                return Ok(new { message = "Se agrego el cuestionario exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListQuestionnaireByUser")]
        [HttpGet]
        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetListQuestionnaireByUser()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int userID = JwtConfigurator.GetTokenUserID(identity);
                var listQuestionnaire = await _questionnaireService.GetListQuestionnaireByUser(userID);
                return Ok(listQuestionnaire);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{questionnaireID}")]
        public async Task<IActionResult> Get(int questionnaireID)
        {
            try
            {
                var questionnaire = await _questionnaireService.GetQuestionnaire(questionnaireID);
                return Ok(questionnaire);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{questionnaireID}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete(int questionnaireID)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int userID = JwtConfigurator.GetTokenUserID(identity);
                var questionnaire = await _questionnaireService.SearchQuestionnaire(questionnaireID, userID);
                if(questionnaire == null)
                {
                    return BadRequest(new { message = "No se encontro ningun cuestionario" });
                }
                await _questionnaireService.DeleteQuestionnaire(questionnaire);
                return Ok(new { message = "El cuestionario fue eliminado con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListQuestionnaires")]
        [HttpGet]
        public async Task<IActionResult> GetListQuestionnaires()
        {
            try
            {
                var questionnaireList = await _questionnaireService.GetListQuestionnaires();
                return Ok(questionnaireList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
