using System;
using System.Collections.Generic;
using RestSharp.Portable;
using Validation;

namespace XamarinBoilerplate.Core.Utilities.Auth.Requests
{
    /// <summary>
    /// This class represents a OAuth 2.0 token request.
    /// </summary>
    internal abstract class TokenRequest
    {
        /// <summary>
        /// Convert this instance to a <see cref="RestRequest" /> so that we can execute the grant token request
        /// using the RestSharp library.
        /// </summary>
        /// <param name="tokensUri">The URI to which the token request will be sent.</param>
        /// <returns>
        /// The <see cref="RestRequest" /> representation of this instance.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">tokensUri</exception>
        /// <exception cref="System.InvalidOperationException">The GetParameters method must not return a null instance.</exception>
        public RestRequest ToRestRequest(Uri tokensUri)
        {
            Requires.NotNull(tokensUri, "tokensUri");
      
            var parameters = GetParameters();

            Verify.Operation(parameters != null, "The GetParameters method must not return a null instance.");
            
            var restRequest = new RestRequest(tokensUri, Method.POST);

            foreach (var key in parameters.Keys)
            {
                restRequest.AddParameter(key.ToString(), parameters[key.ToString()]);
            }

            return restRequest;
        }

        /// <summary>
        /// Gets the parameters representing the request.
        /// </summary>
        /// <returns>The parameters.</returns>
        protected abstract IDictionary<string, string> GetParameters();
    }
}