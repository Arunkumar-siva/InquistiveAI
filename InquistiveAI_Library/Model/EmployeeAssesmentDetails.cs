using InquisitiveAiLibrary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquistiveAI_Library.Model
{
    public class EmployeeAssesmentDetails
    {

        [Key]
        public int Id { get; set; }

        
        public string AceId { get; set; }

        
        public int BatchId { get; set; }

        public int AssessmentId { get; set; }
    
        public bool Status { get; set; }

        public DateTime AssessmentSubmissionDate { get; set; }

        public string Result { get; set; }


        [ForeignKey("BatchId")]
        public  virtual BatchDetails BatchDetails { get; set; }

        [ForeignKey("AceId")]
        public virtual EmployeeDetails EmployeeDetails { get; set; }

        [ForeignKey("AssessmentId")]
        public virtual AssesmentDetails AssesmentDetails { get; set; }

    }
}
