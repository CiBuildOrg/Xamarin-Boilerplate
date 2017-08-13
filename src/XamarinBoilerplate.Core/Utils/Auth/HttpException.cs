using System;

namespace XamarinBoilerplate.Core.Exceptions
{
    public class HttpException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public HttpException()
        {
        }

        public HttpException(string message) : base(message)
        {
        }

        public HttpException(string message, Exception inner) : base(message, inner)
        {
        }

        public HttpException(int statusCode, string message)

            : base($"Exception: {message}. HTTP status code: {statusCode}")
        {
        }

    }
}
