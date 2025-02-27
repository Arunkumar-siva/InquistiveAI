using InquisitiveAiLibrary.Model;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquistiveAI_Library.Model
{
    public class Login
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AceId { get; set; }

        [Required]
        public string Password {  get; set; }

        [ForeignKey("AceId")]
        public virtual EmployeeDetails EmployeeDetails { get; set; }


    }
}
