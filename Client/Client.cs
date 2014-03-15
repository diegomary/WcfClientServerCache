using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using WCFServiceHost.Model;
using WCFClientApp.Cache;
using System.IO;
using WCFClientApp.Model;
using System.Linq;
using System.Net;


namespace WCFClientApp
{
    public partial class Client : Form
    {
        private ServiceClassClient serviceClassClient;        
        public Client()
        {
            InitializeComponent();          
            CacheManagement.ClearCache();
        }
        private void btnGetData_Click_1(object sender, EventArgs e)
        {

            using (serviceClassClient = new ServiceClassClient("NetTcpBinding_IServiceClass"))
            {
                NetworkCredential ntc = new NetworkCredential("wcf_service_user", "wcf_service_user");
                serviceClassClient.ClientCredentials.Windows.ClientCredential = ntc;
             //   serviceClassClient.ClientCredentials.Windows.ClientCredential = CredentialCache.DefaultNetworkCredentials;
                // Create a new Guid to pass by reference
                Guid instanceServerGui = new Guid();
                Customer customer = serviceClassClient.GetCustomer(ref instanceServerGui);
                // Write in Cache the server instance
                CacheManagement.WriteInCache(customer);
                // Write in the local Dictionary the value of Guid for the updated instance
                EntityHistory entityHistory = new EntityHistory();
                entityHistory.Add(typeof(Customer).ToString(), instanceServerGui);
                IEntityHistoryWriter entityhistorywriter = new EntityHistoryWriter();
                entityhistorywriter.UpdateEntityHistory(entityHistory);
                // Notify the form
                txtAddress.Text = customer.Address;
                txtCompanyName.Text = customer.CompanyName;
                txtContactName.Text = customer.ContactName;
                txtGuid.Text = instanceServerGui.ToString();
                serviceClassClient.Close();
            }

        }

        private void btnUpdateData_Click_1(object sender, EventArgs e)
        {
            using (serviceClassClient = new ServiceClassClient("NetTcpBinding_IServiceClass"))
            {
                NetworkCredential ntc = new NetworkCredential("wcf_service_user", "wcf_service_user");
                serviceClassClient.ClientCredentials.Windows.ClientCredential = ntc;
                Customer customer = new Customer();
                customer.Address = txtAddress.Text;
                customer.CompanyName = txtCompanyName.Text;
                customer.ContactName = txtContactName.Text;
                Guid clientGuid = Guid.NewGuid();
                txtGuid.Text = clientGuid.ToString();
                serviceClassClient.UpdateCustomer(customer, clientGuid);
                CacheManagement.WriteInCache(customer);
                EntityHistory entityHistory = new EntityHistory();
                entityHistory.Add(typeof(Customer).ToString(), clientGuid);
                IEntityHistoryWriter entityhistorywriter = new EntityHistoryWriter();
                entityhistorywriter.UpdateEntityHistory(entityHistory);
                serviceClassClient.Close();
            }

        }

        private void btnRescueUpi_Click(object sender, EventArgs e)
        {
            using (serviceClassClient = new ServiceClassClient("NetTcpBinding_IServiceClass"))
            {
                NetworkCredential ntc = new NetworkCredential("wcf_service_user", "wcf_service_user");
                serviceClassClient.ClientCredentials.Windows.ClientCredential = ntc;
                // We read the Cache Dictionary now
                IEntityHistoryReader reader = new EntityHistoryReader();
                EntityHistory enth = new EntityHistory();
                enth = reader.LoadEntityHistory();
                KeyValuePair<string, Guid> customerPair = enth.FirstOrDefault(m => m.Key.Contains("Customer"));
                bool ret = serviceClassClient.CompareGuidForCaching(customerPair.Value);
                switch (ret)
                {
                    case true:
                        txtUptoDate.Text = customerPair.Value.ToString();
                        break;
                    case false:
                        // We need to rescue the object from the server and update the cache and the dictionary
                        Guid instanceServerGui = new Guid();
                        Customer customer = serviceClassClient.GetCustomer(ref instanceServerGui);
                        CacheManagement.WriteInCache(customer);                     
                        EntityHistory entityHistory = new EntityHistory();
                        entityHistory.Add(typeof(Customer).ToString(), instanceServerGui);
                        IEntityHistoryWriter entityhistorywriter = new EntityHistoryWriter();
                        entityhistorywriter.UpdateEntityHistory(entityHistory);                                     
                        // We notify the app
                        txtNotUpTodate.Text = instanceServerGui.ToString();
                        // We also notify the service behaviour panel
                        txtAddress.Text = customer.Address;
                        txtCompanyName.Text = customer.CompanyName;
                        txtContactName.Text = customer.ContactName;
                        txtGuid.Text = instanceServerGui.ToString();
                        break;
                }
                serviceClassClient.Close();
            }
        }
    }
}