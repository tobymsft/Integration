using System;
using IntegrationTests.AuthenticationUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace IntegrationTests
{
    [TestClass]
    public class CreatePartyAddressAndUpdateValidFromDate
    {
        [TestMethod]
        public void ShouldUpdatePartyAddressValidFromDate()
        {

            var uriString = ClientConfiguration.Default.UriString;
            RestClient client =
                RestClientBuilder.Client($"{uriString}/data/PartyLocationPostalAddresses");

            var request = new RestRequest(Method.POST);

            var partyNumber = "000002257"; // enter a party number here

            request.AddJsonBody(new PartyAddress {PartyNumber = partyNumber, ValidFrom = "2018-07-02T18:38:16Z", IsPrimary = "No", IsRoleDelivery = "No", IsPrivate = "No", Street = "123 Test Street", Latitude = 0, Description = "Test Office", IsRoleInvoice = "No", Roles = "Invoice", IsRoleHome = "No", IsPrimaryTaxRegistration = "Yes", ValidTo = "2154-12-31T23:59:59Z", IsPrivatePostalAddress = "No", City = "Baldwin City", StreetNumber = "", IsRoleBusiness = "No", CountryRegionId = "USA", State = "KS", ZipCode = "66006", IsPostalAddress = "Yes", CountryRegionISOCode = "US", LocationId = ""});

            // insert
            var response = client.Execute<PartyAddress>(request);

            RestClient clientUpdate =
                RestClientBuilder.Client(
                    $"{uriString}/data/PartyLocationPostalAddresses(PartyNumber='{partyNumber}',LocationId='{response.Data.LocationId}', ValidFrom={response.Data.ValidFrom})");

            var requestUpdate = new RestRequest(Method.PATCH);

            requestUpdate.AddJsonBody(new
            {
                ValidFrom = DateTime.Parse(response.Data.ValidFrom).AddDays(-1) // this doesn't update
                //IsPrivatePostalAddress="Yes" // this works
            });

            var responseUpdate = clientUpdate.Execute<PartyAddress>(requestUpdate);

        }



        
    }

    
}



