using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServiceHost.Model;

namespace WCFClientApp.Cache
{
    public static class CacheManagement
    {
       public  static void  ClearCache()
       {
           try
           {
               File.Delete(string.Concat(Directory.GetCurrentDirectory(), @"\CacheFile.xml"));
           }
           catch(FileNotFoundException ex)
           {
               Console.WriteLine(ex.Message);
           }
       }
       public static void WriteInCache(Customer customer)
       {
           ICacheWriter cachewriter = new CacheWriter();
           bool ret = cachewriter.WriteCustomerInCache(customer);       
       
       }

    }
}
