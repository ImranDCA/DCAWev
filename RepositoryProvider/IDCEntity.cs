using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryProvider
{
    public interface IDCEntity
    {
        string EntityLogicalName { get; set; }

        string EntityPluralName { get; set; }

        T Convert<T>(); 
    }
}
