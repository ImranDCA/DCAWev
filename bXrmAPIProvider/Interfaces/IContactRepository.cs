using DtoProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrmAPIProvider.Interfaces
{
    public interface IContactRepository : IMasterRepository<ContactDto>
    {
        void GetContactWithfilter(string Email);
        void GetContactWithFormattedValue(string Email);
        void GetContactWithExpand(string Email);
        void GetContactWithPhonePrefixFilter(string CountriyId);

    }
}
