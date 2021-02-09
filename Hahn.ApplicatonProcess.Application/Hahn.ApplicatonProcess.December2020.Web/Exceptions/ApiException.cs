using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web.Exceptions
{
    public class ApiException: Exception
    {
        public int StatusCode { get; set; }
        public HttpStatusCode Status { get; set; }

        public ApiException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : base(message)
        {
            StatusCode = (int)statusCode;
            Status = statusCode;
        }
        
        public ApiException(Exception ex, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : base(ex.Message)
        {
            StatusCode = (int)statusCode;
        }
    }
}
