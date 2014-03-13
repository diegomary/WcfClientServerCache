using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFServiceHost.Model;

namespace WCFServiceHost.Wcf
{
    [ServiceContract]
    public interface IServiceClass
    {

        [OperationContract(IsOneWay = false)]  // Default Request/Reply   
        void UpdateCustomer(Customer request, Guid cacheId);

        [OperationContract(IsOneWay = false)] 
        Customer GetCustomer(ref Guid lastUpdate);

        [OperationContract(IsOneWay = false)]
        bool CompareGuidForCaching(Guid clientguid);

    }

}
