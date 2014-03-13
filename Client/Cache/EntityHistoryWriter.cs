using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WCFClientApp.Model;
using WCFServiceHost.Model;

namespace WCFClientApp.Cache
{
 public class EntityHistoryWriter:IEntityHistoryWriter
    {
        public bool UpdateEntityHistory(EntityHistory entityHistory)
        {
            try
            {
                string dbpath = string.Concat(Directory.GetCurrentDirectory(), @"\cachedictionary.xml");
                DataContractSerializer ser = new DataContractSerializer(typeof(EntityHistory));
                using (Stream writer = new FileStream(dbpath, FileMode.Create))
                {
                    ser.WriteObject(writer, entityHistory);
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
