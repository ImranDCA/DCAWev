using bXrmAPIProvider;
using bXrmAPIProvider.DCEntity;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.OData.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebApiConnectivity.Microsoft.Dynamics.CRM;

namespace WebApiConnectivity
{
    class ApiProvoderTest
    {
        static void Main(string[] args)
        {
            DataServiceContext cont = new Microsoft.Dynamics.CRM.System(new Uri(ClientConfig.resource + "api/data/v8.2/"));
            


            cont.SendingRequest2 += (sender, e) =>
            {
                AuthenticationContext authContext = new AuthenticationContext(ClientConfig.authorityProvider, false);
                
                
                AuthenticationResult result = authContext.AcquireTokenAsync(ClientConfig.resource, ClientConfig.clientId, new Uri(ClientConfig.redirectUrl), new PlatformParameters(PromptBehavior.Auto)).Result;
                e.RequestMessage.SetHeader("Authorization", $"Bearer {result.AccessToken}");
                
            };

            try
            {                
                var query = cont.CreateQuery<Account>("accounts").AddQueryOption("$filter", 
                    "accountid eq 28AB50DC-2274-E611-80E0-C4346BAC6E60").AddQueryOption("$select", "name");              

                query.Execute().SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }

            
        }

        
    }


    public class modelGenerator
    {
        public static DCContact getContact()
        {
            return new DCContact() { EntityLogicalName = "contact", EntityPluralName = "contacts", FirstName = "steve", LastName = "smith" };
        }
    }
}
