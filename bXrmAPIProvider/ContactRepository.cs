using DtoProvider;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XrmAPIProvider.Helper;
using XrmAPIProvider.Interfaces;

namespace XrmAPIProvider
{
    public class ContactRepository :  XrmApiProvider, IContactRepository
    {


        public ContactRepository(string Resource, string ClientId, string RedirectUrl) : base(Resource, ClientId, RedirectUrl) { }
      

        public object ConvertTo(ContactDto DCEntity)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Gets all the contact with filter
        /// selects only dca ref num, full name, email.
        /// and filters by email.
        /// </summary>
        public void GetContactWithfilter(string Email)
        {
            string ContactUri = "contacts";
            string selectColumns = "?$select=bu_referencenumber,fullname,emailaddress1,telephone1";
            if (!string.IsNullOrEmpty(Email))
                selectColumns += string.Format(CultureInfo.InvariantCulture, "&$filter=emailaddress1 eq '{0}'", Email);

            HttpResponseMessage response =  SendCrmRequestAsync(HttpMethod.Get, ContactUri + selectColumns).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string body = response.Content.ReadAsStringAsync().Result;
                JObject result = JsonConvert.DeserializeObject<JObject>(body);
            }

            else
                throw new CrmHttpResponseException(response.Content);
        }

        public void GetContactWithFormattedValue(string Email)
        {
            string ContactUri = "contacts";
            string selectColumns = "?$select=bu_referencenumber,fullname,emailaddress1,telephone1,_bu_mobilephoneprefix_value";
            if (!string.IsNullOrEmpty(Email))
                selectColumns += string.Format(CultureInfo.InvariantCulture, "&$filter=emailaddress1 eq '{0}'", Email);

            HttpResponseMessage response = SendCrmRequestAsync(HttpMethod.Get, ContactUri + selectColumns, true).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string body = response.Content.ReadAsStringAsync().Result;
                JObject result = JsonConvert.DeserializeObject<JObject>(body);
            }

            else
                throw new CrmHttpResponseException(response.Content);
        }


        public void GetContactWithExpand(string Email)
        {
            string ContactUri = "contacts";
            string selectColumns = "?$select=bu_referencenumber,fullname,emailaddress1,telephone1,_bu_mobilephoneprefix_value&$expand=bu_mobilephoneprefix($select=bu_name,bu_isocode,bu_prefix)";
            if (!string.IsNullOrEmpty(Email))
                selectColumns += string.Format(CultureInfo.InvariantCulture, "&$filter=emailaddress1 eq '{0}'", Email);

            HttpResponseMessage response = SendCrmRequestAsync(HttpMethod.Get, ContactUri + selectColumns, true).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string body = response.Content.ReadAsStringAsync().Result;
                JObject result = JsonConvert.DeserializeObject<JObject>(body);
            }

            else
                throw new CrmHttpResponseException(response.Content);
        }


        public void GetContactWithPhonePrefixFilter(string CountriyId)
        {
            string ContactUri = "contacts";
            string selectColumns = "?$select=bu_referencenumber,fullname,emailaddress1,telephone1,_bu_mobilephoneprefix_value&$expand=bu_mobilephoneprefix($select=bu_name,bu_isocode,bu_prefix)";

            if (!string.IsNullOrEmpty(CountriyId))
                selectColumns += string.Format(CultureInfo.InvariantCulture, "&$filter=bu_mobilephoneprefix/bu_countryid%20eq%20{0}", CountriyId);

            HttpResponseMessage response = SendCrmRequestAsync(HttpMethod.Get, ContactUri + selectColumns, true).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string body = response.Content.ReadAsStringAsync().Result;
                JObject result = JsonConvert.DeserializeObject<JObject>(body);
            }

            else
                throw new CrmHttpResponseException(response.Content);
        }


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
        // ~ContactRepository() {
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
