using InquisitiveAiLibrary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquistiveAI_Library.Model
{
    public class Roles
    {

        [Key]

        public int RoleId { get; set; }

        [Required]
        public string Role { get; set; }

        public virtual ICollection<EmployeeDetails> EmployeeDetails { get; set; }

       
    }
}
