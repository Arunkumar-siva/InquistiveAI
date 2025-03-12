using Microsoft.AspNetCore.Mvc;
using InquistiveAI_Library.DTO;
using InquistiveAI_Library.Interface;
using InquistiveAI_Library.Exceptions;

// API Controller to handle Employee-related operations
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

        /// <summary>
        /// Creates a new employee record.
        /// </summary>
        /// <param name="employeeDto">Employee details DTO</param>
        /// <returns>Returns the created employee object</returns>
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDetailsDto employeeDto)
        {
            try
            {
                // Attempt to create a new employee record
                var response = await _unitOfWork.Employee.CreateEmployee(employeeDto);
                if (response)
                {
                    // Save changes to the database
                    await _unitOfWork.CommitAsync();
                    return Ok($"{employeeDto.AceId} {employeeDto.EmployeeName} added Successfully");

                }

                return BadRequest("Unable to Add New Employee");

            }
            catch (AssessmentNotFoundException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An unexpected error occurred.", details = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves employees based on batchId and roleId filters.
        /// </summary>
        /// <param name="batchId">Optional batch ID filter</param>
        /// <param name="roleId">Optional role ID filter</param>
        /// <returns>List of employees matching the filters</returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetEmployees([FromQuery] int? batchId, [FromQuery] int? roleId)
        {
            try
            {
                // Ensuring at least one filtering parameter is provided
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

        /// <summary>
        /// Retrieves an employee by AceId.
        /// </summary>
        /// <param name="aceId">Unique identifier for the employee</param>
        /// <returns>Employee details if found</returns>
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

        /// <summary>
        /// Updates an existing employee record.
        /// </summary>
        /// <param name="aceId">Employee unique identifier</param>
        /// <param name="updateDto">Updated employee details</param>
        /// <returns>Updated employee object</returns>
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

                // Save updated changes to the database
                await _unitOfWork.CommitAsync();
                return Ok(updatedEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An unexpected error occurred.", details = ex.Message });
            }
        }

        /// <summary>
        /// Deletes an employee record.
        /// </summary>
        /// <param name="aceId">Employee unique identifier</param>
        /// <returns>Success or failure response</returns>
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

                // Ensure the delete operation is committed
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
