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
        void Update();

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        void Delete();


        /// <summary>
        /// Retrieves the mudltiple entity.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        IEnumerable RetrieveMudltipleEntity(QueryExpression query) ;



    }
}
