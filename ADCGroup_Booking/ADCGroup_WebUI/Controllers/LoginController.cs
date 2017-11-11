using ADCGroup_WebUI.Models.LoginModels;
using System.Web.Mvc;
using ADCGroup_Service.InterfaceEx.Service_Login;
using ADCGroup_Service.Model.JiraModel.LoginSession;
using ADCGroup_WebUI.Common;
using ADCGroup_Service.InterfaceEx.Service_Booking;
using ADCGroup_Service.InterfaceEx.Service_Html;
using System.Web.Security;

namespace ADCGroup_WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IService_Login serviceLogin;

        public LoginController(IService_Login _context)
        {
            this.serviceLogin = _context;
        }
        // GET: Login
        [HttpGet]
        public ActionResult Home()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Home(Accounts account)
        {
            return LoginAllJira(account, string.Empty);
        }

        private ActionResult LoginWithProject(Accounts account)
        {
            if (ModelState.IsValid)
            {
                int _code = this.serviceLogin.LoginServicewithIssue(account.Username, account.Password);
                if (_code == 200)
                {
                    ModelState.AddModelError("Notification", "Đăng nhập thành công");
                    LoginUser sess = new LoginUser();
                    sess.UserName = account.Username;
                    Session.Add(Common.LoginSession.USER_SESSION, sess.UserName);
                    return RedirectToAction("Index", "Building", new { _username = account.Username });
                    //return RedirectToAction("Index", "Home", new { _account = account });
                }
                else if (_code == 401)
                {
                    ModelState.AddModelError("Notification", "Sai tên đăng nhập hoặc mật khẩu");
                }
                else if (_code == 403)
                {
                    ModelState.AddModelError("Notification", "Bị chặn quyền truy cập");
                }
                else if (_code == 409)
                {
                    ModelState.AddModelError("Notification", "Tài khoản chưa xác minh");
                }
                else
                {
                    ModelState.AddModelError("Notification", "Lỗi đăng nhập");
                }
            }
            return View("Home");
        }

        private ActionResult LoginAllJira(Accounts account, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ResultLogin result = serviceLogin.LoginServicewithAccount(account.Username, account.Password);
                if (result.code == 401)
                {
                    ModelState.AddModelError("Notification", "Sai tên đăng nhập hoặc mật khẩu");
                }
                else if (result.code == 403)
                {
                    ModelState.AddModelError("Notification", "Bị chặn quyền truy cập");
                }
                else if (result.code == 200)
                {
                    LoginUser sess = new LoginUser();
                    sess.UserName = result.name;
                    Session.Add(Common.LoginSession.USER_SESSION, sess.UserName);
                    TempData["AccountData"] = account;
                    TempData.Keep();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Notification", "Bị chặn quyền truy cập");
                }
            }
            return View("Home");
        }
    }
}