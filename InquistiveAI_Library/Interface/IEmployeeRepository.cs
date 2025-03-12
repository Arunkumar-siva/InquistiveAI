using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InquistiveAI_Library.DTO;
using InquistiveAI_Library.Model;

namespace InquistiveAI_Library.Interface
{
    public interface IEmployeeRepository
    {
        Task<EmployeeDetails> CreateEmployee(EmployeeDetailsDto employeeDto);
        Task<IEnumerable<EmployeeDetails>> GetEmployees(int? batchId, int? roleId);
        Task<EmployeeDetails> GetEmployeeByAceId(string aceId);
        Task<EmployeeDetails> UpdateEmployee(string aceId, EmployeeDetailsDto updateDto);
        Task<bool> DeleteEmployee(string aceId);
    }
}
