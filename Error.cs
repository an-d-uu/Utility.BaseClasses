using System.Net;

namespace Utility.BaseClasses
{
    class Error
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
