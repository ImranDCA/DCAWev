using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebApiConnectivity
{
    class Program
    {
        static void Main(string[] args)
        {


            // TODO Substitute your correct CRM root service address, 
            string resource = "https://dca-solution.crm4.dynamics.com/";

            // TODO Substitute your app registration values that can be obtained after you
            // register the app in Active Directory on the Microsoft Azure portal.
            string clientId = "e5f9ee14-b122-47ba-ae6d-079f2e9a5ed6";
            string redirectUrl = "https://web-api-poc.doctorcareanywhere.com/";


            new Program().adalCallAsync(resource, clientId, redirectUrl);


            Console.Read();






        }

        private async void adalCallAsync(string resource, string clientId, string redirectUrl)
        {
            try
            {
                AuthenticationContext authContext = new AuthenticationContext("https://login.windows.net/common", false);
                AuthenticationResult result = await authContext.AcquireTokenAsync(resource, clientId, new Uri(redirectUrl), new PlatformParameters(PromptBehavior.Auto));

                //Console.WriteLine(result.AccessToken);


                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(resource + "api/data/v8.1/");
                    httpClient.Timeout = new TimeSpan(0, 2, 0);  // 2 minutes
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", result.AccessToken);
                    httpClient.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
                    httpClient.DefaultRequestHeaders.Add("OData-Version", "4.0");
                    httpClient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));


                    HttpResponseMessage response = await httpClient.GetAsync("WhoAmI", HttpCompletionOption.ResponseContentRead);
                    
                    //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, )

                    if(response.IsSuccessStatusCode == true)
                    {
                        //working code
                        JObject resp = JObject.Parse(await response.Content.ReadAsStringAsync());
                    }



                }

                Console.Read();

            }
            catch (AdalException ex)
            {

                throw;
            }



        }
    }
}
