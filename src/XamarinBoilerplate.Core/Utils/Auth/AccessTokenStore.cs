using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Validation;
using Xamarin.Auth;

namespace XamarinBoilerplate.Core.Utilities.Auth
{
    /// <summary>
    /// A store to securely store <see cref="AccessToken"/> instances in. This class acts as a wrapper around
    /// the <see cref="AccountStore"/> class, which is where the actual storage takes place.
    /// </summary>
    public class AccessTokenStore
    {
        private const string NormalizedUsernamePrefix = "user:";
        private const string NormalizedClientIdPrefix = "client:";

        private readonly AccountStore _accountStore;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessTokenStore"/> class.
        /// </summary>
        /// <param name="accountStore">The account store.</param>
        /// <exception cref="System.ArgumentNullException">accountStore</exception>
        public AccessTokenStore(AccountStore accountStore)
        {
            Requires.NotNull(accountStore, "accountStore");

            _accountStore = accountStore;
        }

        /// <summary>
        /// Gets the user access token.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="serviceId">The service id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The task that represents the token retrieval action.</returns>
        /// <exception cref="System.ArgumentNullException">username
        /// or
        /// serviceId</exception>
        public Task<AccessToken> GetUserAccessToken(string username, string serviceId, CancellationToken cancellationToken)
        {
            Requires.NotNullOrEmpty(username, "username");
            Requires.NotNullOrEmpty(serviceId, "serviceId");

            return GetAccessToken(NormalizeUsername(username), serviceId, cancellationToken);
        }

        /// <summary>
        /// Gets the client access token.
        /// </summary>
        /// <param name="clientId">The client id.</param>
        /// <param name="serviceId">The service id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// The task that represents the token retrieval action.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">clientId
        /// or
        /// serviceId</exception>
        public Task<AccessToken> GetClientAccessToken(string clientId, string serviceId, CancellationToken cancellationToken)
        {
            Requires.NotNullOrEmpty(clientId, "clientId");
            Requires.NotNullOrEmpty(serviceId, "serviceId");

            return GetAccessToken(NormalizeClientId(clientId), serviceId, cancellationToken);
        }

        /// <summary>
        /// Saves the user access token.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="serviceId">The service id.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The task that represents the save action.</returns>
        public Task SaveUserAccessToken(string username, string serviceId, AccessToken accessToken, CancellationToken cancellationToken)
        {
            Requires.NotNullOrEmpty(username, "username");
            Requires.NotNullOrEmpty(serviceId, "serviceId");
            Requires.NotNull(accessToken, "accessToken");

            return SaveAccessToken(NormalizeUsername(username), serviceId, accessToken, cancellationToken);
        }

        /// <summary>
        /// Saves the client access token.
        /// </summary>
        /// <param name="clientId">The client id.</param>
        /// <param name="serviceId">The service id.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The task that represents the save action.</returns>
        public Task SaveClientAccessToken(string clientId, string serviceId, AccessToken accessToken, CancellationToken cancellationToken)
        {
            Requires.NotNullOrEmpty(clientId, "clientId");
            Requires.NotNullOrEmpty(serviceId, "serviceId");
            Requires.NotNull(accessToken, "accessToken");

            return SaveAccessToken(NormalizeClientId(clientId), serviceId, accessToken, cancellationToken);
        }

        private Task<AccessToken> GetAccessToken(string normalizedUsername, string serviceId, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() =>
                {
                    var account = _accountStore.FindAccountsForService(serviceId)
                                      .First(a => string.Equals(a.Username, normalizedUsername, StringComparison.CurrentCultureIgnoreCase));

                    return new AccessToken(account.Properties);
                }, cancellationToken);
        }

        private Task SaveAccessToken(string normalizedUsername, string serviceId, AccessToken accessToken, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() => _accountStore.Save(new Account(normalizedUsername, accessToken.ToDictionary()), serviceId), cancellationToken);
        }

        private static string NormalizeUsername(string username)
        {
            return NormalizedUsernamePrefix + username;
        }

        private static string NormalizeClientId(string clientId)
        {
            return NormalizedClientIdPrefix + clientId;
        }
    }
}