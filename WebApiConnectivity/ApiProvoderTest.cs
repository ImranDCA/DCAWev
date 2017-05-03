using bXrmAPIProvider;
using bXrmAPIProvider.DCEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiConnectivity
{
    class ApiProvoderTest
    {
        static void Main(string[] args)
        {
            XrmApiProvider _api = new XrmApiProvider("https://dca-solution.crm4.dynamics.com/","e5f9ee14-b122-47ba-ae6d-079f2e9a5ed6", "https://web-api-poc.doctorcareanywhere.com/");
            _api.Create(modelGenerator.getContact());
                
        }
    }


    public class modelGenerator
    {
        public static DCContact getContact()
        {
            return new DCContact() { EntityLogicalName = "contact", EntityPluralName = "contacts", FirstName = "steve", LastName = "smith" };
        }
    }
}
