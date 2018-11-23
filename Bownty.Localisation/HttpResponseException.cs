using System;

namespace Bownty.Localisation
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException(int statusCode, string message) : base(message)
        {
            HttpStatusCode = statusCode;
        }

        public int HttpStatusCode;
    }
}
