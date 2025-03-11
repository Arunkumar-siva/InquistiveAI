using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquistiveAI_Library.DTO
{
    public class BatchDetailsDto
    {
        [Required]
        public string BatchName {  get; set; }

        [Required]

        public DateTime BatchMonth { get; set; }
    }
}
