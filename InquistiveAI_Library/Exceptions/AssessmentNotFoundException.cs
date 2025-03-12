using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquistiveAI_Library.Exceptions
{
    public class AssessmentNotFoundException : Exception
    {
        public AssessmentNotFoundException(string message) : base(message)
        {

        }
    }
}
