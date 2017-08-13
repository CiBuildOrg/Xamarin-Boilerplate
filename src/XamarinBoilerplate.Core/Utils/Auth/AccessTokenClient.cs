using System.Net;
using System.Threading;
using System.Threading.Tasks;
using RestSharp.Portable.Deserializers;
using RestSharp.Portable.HttpClient;
using Validation;
using XamarinBoilerplate.Core.Exceptions;
using XamarinBoilerplate.Core.Utilities.Auth.Requests;

namespace XamarinBoilerplate.Core.Utilities.Auth
{
    /// <summary>
    /// This client allows retrieval of access tokens through the OAuth 2 protocol (http://tools.ietf.org/html/rfc6749).
    /// </summary>
    public class AccessTokenClient
    {
        private readonly OAuthServerConfiguration _serverConfiguration;
        private readonly JsonDeserializer _jsonDeserializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessTokenClient"/> class.
        /// </summary>
        /// <param name="serverConfiguration">The client configuration.</param>
        /// <exception cref="System.ArgumentNullException">clientConfiguration</exception>
        public AccessTokenClient(OAuthServerConfiguration serverConfiguration)
        {
            Requires.NotNull(serverConfiguration, "clientConfiguration");

            _jsonDeserializer = new JsonDeserializer();
            _serverConfiguration = serverConfiguration;
            RestClient = new RestClient(serverConfiguration.BaseUrl.ToString());
        }

        /// <summary>
        /// Gets the rest client used to make the requests.
        /// </summary>
        /// <value>
        /// The rest client.
        /// </value>
        public RestClient RestClient { get; private set; }

        /// <summary>
        /// Gets an access token for a client.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <returns>The access token retrieval task.</returns>
        /// <remarks>
        /// This method implements the client credentials grant workflow (http://tools.ietf.org/html/rfc6749#section-4.4)
        /// </remarks>
        public Task<AccessToken> GetClientAccessToken(string scope)
        {
            return GetClientAccessToken(scope, CancellationToken.None);
        }

        /// <summary>
        /// Gets an access token for a client.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The access token retrieval task.</returns>
        /// <remarks>
        /// This method implements the client credentials grant workflow (http://tools.ietf.org/html/rfc6749#section-4.4)
        /// </remarks>
        public Task<AccessToken> GetClientAccessToken(string scope, CancellationToken cancellationToken)
        {
            return ExecuteAccessTokenRequest(new ClientCredentialsGrantTokenRequest(_serverConfiguration.ClientId, _serverConfiguration.ClientSecret, scope), cancellationToken);
        }

        /// <summary>
        /// Gets an access token for a user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="scope">The scope.</param>
        /// <returns>The access token retrieval task.</returns>
        /// <remarks>
        /// This method implements the resource owner password credentials grant workflow (http://tools.ietf.org/html/rfc6749#section-4.3)
        /// </remarks>
        public Task<AccessToken> GetUserAccessToken(string username, string password, string scope)
        {
            return GetUserAccessToken(username, password, scope, CancellationToken.None);
        }

        /// <summary>
        /// Gets an access token for a user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="scope">The scope.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The access token retrieval task.</returns>
        /// <remarks>
        /// This method implements the resource owner password credentials grant workflow (http://tools.ietf.org/html/rfc6749#section-4.3)
        /// </remarks>
        public Task<AccessToken> GetUserAccessToken(string username, string password, string scope, CancellationToken cancellationToken)
        {
            Requires.NotNullOrEmpty(username, "username");
            Requires.NotNullOrEmpty(password, "password");
            
            return ExecuteAccessTokenRequest(new ResourceOwnerPasswordCredentialsGrantTokenRequest(username, password, _serverConfiguration.ClientId, scope), cancellationToken);
        }

        /// <summary>
        /// Exchanged a refresh token for a new access token.
        /// </summary>
        /// <param name="refreshToken">The refresh token.</param>
        /// <returns></returns>
        /// <remarks>
        /// This method implements the refresh access token workflow (http://tools.ietf.org/html/rfc6749#section-6)
        /// </remarks>
        public Task<AccessToken> RefreshToken(string refreshToken)
        {
            return RefreshToken(refreshToken, CancellationToken.None);
        }

        /// <summary>
        /// Exchanged a refresh token for a new access token.
        /// </summary>
        /// <param name="refreshToken">The refresh token.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <remarks>
        /// This method implements the refresh access token workflow (http://tools.ietf.org/html/rfc6749#section-6)
        /// </remarks>
        public Task<AccessToken> RefreshToken(string refreshToken, CancellationToken cancellationToken)
        {
            Requires.NotNullOrEmpty(refreshToken, "refreshToken");
            
            return ExecuteAccessTokenRequest(new RefreshAccessTokenRequest(refreshToken, _serverConfiguration.ClientId, _serverConfiguration.ClientSecret), cancellationToken);
        }

        private Task<AccessToken> ExecuteAccessTokenRequest(TokenRequest tokenRequest, CancellationToken cancellationToken)
        {
            var restRequest = tokenRequest.ToRestRequest(_serverConfiguration.TokensUrl);

            return RestClient.Execute(restRequest, cancellationToken)
                .ContinueWith(t =>
                    {
                        // We will only process HTTP 200 status codes, as only then we can be sure 
                        // that we have received a correct response and can be try to deserialize
                        // the access token response
                        if (t.Result.StatusCode == HttpStatusCode.OK)
                        {
                            return _jsonDeserializer.Deserialize<AccessTokenResponse>(t.Result).ToAccessToken();
                        }

                        throw new HttpException((int)t.Result.StatusCode, t.Result.StatusDescription);
                    }, cancellationToken);
        }
    }
}