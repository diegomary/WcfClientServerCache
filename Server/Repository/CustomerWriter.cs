using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WCFServiceHost.Model;

namespace WCFServiceHost.Repository
{
    class CustomerWriter:ICustomerWriter
    {
     public bool UpdateCustomer(Customer customer)
        {           
            try
            {
               string dbpath = string.Concat(Directory.GetCurrentDirectory(), @"\DbCustomer.xml");
               DataContractSerializer ser = new DataContractSerializer(typeof(Customer));
               using (Stream writer = new FileStream(dbpath, FileMode.Create))
               {
                   ser.WriteObject(writer, customer);
                   return true;
               }               
            }
            catch (System.Runtime.Serialization.SerializationException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return false;
            }

        }

    }
}
