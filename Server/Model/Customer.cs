using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFServiceHost.Model
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public   string ContactName { get; set; }
        [DataMember]
        public   string Address { get; set; }
    }
}
