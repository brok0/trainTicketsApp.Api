using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TrainTickets.Domain.Exceptions
{
    public class HttpException : Exception
    {
        public  HttpStatusCode StatusCode { get;  }
        public string Message { get;  }
        public HttpException( HttpStatusCode statusCode,string message)

        {

            StatusCode = statusCode;
            Message = message;
        }
        public string JsonToString()
        {
            return string.Concat( " {\"statusCode\" : + ", StatusCode.ToString(),",\"message:",Message,"\"}");
        }
    }
}
