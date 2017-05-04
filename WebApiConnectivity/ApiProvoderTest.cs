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
            DataServiceContext cont = new DataServiceContext(new Uri(ClientConfig.resource + "api/data/v8.2/"));
            


            cont.SendingRequest2 += (sender, e) =>
            {
                AuthenticationContext authContext = new AuthenticationContext(ClientConfig.authorityProvider, false);
                AuthenticationResult result = authContext.AcquireTokenAsync(ClientConfig.resource, ClientConfig.clientId, new Uri(ClientConfig.redirectUrl), new PlatformParameters(PromptBehavior.Auto)).Result;

                var httpWebRequest = ((HttpWebRequestMessage)e.RequestMessage).HttpWebRequest;

                httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {result.AccessToken}");

                //e.RequestMessage.SetHeader("Authorization", $"Bearer {result.AccessToken}");
                //e.RequestMessage.SetHeader("OData-MaxVersion", "4.0");
                //e.RequestMessage.SetHeader("OData-Version", "4.0"); 

                //var httpWebRequest = ((HttpWebRequestMessage)e.RequestMessage).HttpWebRequest;
                //httpWebRequest.Headers.Add(System.Net.HttpRequestHeader.Authorization, "Bearer" + " " + result.AccessToken);
                //httpWebRequest.Headers.Add("OData-MaxVersion", "4.0");
                //httpWebRequest.Headers.Add("OData-Version", "4.0");
            };

            try
            {
                //var acc = new WebApiConnectivity.Microsoft.Dynamics.CRM.System(new Uri(ClientConfig.resource + "api/data/v8.1/"));
                //Guid id = Guid.Parse("28ab50dc-2274-e611-80e0-c4346bac6e60");
                //var contt = acc.Accounts.Where(t => t.Accountid == id).SingleOrDefault();
                var query = cont.CreateQuery<Account>("accounts").AddQueryOption("$select", "name").AddQueryOption("$filter", 
                    "accountid eq 28AB50DC-2274-E611-80E0-C4346BAC6E60");              

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
