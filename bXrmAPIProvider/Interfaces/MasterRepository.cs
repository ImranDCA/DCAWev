using RepositoryProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrmAPIProvider.Interfaces
{
    public interface IMasterRepository<T> : IDisposable where T:IDCEntity
    {
        object ConvertTo(T DCEntity);


    }
}
