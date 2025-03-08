using InquisitiveAiLibrary.Model;
using InquistiveAI_Library.Context;
using InquistiveAI_Library.DTO;
using InquistiveAI_Library.Interface;
using InquistiveAI_Library.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquistiveAI_Library.Repository
{
    public class HomeRepository : IHomeRepository
    {

        private readonly ApplicationDbContext _context;
        public HomeRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<EmployeeDetails> CheckUserCredentials(LoginDto login)
        {
            var employeeData = await this._context.Login.FirstOrDefaultAsync(employee => employee.AceId == login.AceId && employee.Password == login.Password);
            if (employeeData != null)
            {
                var employeeDetails = await this._context.EmployeeDetails
                                      .Where(employee => employee.AceId == employeeData.AceId)
                                      .Include(employee => employee.BatchDetails)
                                      .Include(employee => employee.Roles)
                                      .Include(employee => employee.EmployeeAssessmentDetails)
                                      .FirstOrDefaultAsync();  // ✅ Throws an exception if multiple records exist
                if (employeeDetails != null)
                {
                    return employeeDetails;
                }



            }

            return null;

        }
    }
}
