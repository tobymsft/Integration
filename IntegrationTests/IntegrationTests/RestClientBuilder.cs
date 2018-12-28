using System;
using IntegrationTests.AuthenticationUtility;
using RestSharp;
using RestSharp.Authenticators;

namespace IntegrationTests
{
    public static class RestClientBuilder
    {
        public static RestClient Client(string servicePath)
        {
            return new RestClient
            {
                BaseUrl = new Uri(servicePath),
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(OAuthHelper.GetAuthenticationResult(true).AccessToken, "Bearer")
            };
        }
    }
}
