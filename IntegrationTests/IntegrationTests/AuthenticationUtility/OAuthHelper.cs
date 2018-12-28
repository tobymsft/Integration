﻿using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace IntegrationTests.AuthenticationUtility
{
    public class OAuthHelper
    {
        /// <summary>
        /// The header to use for OAuth.
        /// </summary>
        public const string OAuthHeader = "Authorization";

        /// <summary>
        /// Retrieves an authentication header from the service.
        /// </summary>
        /// <returns>The authentication header for the Web API call.</returns>
        public static string GetAuthenticationHeader(bool useWebAppAuthentication = false)
        {
            // Create and get JWT token
            return GetAuthenticationResult(useWebAppAuthentication).CreateAuthorizationHeader();
        }

        

        public static AuthenticationResult GetAuthenticationResult(bool useWebAppAuthentication = false)
        {
            string aadTenant = ClientConfiguration.Default.ActiveDirectoryTenant;
            string aadClientAppId = ClientConfiguration.Default.ActiveDirectoryClientAppId;
            string aadResource = ClientConfiguration.Default.ActiveDirectoryResource;

            AuthenticationContext authenticationContext = new AuthenticationContext(aadTenant);
            AuthenticationResult authenticationResult;

            if (useWebAppAuthentication)
            {
                string aadClientAppSecret = ClientConfiguration.Default.ActiveDirectoryClientAppSecret;
                var creadential = new ClientCredential(aadClientAppId, aadClientAppSecret);
                authenticationResult = authenticationContext.AcquireTokenAsync(aadResource, creadential).Result;
            }
            else
            {
                // OAuth through username and password.
                string username = ClientConfiguration.Default.UserName;
                string password = ClientConfiguration.Default.Password;

                // Get token object
                var userCredential = new UserPasswordCredential(username, password);
                authenticationResult = authenticationContext.AcquireTokenAsync(aadResource, aadClientAppId, userCredential).Result;
            }
            
            return authenticationResult;
        }
    }
}