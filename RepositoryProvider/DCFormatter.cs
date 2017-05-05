using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryProvider
{
    public abstract class DCFormatter
    {
        /// <summary>
        /// Converts to dto.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="BusinessEntity">The business entity.</param>
        /// <returns></returns>
        public abstract IDCEntity ConvertToDto<TEntity>(TEntity BusinessEntity);
    }
}
