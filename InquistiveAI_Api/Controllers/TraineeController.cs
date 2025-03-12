using Microsoft.AspNetCore.Mvc;
using InquisitiveAiLibrary.Model;
using InquistiveAI_Library.Interface;
using InquistiveAI_Library.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace InquistiveAI_Api.Controllers
{
    [ApiController]
    public class TraineeController : ControllerBase
    {
         private readonly ITraineeRepository _traineeRepository;

        public TraineeController(ITraineeRepository traineeRepository)
        {
            this._traineeRepository = traineeRepository;
        }

        [HttpGet("api/dashBoard/{aceId}")]
        
        public async Task<IActionResult> GetEmployeeDetailById(string aceId)
        {
            try{
                var response = await this._traineeRepository.GetEmployeeDetailById(aceId);
                if(response.AceId != null){
                    return Ok(response);
                }
                return Ok($"{aceId} dose not Exists");
            }
            catch(Exception exception){
                 return BadRequest(exception.Message);
            }
        }

         [HttpGet("api/assessment/{aceId}")]
        
        public async Task<IActionResult> GetAssessmentDetailsById(string aceId)
        {
            try{
                var response = await this._traineeRepository.GetAssessmentDetailsById(aceId);
                int length = response.Count();
                if(length > 0){
                    return Ok(response);
                }
                return Ok($"No Assessment started");
            } 
            catch(Exception exception){
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("api/assessment/takeAssessment/{aceId}")]

        public async Task<IActionResult> TakeAssessment(string aceId){
            try{
                var response = await this._traineeRepository.GetAssessmentByAceId(aceId);
                if(response !=null){
                    return Ok(response);
                }
                return Ok($"No Assessment Added");
            } 
            catch(Exception exception){
                return BadRequest(exception.Message);
            }
        }

         [HttpGet("api/assessment/FeedBack/{aceId}")]

        public async Task<IActionResult> GetAssessmentFeedBack(string aceId){
            try{
                var response = await this._traineeRepository.GetAssessmentFeedBack(aceId);
                if(response !=null){
                    return Ok(response);
                }
                return NotFound();
            } 
            catch(Exception exception){
                return BadRequest(exception.Message);
            }
        }


    }
}
