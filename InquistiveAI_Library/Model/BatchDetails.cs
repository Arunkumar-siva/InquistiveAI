using InquisitiveAiLibrary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquistiveAI_Library.Model
{
    public class BatchDetails
    {
        [Key]
        public int BatchId { get; set; }
        [Required]
        public string BatchName { get; set; }

        public DateTime BatchMonth { get; set; }

        public virtual AssesmentDetails AssesmentDetails { get; set; } 

        public virtual ICollection<EmployeeAssesmentDetails> EmployeeAssesmentDetails { get; set;} 

        public virtual ICollection<EmployeeDetails> EmployeeDetails { get; set; }

    }
}
