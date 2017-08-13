using System.Collections.Generic;
using Validation;

namespace XamarinBoilerplate.Core.Utilities.Auth.Requests
{
    /// <summary>
    /// A request for a token based on a resource owner's password credentials. Implements: http://tools.ietf.org/html/rfc6749#section-4.3
    /// </summary>
    internal class ResourceOwnerPasswordCredentialsGrantTokenRequest : TokenRequest
    {
        private const string PasswordGrantType = "password";

        private readonly string _username;
        private readonly string _password;
        private readonly string _clientId;
        private readonly string _scope;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceOwnerPasswordCredentialsGrantTokenRequest"/> class.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="clientId">The client id.</param>
        /// <param name="scope">The scope.</param>
        /// <exception cref="System.ArgumentNullException">
        /// username
        /// or
        /// password
        /// or
        /// clientId
        /// </exception>
        public ResourceOwnerPasswordCredentialsGrantTokenRequest(string username, string password, string clientId, string scope)
        {
            Requires.NotNullOrEmpty(username, "username");
            Requires.NotNullOrEmpty(password, "password");
            Requires.NotNullOrEmpty(clientId, "clientId");

            _username = username;
            _password = password;
            _clientId = clientId;
            _scope = scope;
        }

        /// <summary>
        /// Gets the parameters representing the request.
        /// </summary>
        /// <returns>
        /// The parameters.
        /// </returns>
        protected override IDictionary<string, string> GetParameters()
        {
            return new Dictionary<string, string>
                       {
                           { "grant_type", PasswordGrantType },
                           { "client_id", _clientId },
                           { "username", _username },
                           { "password", _password },
                           { "scope", _scope }
                       };
        }
    }
}