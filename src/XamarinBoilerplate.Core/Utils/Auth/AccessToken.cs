using System;
using System.Collections.Generic;
using System.Linq;
using Validation;

namespace XamarinBoilerplate.Core.Utilities.Auth
{
    /// <summary>
    /// An OAuth access token.
    /// </summary>
    public class AccessToken
    {
        private const string TokenKey = "Token";
        private const string RefreshTokenKey = "RefreshToken";
        private const string ScopeKey = "Scope";
        private const string TokenTypeKey = "TokenType";
        private const string ExpirationDateKey = "ExpirationDate";

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessToken"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="tokenType">Type of the token.</param>
        /// <param name="scope">The scope.</param>
        /// <param name="expirationDate">The expiration date.</param>
        public AccessToken(string token, string tokenType, string scope, DateTime? expirationDate)
            : this(token, tokenType, scope, expirationDate, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessToken" /> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="tokenType">Type of the token.</param>
        /// <param name="scope">The scope.</param>
        /// <param name="expirationDate">The expiration date.</param>
        /// <param name="refreshToken">The refresh token.</param>
        /// <exception cref="System.ArgumentNullException">
        /// token
        /// or
        /// scope
        /// or
        /// tokenType
        /// </exception>
        public AccessToken(string token, string tokenType, string scope, DateTime? expirationDate, string refreshToken)
        {
            Requires.NotNullOrEmpty(token, "token");
            Requires.NotNullOrEmpty(tokenType, "tokenType");

            Token = token;
            Scope = scope;
            TokenType = tokenType;
            ExpirationDate = expirationDate;
            RefreshToken = refreshToken;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessToken" /> class.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <exception cref="System.ArgumentNullException">dictionary</exception>
        public AccessToken(IDictionary<string, string> dictionary)
        {
            Requires.NotNull(dictionary, "dictionary");
            Requires.That(dictionary.ContainsKey(TokenKey), "dictionary", string.Format("The dictionary does not contain a value for the \"{0}\" key.", TokenKey));
            Requires.That(dictionary.ContainsKey(TokenTypeKey), "dictionary", string.Format("The dictionary does not contain a value for the \"{0}\" key.", TokenTypeKey));
            Requires.That(!string.IsNullOrEmpty(dictionary[TokenKey]), "dictionary", string.Format("The value for the \"{0}\" key must not be empty.", TokenKey));
            Requires.That(!string.IsNullOrEmpty(dictionary[TokenTypeKey]), "dictionary", string.Format("The value for the \"{0}\" key must not be empty.", TokenTypeKey));

            Token = dictionary[TokenKey];
            TokenType = dictionary[TokenTypeKey];
            Scope = dictionary.ContainsKey(ScopeKey) ? dictionary[ScopeKey] : null;
            RefreshToken = dictionary.ContainsKey(RefreshTokenKey) ? dictionary[RefreshTokenKey] : null;
            ExpirationDate = dictionary.ContainsKey(ExpirationDateKey) ? DateTime.Parse(dictionary[ExpirationDateKey]) : (DateTime?)null;
        }

        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public string Token { get; private set; }

        /// <summary>
        /// Gets the scope.
        /// </summary>
        /// <value>
        /// The scope.
        /// </value>
        public string Scope { get; private set; }

        /// <summary>
        /// Gets the type of the token.
        /// </summary>
        /// <value>
        /// The type of the token.
        /// </value>
        public string TokenType { get; private set; }

        /// <summary>
        /// Gets the expiration date.
        /// </summary>
        /// <value>
        /// The expiration date.
        /// </value>
        public DateTime? ExpirationDate { get; private set; }

        /// <summary>
        /// Gets the refresh token.
        /// </summary>
        /// <value>
        /// The refresh token.
        /// </value>
        public string RefreshToken { get; private set; }

        /// <summary>
        /// Check if the access token should be refreshed when taking into account the specified refresh token expiration window.
        /// </summary>
        /// <param name="refreshTokenExpirationWindow">The refresh token expiration window.</param>
        /// <returns><c>true</c>, if the access token should be refreshed; otherwise, <c>false</c>.</returns>
        public bool ShouldBeRefreshed(TimeSpan refreshTokenExpirationWindow)
        {
            if (ExpirationDate == null)
            {
                return false;
            }

            return ExpirationDate <= DateTime.Now || ExpirationDate - DateTime.Now <= refreshTokenExpirationWindow;
        }

        /// <summary>
        /// Convert this instance to a dictionary.
        /// </summary>
        /// <returns>The dictionary representation of this instance.</returns>
        public IDictionary<string, string> ToDictionary()
        {
            var dictionary = new Dictionary<string, string>
                                 {
                                     { TokenKey, Token },
                                     { TokenTypeKey, TokenType },
                                     { ScopeKey, Scope },
                                     { ExpirationDateKey, ExpirationDate.HasValue ? ExpirationDate.Value.ToString("s") : null },
                                     { RefreshTokenKey, RefreshToken }
                                 };

            return dictionary.Where(kv => kv.Value != null).ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
}