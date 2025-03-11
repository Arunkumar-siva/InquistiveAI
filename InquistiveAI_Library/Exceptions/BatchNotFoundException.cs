using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquistiveAI_Library.Exceptions
{
    public class BatchNotFoundException : Exception
    {
        public BatchNotFoundException(string message) : base(message)
        {

        }
    }
}
