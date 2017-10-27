using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADCGroup_WebUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index(string username)
        {
            ViewBag.Name = username;
            return View();
        }

        [HttpGet]
        public ActionResult MeetingRoom()
        {
            return View();
        }

        public string OpenModelPopup()
        {
            //can send some data also.
            return "<h1>This is Modal Popup Window</h1>";
        }
    }
}