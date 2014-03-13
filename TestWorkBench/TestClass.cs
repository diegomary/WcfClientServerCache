using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using WCFServiceHost.Model;
using WCFServiceHost.Wcf;

namespace TestWorkBench
{
    [TestFixture]
    public class TestClass
    {

        [Test]
        public void TestGetCustomer()
        {
            var newguid = Guid.NewGuid();
            Customer testcustomer = new Customer { Address="Street 20", CompanyName="DMM", ContactName="Diego Burlando" };
            var moqservice = new Mock<IServiceClass>();
            moqservice.Setup(x => x.GetCustomer(ref newguid)).Returns(testcustomer);
            var service = moqservice.Object;
            Customer custreturn = service.GetCustomer(ref newguid);
            Assert.AreEqual(custreturn, testcustomer);
        }

        [Test]
        public void TestUpdateCustomer()
        {
            var newguid = Guid.NewGuid();
            var moqservice = new Mock<IServiceClass>();
            moqservice.Setup(x => x.CompareGuidForCaching(newguid)).Returns(true);
            var service = moqservice.Object;
            bool ret = service.CompareGuidForCaching(newguid);
            Assert.AreEqual(ret, true);
        }

    }
}
