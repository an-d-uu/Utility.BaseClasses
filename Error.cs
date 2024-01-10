using System.Net;

namespace Utility.BaseClasses
{
    /// <summary>
    /// A class that allows you to store and return an HttpStatusCode and a string message. This is very useful when returning responses from API requests where you need to return the status code and a message about why the status code was returned.
    /// </summary>
    public class Error
    {
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }

        public Error() : base()
        {
            Status = HttpStatusCode.NoContent;
            Message = string.Empty;

        }
        public Error(bool initializeMessage = false) : base()
        {
            Status = HttpStatusCode.NoContent;
            if (initializeMessage)
                Message = "Initialized: Must set HttpStatusCode.Ok when ready to return data!";
            else
                Message = string.Empty;

        }
    }
}
