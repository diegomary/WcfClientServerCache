﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServiceHost.Model;

namespace WCFServiceHost.Repository
{
  public  interface IEntityHistoryWriter
    {
        bool UpdateEntityHistory(EntityHistory entityHistory);
    }
}
