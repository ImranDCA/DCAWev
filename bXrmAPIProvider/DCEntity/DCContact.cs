using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RepositoryProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bXrmAPIProvider.DCEntity
{
    public class DCContact : IDCEntity
    {
        public string EntityLogicalName { get; set; }

        public string EntityPluralName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public T Convert<T>() 
        {
            JObject contact = new JObject();
            contact.Add("firstname", this.FirstName);
            contact.Add("lastname", this.FirstName);

            

            return (T)(object)contact;
        }
    }
}
