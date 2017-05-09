using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XrmAPIProvider;
using static bXrmAPIProvider.IntegrationTest.Model.ModelGenerator;

namespace bXrmAPIProvider.IntegrationTest
{
    [TestFixture]
    [Category("ContactRepositoryTests")]
    public class ContactRepositoryTests
    {
        [Test]
        public void GetContactWithfilter_Positive()
        {
            using (ContactRepository con = new ContactRepository(ApiConnectionConstants.resource, ApiConnectionConstants.clentId, ApiConnectionConstants.redirectUrl))
            {
                con.GetContactWithfilter("j.grbic+comingo@vegait.rs");
            }
        }
    }
}
