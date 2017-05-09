using RepositoryProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Collections;
using Newtonsoft.Json.Linq;
using System.Net.Http;

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Net.Http.Headers;
using XrmAPIProvider.Model;

namespace XrmAPIProvider
{
    /// <summary>
    /// A class that implement xrm methods by querying 
    /// Xrm Web api. See one notes
    /// </summary>
    /// <seealso cref="RepositoryProvider.OrganizationRepository" />
    /// <seealso cref="System.IDisposable" />
    public class XrmApiProvider : OrganizationRepository<IDCEntity>, IDisposable
    {
        #region Private variable

        HttpClient httpClient;

        #endregion        

        /// <summary>
        /// Initializes a new instance of the <see cref="XrmApiProvider"/> class.
        /// </summary>
        /// <param name="Resource">The resource.</param>
        /// <param name="ClientId">The client identifier.</param>
        /// <param name="RedirectUrl">The redirect URL.</param>
        public XrmApiProvider(string Resource, string ClientId, string RedirectUrl)
        {            
            httpClient = CreateHTTPClient(Resource, ClientId, RedirectUrl).Result;
        }

        /// <summary>
        /// Creates the specified ent.
        /// </summary>
        /// <param name="ent">The ent.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override Guid Create(IDCEntity ent)
        {
            //JObject test = ent.Convert<JObject>();
            JObject test = new JObject();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, ent.EntityPluralName);
            //request.Content = new StringContent(ent.Convert<JObject>().ToString(), Encoding.UTF8, APICallConstants.HttpRequestHeaders.JSON_RESPONSE_TYPE);
            HttpResponseMessage response = Execute(request).Result;
            throw new NotImplementedException();
        }


        public override void Delete(IDCEntity ent)
        {
            throw new NotImplementedException();
        }

        public override void Update(IDCEntity ent)
        {
            throw new NotImplementedException();
        }


        #region Private Methods
        async Task<HttpClient> CreateHTTPClient(string Resource, string ClientId, string RedirectUrl)
        {
            AuthenticationContext authContext = new AuthenticationContext("https://login.windows.net/common", false);
            AuthenticationResult result = await authContext.AcquireTokenAsync(Resource, ClientId, new Uri(RedirectUrl), new PlatformParameters(PromptBehavior.Auto));

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Resource + APICallConstants.HttpRequestHeaders.BASE_ADDRESS_POSTFIX);
            httpClient.Timeout = new TimeSpan(0, APICallConstants.HttpRequestHeaders.TIME_OUT, 0);  // 2 minutes
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(APICallConstants.HttpRequestHeaders.BEARER, result.AccessToken);
            httpClient.DefaultRequestHeaders.Add(APICallConstants.HttpRequestHeaders.ODATA_MAX_VERSION, APICallConstants.HttpRequestHeaders.ODATA_VERSION_VALUE);
            httpClient.DefaultRequestHeaders.Add(APICallConstants.HttpRequestHeaders.ODATA_VERSION, APICallConstants.HttpRequestHeaders.ODATA_VERSION_VALUE);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(APICallConstants.HttpRequestHeaders.JSON_RESPONSE_TYPE));
            return httpClient;            
        }

        async Task<HttpResponseMessage> Execute(HttpRequestMessage request)
        {
            return await httpClient.SendAsync(request);
        }
        #endregion



        #region Internal Method
        /// <summary>
        /// Sends the CRM request asynchronous.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="query">The query.</param>
        /// <param name="formatted">if set to <c>true</c> [formatted].</param>
        /// <param name="maxPageSize">Maximum size of the page.</param>
        /// <returns></returns>
        internal async Task<HttpResponseMessage> SendCrmRequestAsync(
                    HttpMethod method, string query, bool formatted = false, int maxPageSize = 10)
        {
            HttpRequestMessage request = new HttpRequestMessage(method, query);
            request.Headers.Add("Prefer", "odata.maxpagesize=" + maxPageSize.ToString());
            if (formatted)
                request.Headers.Add("Prefer",
                    "odata.include-annotations=OData.Community.Display.V1.FormattedValue");
            return await httpClient.SendAsync(request);
        }
        #endregion
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~XrmApiProvider() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

      


        #endregion
    }
}
