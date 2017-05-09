using DtoProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrmAPIProvider.Interfaces
{
    public interface IContactRepository : MasterRepository<ContactDto>
    {
        void GetContactWithfilter(string Email);
     
    }
}
