using RepositoryProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoProvider
{
    public class AccountDto : IDCEntity
    {
        public Guid EntityId { get; set; }

        public string EntityLogicalName { get; set; }

        public string EntityPluralName { get; set; }
    }
}
