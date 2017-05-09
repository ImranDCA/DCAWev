using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace RepositoryProvider
{
    /// <summary>
    /// Organization Repository for the Interface
    /// </summary>
    /// <seealso cref="RepositoryProvider.IOrgRepository" />
    public abstract class OrganizationRepository<T> : IOrgRepository<T> where T: IDCEntity
    {
        public abstract Guid Create(T ent);

        public abstract void Delete(T ent);
        
        public abstract void Update(T ent);

        
    }
}
