using ADCGroup_Service.InterfaceEx.Service_Booking;
using ADCGroup_Service.InterfaceEx.Service_Html;
using ADCGroup_Service.InterfaceEx.Service_Login;
using ADCGroup_Service.Model.BasicModel.Account;
using ADCGroup_Service.Model.JiraModel.InfoUser;
using ADCGroup_Service.Model.JiraModel.Issue;
using System.Collections.Generic;
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
        public ActionResult HomeBooking()
        {
            try
            {
                Accounts acc = TempData["AccountInHome"] as Accounts;
                TempData.Keep("AccountInHome");
                List<Issue> ListIssueToday = this.service_meeting.GetAllIssueToday(acc);
                List<Issue> ListRoom2Big = this.service_meeting.GetAllIssuebyRoom2bigToday(acc);
                List<Issue> ListRoom2Small = this.service_meeting.GetAllIssuebyRoom2smallToday(acc);
                List<Issue> ListRoom4 = this.service_meeting.GetAllIssuebyRoom4Today(acc);
                List<Issue> ListRoom6 = this.service_meeting.GetAllIssuebyRoom6Today(acc);
                string htmlMeetingRoom2bigToday = this.service_htmlmeeting.MeetingRoomTodayTable(ListRoom2Big);
                string htmlMeetingRoom2smallToday = this.service_htmlmeeting.MeetingRoomTodayTable(ListRoom2Small);
                string htmlMeetingRoom4Today = this.service_htmlmeeting.MeetingRoomTodayTable(ListRoom4);
                string htmlMeetingRoom6Today = this.service_htmlmeeting.MeetingRoomTodayTable(ListRoom6);
                string htmlPopup = this.service_htmlmeeting.MeetingRoomwithID(ListIssueToday);
                ViewData["htmlMeetingRoom2bigToday"] = htmlMeetingRoom2bigToday;
                ViewData["htmlMeetingRoom2smallToday"] = htmlMeetingRoom2smallToday;
                ViewData["htmlMeetingRoom4Today"] = htmlMeetingRoom4Today;
                ViewData["htmlMeetingRoom6Today"] = htmlMeetingRoom6Today;
                ViewBag.ListPopupToday = htmlPopup;
                InfoUser User = GetUser(acc);
                ViewBag.UserDislayName = User.displayName;
                return View();
            }
            catch
            {
                return View("Denied");
            }
        }

        [HttpGet]
        public ActionResult ResultDay(int _day, int _month)
        {

            return View();
        }

        [HttpGet]
        public ActionResult Booking()
        {
            return View();
        }

        public ActionResult Denied()
        {
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