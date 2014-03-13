using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServiceHost.Model;

namespace WCFServiceHost.Notification
{
    public class NotificationSystem
    {
        public INotifyService iservice {get; set; }
     
        public NotificationSystem(INotifyService notifyservice)
        {
            this.iservice = notifyservice;           
        }
        public void Notify()
        {
            if (iservice == null) 
            {
                throw new InvalidOperationException("Null value passed");
            }
            iservice.NotifyMedia();
        }

        public Customer RescueCustomer()
        {
            if (iservice == null)
            {
                throw new InvalidOperationException("Null value passed");
            }
            return iservice.GetCustomer();
        }

    }
}
