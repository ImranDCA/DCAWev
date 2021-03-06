﻿using RepositoryProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoProvider
{
    public class ContactDto : IDCEntity
    {
        public Guid EntityId { get; set; }        

        public string EntityLogicalName { get; set; }

        public string EntityPluralName { get; set; }

        public string FirstName { get; set; }

        public AccountDto AccountName { get; set; }


    }
}
