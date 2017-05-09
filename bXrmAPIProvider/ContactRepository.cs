using DtoProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
            HttpResponseMessage response =  SendCrmRequestAsync(HttpMethod.Get, ContactUri + selectColumns).Result;
            
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
