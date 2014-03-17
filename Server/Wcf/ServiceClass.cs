using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFServiceHost.Model;
using WCFServiceHost.Notification;
using WCFServiceHost.Repository;

namespace WCFServiceHost.Wcf
{
   [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single,InstanceContextMode = InstanceContextMode.PerCall)]
    public class ServiceClass : IServiceClass
    {       
        public void UpdateCustomer(Customer updatedCustomer,Guid cacheId)
        {
            ICustomerWriter writer = new CustomerWriter();
            writer.UpdateCustomer(updatedCustomer);
            // Than we register for the object Customer a GUID in cache
            EntityHistory entityhistory = new EntityHistory();           
            entityhistory.Add(typeof(Customer).ToString(), cacheId);
            // We save the cache
            IEntityHistoryWriter entityhistorywriter = new EntityHistoryWriter();
            entityhistorywriter.UpdateEntityHistory(entityhistory);
            // We notify the form
            INotifyService inotservice = new NotifyForm(updatedCustomer,cacheId.ToString());
            NotificationSystem ns = new NotificationSystem(inotservice);
            ns.Notify();
        }
        public Customer GetCustomer(ref Guid lastUpdate)
        {
            IEntityHistoryReader entityhistoryreader = new EntityHistoryReader();
            EntityHistory entityhistory= entityhistoryreader.LoadEntityHistory();
            KeyValuePair<string, Guid> customerpair = entityhistory.FirstOrDefault(m => m.Key.Contains("Customer"));
            lastUpdate = customerpair.Value;
            INotifyService inotservice = new NotifyForm();
            NotificationSystem ns = new NotificationSystem(inotservice);
            ns.NotifyGets();
            ICustomerReader reader = new CustomerReader();
            return reader.LoadCustomer();           
        }
       public bool CompareGuidForCaching(Guid clientguid)
       {
           IEntityHistoryReader entityhistoryreader = new EntityHistoryReader();
           EntityHistory entityhistory = entityhistoryreader.LoadEntityHistory();
           KeyValuePair<string, Guid> customerpair = entityhistory.FirstOrDefault(m => m.Key.Contains("Customer"));
           return  clientguid.Equals(customerpair.Value) ? true: false;
       }


    }
}