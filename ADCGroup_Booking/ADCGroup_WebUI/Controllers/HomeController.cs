using ADCGroup_Service.InterfaceEx.Service_Booking;
using ADCGroup_Service.InterfaceEx.Service_Html;
using ADCGroup_Service.InterfaceEx.Service_Login;
using ADCGroup_Service.Model.BasicModel.Account;
using ADCGroup_Service.Model.JiraModel.InfoUser;
using ADCGroup_Service.Model.JiraModel.Issue;
using ADCGroup_Service.Service.Service_Login;
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
        private readonly IHtml_MeetingRoom service_htmlmeeting;
        private readonly IJiraLogin service_jiralogin;
        Accounts account;

        /// <summary>
        /// Ctor Home Controller
        /// </summary>
        /// <param name="_service"></param>
        /// <param name="_html"></param>
        public HomeController(IMeeting _service, IHtml_MeetingRoom _html, IJiraLogin _jiralogin, Accounts _ac)
        {
            this.service_meeting = _service;
            this.service_htmlmeeting = _html;
            this.service_jiralogin = _jiralogin;
            this.account = _ac;
        }

        // GET : Home/Index
        [HttpGet]
        public ActionResult Index(Accounts ac) //Improve
        {
            try
            {
                Models.LoginModels.Accounts acc = TempData["AccountData"] as Models.LoginModels.Accounts;
                this.account.username = acc.Username;
                this.account.password = acc.Password;
                InfoUser User = this.service_jiralogin.GetInfoUser(account);
                ViewBag.DislayName = User.displayName;
                TempData["AccountInHome"] = this.account;
                TempData.Keep("AccountInHome");
                return View();
            }
            catch
            {
                Accounts acc = TempData["AccountInHome"] as Accounts;
                TempData.Keep();
                InfoUser User = this.service_jiralogin.GetInfoUser(acc);
                ViewBag.DislayName = User.displayName;
                TempData["AccountInHome"] = acc;
                TempData.Keep("AccountInHome");
                return View();
            }
        }

        // GET : Home/Home_Booking
        public ActionResult Home_Booking()
        {
            Accounts acc = TempData["AccountInHome"] as Accounts;
            TempData.Keep("AccountInHome");
            List<Issue> ListIssueToday = GetAllIssueToday(acc);
            string htmlMeetingRoomToday = this.service_htmlmeeting.MeetingRoomToday(ListIssueToday);
            ViewBag.ListIssueToday = htmlMeetingRoomToday;
            InfoUser User = GetUser(acc);
            ViewBag.UserDislayName = User.displayName;
            return View();
        }

        public InfoUser GetUser(Accounts a)
        {
            return this.service_jiralogin.GetInfoUser(a);
        }

        public List<Issue> GetAllIssue(Accounts a)
        {
            return this.service_meeting.GetAllIssue(a);
        }

        public List<Issue> GetAllIssueToday(Accounts a)
        {
            return this.service_meeting.GetAllIssueToday(a);
        }
    }
}