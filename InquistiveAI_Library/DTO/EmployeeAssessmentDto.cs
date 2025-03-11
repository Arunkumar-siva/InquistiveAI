using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquistiveAI_Library.DTO
{
    public class EmployeeAssessmentDto
    {
         public int AssessmentId { get; set; }
    
        public bool Status { get; set; }

        public DateTime AssessmentSubmissionDate { get; set; }

        public string Result { get; set; }


    }
}