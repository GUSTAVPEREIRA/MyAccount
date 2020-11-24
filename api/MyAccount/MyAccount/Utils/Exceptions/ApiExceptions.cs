using System;
using System.Net;

namespace MyAccount.Utils.Exceptions
{
    public class ApiExceptions : Exception
    {
        private readonly HttpStatusCode statusCode;
        public object Value { get; set; }


        public ApiExceptions(HttpStatusCode statusCode, string message, Exception ex) : base(message, ex)
        {
            this.statusCode = statusCode;
        }

        public ApiExceptions(HttpStatusCode statusCode, string message) : base(message)
        {
            this.statusCode = statusCode;
        }

        public ApiExceptions(HttpStatusCode statusCode)
        {
            this.statusCode = statusCode;
        }

        public HttpStatusCode StatusCode
        {
            get
            {
                return this.statusCode;
            }
        }
    }
}