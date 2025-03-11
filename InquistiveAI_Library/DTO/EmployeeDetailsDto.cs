using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InquisitiveAiLibrary.Model;

namespace InquistiveAI_Library.DTO
{
    public class EmployeeDetailsDTO
    {
        public string AceId { get; set; }

        public string EmployeeName { get; set; }

        public int BatchId { get; set; }

        public int RoleId { get; set; }

        public List<EmployeeAssessmentDto> EmployeeAssessment {get;set;}

    }
}