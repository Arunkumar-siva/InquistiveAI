using Microsoft.AspNetCore.Mvc;
using InquistiveAI_Library.DTO;
using InquistiveAI_Library.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InquistiveAI_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDetailsDto employeeDto)
        {
            try
            {
                var employee = await _unitOfWork.Employee.CreateEmployee(employeeDto);
                if (employee == null)
                {
                    return BadRequest("Employee creation failed.");
                }

                await _unitOfWork.CommitAsync();
                return CreatedAtAction(nameof(GetEmployees), new { aceId = employee.AceId }, employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An unexpected error occurred.", details = ex.Message });
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetEmployees([FromQuery] int? batchId, [FromQuery] int? roleId)
        {
            try
            {
                // If both parameters are null, return a bad request message
                if (!batchId.HasValue && !roleId.HasValue)
                {
                    return BadRequest("Please provide at least one filter parameter: batchId or roleId.");
                }

                var employees = await _unitOfWork.Employee.GetEmployees(batchId, roleId);

                if (employees == null || !employees.Any())
                {
                    return NotFound("No employees found with the given filters.");
                }

                return Ok(employees);
            }

            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An unexpected error occurred.", details = ex.Message });
            }
        }

        [HttpGet("{aceId}")]
        public async Task<IActionResult> GetEmployeeByAceId(string aceId)
        {
            try
            {
                var employee = await _unitOfWork.Employee.GetEmployeeByAceId(aceId);
                if (employee == null)
                {
                    return NotFound($"Employee with AceId {aceId} not found.");
                }

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An unexpected error occurred.", details = ex.Message });
            }
        }

        [HttpPut("{aceId}")]
        public async Task<IActionResult> UpdateEmployee(string aceId, [FromBody] EmployeeDetailsDto updateDto)
        {
            try
            {
                var updatedEmployee = await _unitOfWork.Employee.UpdateEmployee(aceId, updateDto);
                if (updatedEmployee == null)
                {
                    return NotFound($"Employee with AceId {aceId} not found.");
                }

                await _unitOfWork.CommitAsync();
                return Ok(updatedEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An unexpected error occurred.", details = ex.Message });
            }
        }

        [HttpDelete("{aceId}")]
        public async Task<IActionResult> DeleteEmployee(string aceId)
        {
            try
            {
                var isDeleted = await _unitOfWork.Employee.DeleteEmployee(aceId);
                if (!isDeleted)
                {
                    return NotFound($"Employee with AceId {aceId} not found.");
                }

                await _unitOfWork.CommitAsync();
                return Ok($"Employee with AceId {aceId} deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An unexpected error occurred.", details = ex.Message });
            }
        }
    }
}
