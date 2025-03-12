using InquisitiveAiLibrary.Model;
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
                
                  var employeeAssessmentData = employeeAssessment.Select(a => new EmployeeAssessmentDto
                    {
                        AssessmentId = a.AssessmentId,
                        Status = a.Status,
                        AssessmentSubmissionDate = a.AssessmentSubmissionDate,
                        Result = a.Result
                    }).ToList();

                    return employeeAssessmentData;
                    
            }
            return [];

    }
    public async Task<AssessmentDetailDto> GetAssessmentByAceId(string aceId){

        var employee = await this.GetEmployeeDetailById(aceId);
        if(employee!=null){
            var assessment = await this._context.AssesmentDetails.FirstOrDefaultAsync(assessment=> assessment.BatchId == employee.BatchId);
            if(assessment !=null){
                var assessmentData = new AssessmentDetailDto{
                    QuestionName = assessment.QuestionName,
                    BatchId = assessment.BatchId, 
                    AssessmentUploadedDate = assessment.AssessmentUploadedDate
                } ;
                return assessmentData;
            }
        }
            return new AssessmentDetailDto();
  }
public async Task<string> GetAssessmentFeedBack(string aceId){
     var employee = await this.GetAssessmentDetailsById(aceId);
        if(employee.Count()>0){
            var result = await this._context.EmployeeAssesmentDetails.FirstOrDefaultAsync(assessment=> assessment.AssessmentId == employee[0].AssessmentId);
            return result.Result;
            }
            else{
                return "No Assessment Taken";
            }
}
    }
}
