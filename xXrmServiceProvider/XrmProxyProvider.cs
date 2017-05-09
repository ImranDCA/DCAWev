using RepositoryProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Collections;

namespace XrmServiceProvider
{
    /// <summary>
    /// Class that implements the xrm methods by querying
    /// Xrm Service context
    /// </summary>
    /// <seealso cref="RepositoryProvider.OrganizationRepository" />
    /// <seealso cref="System.IDisposable" />
    public class XrmProxyProvider : OrganizationRepository, IDisposable
    {
        private IOrganizationService Service;

        /// <summary>
        /// Initializes a new instance of the <see cref="XrmProxyProvider"/> class. 
        /// this constructor is to be used by third party applications like console application
        /// WCF 
        /// </summary>
        /// <remarks>Will need extra parameters</remarks>
        public XrmProxyProvider()
        {            
            // to do: call an implementation of the method that generates Xrm Service Provider
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="XrmProxyProvider" /> class.
        /// this constructor is to be used for BPO project with in d365
        /// i.e plugin, workflow, action
        /// </summary>
        /// <param name="_service">The service.</param>
        public XrmProxyProvider(IOrganizationService _service) { Service = _service; }

        #region Implementation of the core xrm messages
        /// <summary>
        /// Creates the specified ent.
        /// </summary>
        /// <param name="ent">The ent.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override Guid Create(IDCEntity ent)
        {
            throw new NotImplementedException();
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
        // ~XrmProxyProvider() {
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

        public override void Delete(IDCEntity ent)
        {
            throw new NotImplementedException();
        }

        public override void Update(IDCEntity ent)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
