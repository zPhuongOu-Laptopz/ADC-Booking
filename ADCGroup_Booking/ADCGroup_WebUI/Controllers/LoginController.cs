using ADCGroup_WebUI.Models.LoginModels;
using ADCGroup_Service.Service_BookingRoom.Service_Login;
using System.Web.Mvc;
using System.Web.Routing;

namespace ADCGroup_WebUI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Home(Accounts account)
        {
            int _code = new Service_Login(account.Username, account.Password) { }.LoginService();
            if (_code == 200)
            {
                ModelState.AddModelError("Notification", "Đăng nhập thành công");
                return RedirectToAction("Index", "Building", new { _username = account.Username });
            }
            else if (_code == 401)
            {
                ModelState.AddModelError("Notification", "Sai tên đăng nhập hoặc mật khẩu");
            }
            else if (_code == 403)
            {
                ModelState.AddModelError("Notification", "Không có quyền truy cập");
            }
            else if (_code == 409)
            {
                ModelState.AddModelError("Notification", "Tài khoản chưa xác minh");
            }
            else
            {
                ModelState.AddModelError("Notification", "Lỗi sai còn lại");
            }
            return View();
        }
    }
}