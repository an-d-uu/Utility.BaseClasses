using System;
using System.Net;

namespace Utility.BaseClasses
{
    /// <summary>
    /// Extends the Exception class to give you a HttpStatusCode and Message as well as the base Exception information.
    /// </summary>
    public class CustomException : Exception
    {
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
        public CustomException() : base()
        {
            Status = HttpStatusCode.NoContent;
            Message = "";
        }
        public CustomException(HttpStatusCode statusCode, string errorMsg) : base(errorMsg)
        {
            Status = statusCode;
            Message = errorMsg;
        }
    }
}
