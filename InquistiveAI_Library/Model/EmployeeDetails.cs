using InquistiveAI_Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InquisitiveAiLibrary.Model
{
    public class EmployeeDetails
    {

        [Key]
        public string AceId { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        [Required]
        public int BatchId { get; set; }

        [Required]
        public int RoleId { get; set; }


        [ForeignKey("BatchId")]
        [JsonIgnore]

        public virtual BatchDetails BatchDetails { get; set; }

        [ForeignKey("RoleId")]
        [JsonIgnore]

        public virtual Roles Roles { get; set; }

        [JsonIgnore]
        public virtual Login Login { get; set; }

        [JsonIgnore]
        public virtual EmployeeAssesmentDetails EmployeeAssessmentDetails{ get; set; } 

    }
}
    