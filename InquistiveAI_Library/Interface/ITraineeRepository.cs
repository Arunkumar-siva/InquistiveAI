using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InquisitiveAiLibrary.Model;
using InquistiveAI_Library.DTO;


namespace InquistiveAI_Library.Interface
{
    public interface ITraineeRepository
    {
     Task<EmployeeDetailsDTO> GetEmployeeDetailById(string aceId);
     Task<List<EmployeeAssessmentDto>> GetAssessmentDetailsById(string aceId);
     Task<AssessmentDetailDto> GetAssessmentByAceId(string aceId);
     Task<string> GetAssessmentFeedBack(string aceId);
    }
}
