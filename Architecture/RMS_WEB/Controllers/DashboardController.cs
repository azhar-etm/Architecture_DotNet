using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ENTITY;
using Utility;
using RMS_WEB.Models;
using System.Web.Security;

namespace RMS_WEB.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/
        [Authorize]       
        public ActionResult Index()
        {
            return View();
        }
    }
}
