using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurfBoard.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashborad
        public ActionResult DashBoard()
        {
            return View();
        }
    }
}