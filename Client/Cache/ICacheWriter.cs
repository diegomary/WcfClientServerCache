using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServiceHost.Model;


namespace WCFClientApp.Cache
{
    interface ICacheWriter
    {
        bool WriteCustomerInCache(Customer customer);
    }
}
