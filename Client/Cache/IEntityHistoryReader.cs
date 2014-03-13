using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFClientApp.Model;
using WCFServiceHost.Model;

namespace WCFClientApp.Cache
{
 public   interface IEntityHistoryReader
    {

        EntityHistory LoadEntityHistory();

    }
}
