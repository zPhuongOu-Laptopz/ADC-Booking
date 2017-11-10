using ADCGroup_Service.InterfaceEx.Service_Booking;
using ADCGroup_Service.InterfaceEx.Service_Html;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADCGroup_WebUI.Controllers
{
    public class HomeController : BaseController
    {
        /// <summary>
        /// Variable
        /// </summary>
        private readonly IMeeting service_meeting;
        private readonly IHtml_MeetingRoom html_meeting;

        /// <summary>
        /// Ctor Home Controller
        /// </summary>
        /// <param name="_service"></param>
        /// <param name="_html"></param>
        public HomeController(IMeeting _service, IHtml_MeetingRoom _html)
        {
            this.service_meeting = _service;
            this.html_meeting = _html;
        }

        // GET : Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // GET : HOME
        [HttpGet]
        public ActionResult Home_Booking()
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