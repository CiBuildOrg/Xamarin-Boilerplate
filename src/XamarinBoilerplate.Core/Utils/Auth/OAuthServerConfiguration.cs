using System;
using Validation;

namespace XamarinBoilerplate.Core.Utilities.Auth
{
    /// <summary>
    /// The configuration that describes the OAuth server configuration.
    /// </summary>
    public class OAuthServerConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthServerConfiguration" /> class.
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="tokensUrl">The URL to which token requests will be made.</param>
        /// <param name="clientId">The client id.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <exception cref="System.ArgumentNullException">clientId
        /// or
        /// clientSecret</exception>
        public OAuthServerConfiguration(Uri baseUrl, Uri tokensUrl, string clientId, string clientSecret)
        {
            Requires.NotNull(baseUrl, "baseUrl");
            Requires.NotNull(tokensUrl, "tokensUrl");
            Requires.NotNullOrEmpty(clientId, "clientId");
            Requires.NotNullOrEmpty(clientSecret, "clientSecret");

            BaseUrl = baseUrl;
            TokensUrl = tokensUrl;
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Gets the base URL of the OAuth server.
        /// </summary>
        /// <value>
        /// The base URL.
        /// </value>
        public Uri BaseUrl { get; private set; }

        /// <summary>
        /// Gets the URL to which token requests will be made.
        /// </summary>
        /// <value>
        /// The tokens URL.
        /// </value>
        public Uri TokensUrl { get; private set; }

        /// <summary>
        /// Gets the client id.
        /// </summary>
        /// <value>
        /// The client id.
        /// </value>
        public string ClientId { get; private set; }

        /// <summary>
        /// Gets the client secret.
        /// </summary>
        /// <value>
        /// The client secret.
        /// </value>
        public string ClientSecret { get; private set; }
    }
}