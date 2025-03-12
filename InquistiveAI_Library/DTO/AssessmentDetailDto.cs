using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquistiveAI_Library.DTO
{
    public class AssessmentDetailDto
    {

        public string QuestionName { get; set; }

        public int BatchId {  get; set; }

        public DateTime AssessmentUploadedDate { get; set; }

        public IFormFile AssessmentFile { get; set; }

    }
}
