using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WCFServiceHost.Model;


namespace WCFClientApp.Cache
{
    class CacheReader:ICacheReader
    {
        private System.Object lockReader = new System.Object();

        public Customer LoadCustomerInCache()
        {
            try
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(Customer));
                string dbpath = string.Concat(Directory.GetCurrentDirectory(), @"\CacheFile.xml");
                lock (lockReader)
                {
                    using (Stream reader = new FileStream(dbpath, FileMode.Open))
                    {
                        Customer customer = (Customer)ser.ReadObject(reader);
                        return customer;
                    }
                }
            }
            catch (System.Runtime.Serialization.SerializationException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }
    }
}
