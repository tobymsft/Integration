using System;

namespace IntegrationTests.AuthenticationUtility
{
    public class ClientConfiguration
    {
        public static ClientConfiguration Default => ClientConfiguration.Dev;

        public static ClientConfiguration Dev = new ClientConfiguration()
        {
            UriString = "<FinOpsURL>",
            ActiveDirectoryResource = "<FinOpsURL>",
            ActiveDirectoryTenant = "https://login.microsoftonline.com/<tenant>",
            ActiveDirectoryClientAppId = "<AppId>",
            ActiveDirectoryClientAppSecret = "<Secret>",
        };


        public string UriString { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ActiveDirectoryResource { get; set; }
        public string ActiveDirectoryTenant { get; set; }
        public string ActiveDirectoryClientAppId { get; set; }
        public string ActiveDirectoryClientAppSecret { get; set; }
    }
}
