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
    public abstract class OrganizationRepository : IOrgRepository
    {
        public abstract Guid Create(IDCEntity ent);

        public abstract void Delete(IDCEntity ent);
        
        public abstract void Update(IDCEntity ent);

        
    }
}
