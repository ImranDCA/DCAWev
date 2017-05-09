using RepositoryProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrmAPIProvider.Interfaces
{
    public interface MasterRepository<T> where T:IDCEntity
    {
        object ConvertTo(T DCEntity);


    }
}
