using InquistiveAI_Library.Constants;
using InquistiveAI_Library.Context;
using InquistiveAI_Library.DTO;
using InquistiveAI_Library.Exceptions;
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
        public async Task<UserdetailsDto> CheckUserCredentials(LoginDto login)
        {
            var employeeData = await this._context.Login.SingleOrDefaultAsync(employee => employee.AceId == login.AceId && employee.Password == login.Password);
            if (employeeData != null)
            {

                var employeeDetails = await this._context.EmployeeDetails
                                      .Where(employee => employee.AceId == employeeData.AceId)
                                      .SingleOrDefaultAsync();  // ✅ Throws an exception if multiple records exist
                if (employeeDetails != null)
                {
                    if (employeeDetails.RoleId == ConstantClass.trainer)
                    {
                        var userDetails = new UserdetailsDto
                        {
                            AceId = employeeDetails.AceId,
                            EmployeeName = employeeDetails.EmployeeName,
                            UserRole = ConstantClass.trainerRole
                        };

                        return userDetails;
                    }
                    else
                    {
                        if (employeeDetails.RoleId == ConstantClass.fresher)
                        {
                            var userDetails = new UserdetailsDto
                            {
                                AceId = employeeDetails.AceId,
                                EmployeeName = employeeDetails.EmployeeName,
                                UserRole = ConstantClass.fresherRole
                            };
                            return userDetails;
                        }
                        else
                        {
                            var userDetails = new UserdetailsDto
                            {
                                AceId = employeeDetails.AceId,
                                EmployeeName = employeeDetails.EmployeeName,
                                UserRole = ConstantClass.employeeRole
                            };
                            return userDetails;
                        }
                    }

                }

                throw new InvalidCredentialsException("Unable to get Data ");

            }
            throw new InvalidCredentialsException("Invalid Login Credentials");

        }

    }
}
