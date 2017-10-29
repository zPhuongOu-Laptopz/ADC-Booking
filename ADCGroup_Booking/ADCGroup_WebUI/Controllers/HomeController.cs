using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADCGroup_WebUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Test()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MeetingRoom()
        {
            //DateTime dt1 = DateTime.ParseExact(DateTime.Now.ToString(), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            DateTime dt1 = DateTime.Now;
            var dt2 = dt1.AddDays(1);
            var dt3 = dt1.AddDays(2);
            var dt4 = dt1.AddDays(3);
            var dt5 = dt1.AddDays(4);
            string date1 = dt1.ToString("dd/MM", CultureInfo.InvariantCulture);
            string date2 = dt2.ToString("dd/MM", CultureInfo.InvariantCulture);
            string date3 = dt3.ToString("dd/MM", CultureInfo.InvariantCulture);
            string date4 = dt4.ToString("dd/MM", CultureInfo.InvariantCulture);
            string date5 = dt5.ToString("dd/MM", CultureInfo.InvariantCulture);
            ViewBag.date1 = date1;
            ViewBag.date2 = date2;
            ViewBag.date3 = date3;
            ViewBag.date4 = date4;
            ViewBag.date5 = date5;
            return View();
        }

        public string OpenModelPopup()
        {
            //can send some data also.
            return "<h1>This is Modal Popup Window</h1>";
        }
    }
}