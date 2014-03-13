using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WCFServiceHost.Model;



//The lock keyword can be used to ensure that a block of code runs to completion without interruption by other threads.
//This is accomplished by obtaining a mutual-exclusion lock for a given object for the duration of the code block.


namespace WCFClientApp.Cache
{
    class CacheWriter:ICacheWriter
    {
        private System.Object lockWriter = new System.Object();

        public bool WriteCustomerInCache(Customer customer)
        {
            try
            {
                string dbpath = string.Concat(Directory.GetCurrentDirectory(), @"\CacheFile.xml");
                DataContractSerializer ser = new DataContractSerializer(typeof(Customer));
                lock (lockWriter)
                {
                    using (Stream writer = new FileStream(dbpath, FileMode.Create))
                    {
                        ser.WriteObject(writer, customer);
                        return true;
                    }
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
