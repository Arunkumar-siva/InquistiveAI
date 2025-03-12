﻿using InquistiveAI_Library.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InquistiveAI_Library.DTO;
using InquistiveAI_Library.Model;
using InquistiveAI_Library.Context;
using InquistiveAI_Library.Helpers;
using Microsoft.EntityFrameworkCore;



namespace InquistiveAI_Library.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Creates a new employee and their login entry
        public async Task<EmployeeDetails> CreateEmployee(EmployeeDetailsDto employeeDto)
        {
            // Generate a random password
            string randomPassword = PasswordHelper.GenerateRandomPassword();

            // Create a new employee entry
            var employee = new EmployeeDetails
            {
                AceId = employeeDto.AceId,
                EmployeeName = employeeDto.EmployeeName,
                BatchId = employeeDto.BatchId,
                RoleId = employeeDto.RoleId
            };

            await _context.EmployeeDetails.AddAsync(employee);

            // Create a login entry
            var login = new Login
            {
                AceId = employee.AceId,
                Password = randomPassword
            };

            await _context.Login.AddAsync(login);
            return employee;
        }

        // Retrieves employees based on optional filters (batchId, roleId)
        public async Task<IEnumerable<EmployeeDetails>> GetEmployees(int? batchId, int? roleId)
        {
            return await _context.EmployeeDetails
                .Where(e => (!batchId.HasValue || e.BatchId == batchId) &&
                            (!roleId.HasValue || e.RoleId == roleId))
                .ToListAsync();
        }

        // Fetches an employee by their unique AceId
        public async Task<EmployeeDetails> GetEmployeeByAceId(string aceId)
        {
            return await _context.EmployeeDetails.FirstOrDefaultAsync(e => e.AceId == aceId);
        }

         // Updates an existing employee's information
        public async Task<EmployeeDetails> UpdateEmployee(string aceId, EmployeeDetailsDto updateDto)
        {
            var employee = await _context.EmployeeDetails.FirstOrDefaultAsync(e => e.AceId == aceId);
            if (employee == null)
                return null;

            // Update employee properties
            employee.EmployeeName = updateDto.EmployeeName;
            employee.BatchId = updateDto.BatchId;
            employee.RoleId = updateDto.RoleId;

            await _context.SaveChangesAsync();
            return employee;
        }

        // Deletes an employee by AceId, returns true if successful
        public async Task<bool> DeleteEmployee(string aceId)
        {
            var employee = await _context.EmployeeDetails.FirstOrDefaultAsync(e => e.AceId == aceId);
            if (employee == null)
                return false;

            _context.EmployeeDetails.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
