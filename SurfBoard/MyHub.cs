using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SurfBoard
{
    public class MyHub : Hub
    {
        public static void Hello(int id, int type, int checkid)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            context.Clients.All.updatedData(id, type, checkid);
        }

    }
}

