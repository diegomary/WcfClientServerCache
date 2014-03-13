using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFServiceHost.Model
{
    [CollectionDataContract]  // To serialize it properly with datacontractserializer
    public  class  EntityHistory:Dictionary<string,Guid> 
    {
        public EntityHistory() { }
    }
}
