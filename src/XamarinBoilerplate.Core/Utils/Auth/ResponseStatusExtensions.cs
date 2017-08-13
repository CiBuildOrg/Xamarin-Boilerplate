using System;
using System.Net;
using XamarinBoilerplate.Core.Exceptions;

namespace XamarinBoilerplate.Core.Utilities.Auth
{
    /// <summary>
    /// Extensions to the <see cref="ResponseStatus"/> class.
    /// </summary>
    public static class ResponseStatusExtensions
    {
        /// <summary>
        /// Convert the <see cref="ResponseStatus"/> to an <see cref="HttpException"/>.
        /// </summary>
        /// <param name="responseStatus">The response status.</param>
        /// <returns>The <see cref="HttpException"/> instance.</returns>
        /// <exception cref="System.ArgumentException">The Completed response status cannot be converted to an HTTP exception.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">responseStatus</exception>
        public static HttpException ToHttpException(this HttpStatusCode responseStatus)
        {
            switch (responseStatus)
            {
                case HttpStatusCode.InternalServerError:
                    return new HttpException((int)HttpStatusCode.InternalServerError, "The request could not be processed.");
                
                case HttpStatusCode.RequestTimeout:
                    return new HttpException((int)HttpStatusCode.RequestTimeout, "The request timed-out.");
                default:
                    throw new ArgumentOutOfRangeException(nameof(responseStatus));
            }
        }
    }
}