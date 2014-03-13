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
  public  class EntityHistoryReader:IEntityHistoryReader
    {
    public EntityHistory LoadEntityHistory()
    {
        try
        {
            DataContractSerializer ser = new DataContractSerializer(typeof(EntityHistory));
            string dbpath = string.Concat(Directory.GetCurrentDirectory(), @"\cachedictionary.xml");
            using (Stream reader = new FileStream(dbpath, FileMode.Open))
            {
                EntityHistory entityhistory = (EntityHistory)ser.ReadObject(reader);
                return entityhistory;
            }            
        }

         catch( System.Runtime.Serialization.SerializationException ex)
        {
            Console.WriteLine(ex.Message.ToString());
            return null;
        }     
            
     }

}
}

