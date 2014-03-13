using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Description;
using WCFServiceHost.Wcf;
using WCFServiceHost.Repository;
using WCFServiceHost.Model;
using WCFServiceHost.Notification;


namespace WCFServiceHost
{
    public partial class Server : Form
    {
        private CustomerHost vHost;
        private INotifyService inotservice;
        private NotificationSystem ns;
        public Server()
        {
            InitializeComponent();           
        }
        private void Form1_Load(object sender, EventArgs e)
        {          
          
           // We get the customer from the textboxes on the form
            inotservice = new NotifyForm();
            ns = new NotificationSystem(inotservice);
            Customer storedCustomer =  ns.RescueCustomer();
            // First we write the instance in the Repository
            ICustomerWriter writer = new CustomerWriter();
            writer.UpdateCustomer(storedCustomer);
            // Than we register for the object Customer a GUID in cache
            EntityHistory entityhistory = new EntityHistory();
            Guid updatedguid= Guid.NewGuid();
            entityhistory.Add(typeof(Customer).ToString(), updatedguid);
            // We save the cache
            IEntityHistoryWriter entityhistorywriter = new EntityHistoryWriter();
            entityhistorywriter.UpdateEntityHistory(entityhistory);
            // We notify the media of the customer. In this case the media is the Form GUI
            inotservice = new NotifyForm(storedCustomer, updatedguid.ToString());
            ns = new NotificationSystem(inotservice);
            ns.Notify();
            // We start The service
            StartListen();
        }

        private void StartListen()
        {
            vHost = new CustomerHost();
            label1.Text = "Service Running";

        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            vHost.CloseHost();
        }
    }
}
