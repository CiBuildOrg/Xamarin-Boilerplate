using System.Collections.Generic;
using Validation;

namespace XamarinBoilerplate.Core.Utilities.Auth.Requests
{
    /// <summary>
    /// A request to refresh an issued access token. Implements: http://tools.ietf.org/html/rfc6749#section-6
    /// </summary>
    internal class RefreshAccessTokenRequest : TokenRequest
    {
        private const string RefreshTokenGrantType = "refresh_token";

        private readonly string _refreshToken;
        private readonly string _clientId;
        private readonly string _clientSecret;

        /// <summary>
        /// Initializes a new instance of the <see cref="RefreshAccessTokenRequest"/> class.
        /// </summary>
        /// <param name="refreshToken">The refresh token.</param>
        /// <param name="clientId">The client id.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <exception cref="System.ArgumentNullException">
        /// refreshToken
        /// or
        /// clientId
        /// or
        /// clientSecret
        /// </exception>
        public RefreshAccessTokenRequest(string refreshToken, string clientId, string clientSecret)
        {
            Requires.NotNullOrEmpty(refreshToken, "refreshToken");
            Requires.NotNullOrEmpty(clientId, "clientId");
            Requires.NotNullOrEmpty(clientSecret, "clientSecret");

            _refreshToken = refreshToken;
            _clientId = clientId;
            _clientSecret = clientSecret;
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
                           { "grant_type", RefreshTokenGrantType },
                           { "client_id", _clientId },
                           { "client_secret", _clientSecret },
                           { "refresh_token", _refreshToken }
                       };
        }
    }
}