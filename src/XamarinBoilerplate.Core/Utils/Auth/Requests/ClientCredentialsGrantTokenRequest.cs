using System.Collections.Generic;
using Validation;

namespace XamarinBoilerplate.Core.Utilities.Auth.Requests
{
    /// <summary>
    /// A request for a token based on a client credentials grant. Implements: http://tools.ietf.org/html/rfc6749#section-4.4
    /// </summary>
    internal class ClientCredentialsGrantTokenRequest : TokenRequest
    {
        private const string ClientCredentialsGrantType = "client_credentials";

        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _scope;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientCredentialsGrantTokenRequest"/> class.
        /// </summary>
        /// <param name="clientId">The client id.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <param name="scope">The scope.</param>
        /// <exception cref="System.ArgumentNullException">
        /// clientId
        /// or
        /// clientSecret
        /// </exception>
        public ClientCredentialsGrantTokenRequest(string clientId, string clientSecret, string scope)
        {
            Requires.NotNullOrEmpty(clientId, "clientId");
            Requires.NotNullOrEmpty(clientSecret, "clientSecret");
            
            _clientId = clientId;
            _clientSecret = clientSecret;
            _scope = scope;
        }

        /// <summary>
        /// Gets the parameters representing the request.
        /// </summary>
        /// <returns>
        /// The parameters.
        /// </returns>
        protected override IDictionary<string,string> GetParameters()
        {
            return new Dictionary<string, string>
                       {
                           { "grant_type", ClientCredentialsGrantType },
                           { "client_id", _clientId },
                           { "client_secret", _clientSecret },
                           { "scope", _scope }
                       };
        }
    }
}