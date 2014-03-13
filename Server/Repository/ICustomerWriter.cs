using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServiceHost.Model;

namespace WCFServiceHost.Repository
{
    interface ICustomerWriter
    {
        bool UpdateCustomer(Customer customer);

    }
}
