﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InquistiveAI_Library.Model
{
    public class AssesmentDetails
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string QuestionName { get; set; }

        [Required]
        public byte[] Content { get; set; }

        [Required]
        public string ContentType { get; set; }

        [Required]
        public int BatchId { get; set; }

        [Required]
        public DateTime AssessmentUploadedDate { get; set; }

        [ForeignKey("BatchId")]
        [JsonIgnore]
        public virtual BatchDetails BatchDetails { get; set; }

        [JsonIgnore]
        public virtual ICollection<EmployeeAssesmentDetails> EmployeeAssesments { get; set; }
    
    }
}
