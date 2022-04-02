
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xulqna.Domain.Commons
{
    public class ErrorResponse
    {
        public ErrorResponse(int? code = null, string message = null)
        {
            Code = code;
            Message = message;
        }
        int? Code;

        string Message;
    }
}
