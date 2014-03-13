using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFServiceHost.Wcf
{
   public class CustomerHost
    {
        private ServiceHost shost;
        public CustomerHost()
        {
            shost = new ServiceHost(typeof(ServiceClass));
            shost.Open();
        }
       public void CloseHost()
       {
            shost.Close();
       }
    }
}
