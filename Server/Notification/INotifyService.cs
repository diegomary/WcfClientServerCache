﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServiceHost.Model;

namespace WCFServiceHost.Notification
{
    public interface INotifyService
    {
        void NotifyMedia();
        void NotifyNumberOfGets();
        Customer GetCustomer();
    }
}
