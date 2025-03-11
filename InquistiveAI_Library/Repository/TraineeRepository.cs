﻿using InquisitiveAiLibrary.Model;
using InquistiveAI_Library.Context;
using InquistiveAI_Library.Interface;
using InquistiveAI_Library.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InquistiveAI_Library.DTO;

namespace InquistiveAI_Library.Repository
{
    public class TraineeRepository : ITraineeRepository
    {
        private readonly ApplicationDbContext _context;
        public TraineeRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        
        public async Task<EmployeeDetailsDTO> GetEmployeeDetailById(string aceId)
        {
            var employeeData = await this._context.EmployeeDetails
                .Include(employee => employee.Roles)
                .Include(employee => employee.BatchDetails)
                .FirstOrDefaultAsync(employee => employee.AceId == aceId);

            var employeeAssessment = await this._context.EmployeeAssesmentDetails
                .Where(record => record.AceId == aceId)
                .ToListAsync();

            if (employeeData != null)
            {
                var employeeRecord = new EmployeeDetailsDTO
                {
                    AceId = employeeData.AceId,
                    EmployeeName = employeeData.EmployeeName,
                    RoleId = employeeData.RoleId,
                    BatchId = employeeData.BatchId,
                    EmployeeAssessment = employeeAssessment.Select(a => new EmployeeAssessmentDto
                    {
                        AssessmentId = a.AssessmentId,
                        Status = a.Status,
                        AssessmentSubmissionDate = a.AssessmentSubmissionDate,
                        Result = a.Result
                    }).ToList()
                };

                return employeeRecord;
            }
            return new EmployeeDetailsDTO();
        }

        public async Task<List<EmployeeAssessmentDto>> GetAssessmentDetailsById(string aceId){

             var employeeAssessment = await this._context.EmployeeAssesmentDetails
                .Where(record => record.AceId == aceId)
                .ToListAsync();

            if (employeeAssessment.Count() != 0)
            {
                
                  var EmployeeAssessment = employeeAssessment.Select(a => new EmployeeAssessmentDto
                    {
                        AssessmentId = a.AssessmentId,
                        Status = a.Status,
                        AssessmentSubmissionDate = a.AssessmentSubmissionDate,
                        Result = a.Result
                    }).ToList();

                    return EmployeeAssessment;
                    
            }
            return [];

    }

    }
}
