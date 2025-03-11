using Microsoft.AspNetCore.Mvc;
using InquisitiveAiLibrary.Model;
using InquistiveAI_Library.Interface;
using InquistiveAI_Library.DTO;

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
        
        public Task<EmployeeDetailsDTO> GetEmployeeDetailById(string aceId)
        {
            return this._traineeRepository.GetEmployeeDetailById(aceId);
        }

         [HttpGet("api/assessment/{aceId}")]
        
        public Task<List<EmployeeAssessmentDto>> GetAssessmentDetailsById(string aceId)
        {
            return this._traineeRepository.GetAssessmentDetailsById(aceId);
        }


    }
}
