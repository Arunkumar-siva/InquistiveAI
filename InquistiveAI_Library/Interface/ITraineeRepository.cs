using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InquistiveAI_Library.DTO;


namespace InquistiveAI_Library.Interface
{
    public interface ITraineeRepository
    {
     Task<EmployeeDetailsDto> GetEmployeeDetailById(string aceId);
     Task<List<EmployeeAssessmentDto>> GetAssessmentDetailsById(string aceId);
    }
}
