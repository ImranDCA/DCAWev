using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using XrmAPIProvider;
using XrmAPIProvider.Interfaces;
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
            using (IContactRepository con = new ContactRepository(ApiConnectionConstants.resource, ApiConnectionConstants.clentId, ApiConnectionConstants.redirectUrl))
            {
                con.GetContactWithfilter("Test@test.com");
            }
        }

        [Test]
        public void GetContactWithFormattedValue_Positive()
        {
            using (IContactRepository con = new ContactRepository(ApiConnectionConstants.resource, ApiConnectionConstants.clentId, ApiConnectionConstants.redirectUrl))
            {
                con.GetContactWithFormattedValue("Test@test.com");
            }
        }
        
        [Test]
        public void GetContactWithExpand_Positive()
        {
            using (IContactRepository con = new ContactRepository(ApiConnectionConstants.resource, ApiConnectionConstants.clentId, ApiConnectionConstants.redirectUrl))
            {
                con.GetContactWithExpand("Test@test.com");

            }
        }        

        [Test]
        public void GetContactWithPhonePrefixFilter_Positive()
        {
            using (IContactRepository con = new ContactRepository(ApiConnectionConstants.resource, ApiConnectionConstants.clentId, ApiConnectionConstants.redirectUrl))
            {
                con.GetContactWithPhonePrefixFilter("094556D5-FF2E-E611-80E4-5065F38BD4C1");

            }
        }
    }
}
