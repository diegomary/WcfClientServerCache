using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestForLoadAndStress.CustomerService;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;


namespace TestForLoadAndStress
{
    [TestClass]
    public class TestStress
    {
        private Dictionary<string,Guid> stresstasks;
        private List<Task> alltasks;
        private int maxthread = 0;
        private ManualResetEvent checkend;
        [TestMethod]
        public void TestGetCustomerForReal()
        {

            using (ServiceClassClient serviceClassClient = new ServiceClassClient("NetTcpBinding_IServiceClass"))
            {
                NetworkCredential ntc = new NetworkCredential("wcf_user", ".DiEgo62AndMAry19998");           
                Guid instanceServerGui = new Guid();
                Customer customer = serviceClassClient.GetCustomer(ref instanceServerGui);             
                serviceClassClient.Close();
            }
        }

        [TestMethod]
        public void Stress()
        {
            stresstasks = new Dictionary<string, Guid>();
            alltasks = new List<Task>();
            checkend = new ManualResetEvent(false);
            for (int counter = 0; counter < 1000; counter++)
            {
                alltasks.Add(new Task(() => PerformStress()));
            }
            foreach(Task tk in alltasks)
            {
                tk.Start();
            }
            checkend.WaitOne();         

        }

        private void PerformStress()
        {
            using (ServiceClassClient serviceClassClient = new ServiceClassClient("NetTcpBinding_IServiceClass"))
            {
                NetworkCredential ntc = new NetworkCredential("wcf_user", ".DiEgo62AndMAry19998");
                Guid instanceServerGui = new Guid();
                Customer customer = serviceClassClient.GetCustomer(ref instanceServerGui);
                serviceClassClient.Close();
                stresstasks.Add(maxthread.ToString(), instanceServerGui);
                maxthread++;
                if (maxthread == 999) checkend.Set();
            }

        }


    }
}







  


      
           
          
        
    
