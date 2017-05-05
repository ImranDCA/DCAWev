using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryProvider
{
    /// <summary>
    /// Provide the basic organization service 
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IOrgRepository 
    {
        /// <summary>
        /// Creates the specified ent.
        /// </summary>
        /// <param name="ent">The ent.</param>
        Guid Create(IDCEntity ent);

        /// <summary>
        /// Updates this instance.
        /// </summary>
        /// <param name="ent">The ent.</param>
        void Update(IDCEntity ent);

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        /// <param name="ent">The ent.</param>
        void Delete(IDCEntity ent);

    }
}
