using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServiceHost.Model;

namespace WCFServiceHost.Notification
{
    class NotifyForm:INotifyService
    {
        private Customer _customer;
        private string _guid;
        public NotifyForm(Customer customer, string guid)
        {
            _customer = customer;
            _guid = guid;
        }
        public NotifyForm()
        { }        
        public void NotifyMedia()
        {
            WCFServiceHost.Program.starter.txtAddress.Text = _customer.Address;
            WCFServiceHost.Program.starter.txtCompanyName.Text = _customer.CompanyName;
            WCFServiceHost.Program.starter.txtContactName.Text = _customer.ContactName;
            WCFServiceHost.Program.starter.txtGuid.Text = _guid;
           
        }

        public void NotifyNumberOfGets()
        {           
            WCFServiceHost.Program.starter.txtNumCalls.Text = (Convert.ToInt32(WCFServiceHost.Program.starter.txtNumCalls.Text) + 1).ToString();
        }

        public Customer GetCustomer()
        {
            Customer customer = new Customer
            {
                Address = WCFServiceHost.Program.starter.txtAddress.Text,
                CompanyName =
                    WCFServiceHost.Program.starter.txtCompanyName.Text,
                ContactName = WCFServiceHost.Program.starter.txtContactName.Text
            };
            return customer;
        }

    }
}
