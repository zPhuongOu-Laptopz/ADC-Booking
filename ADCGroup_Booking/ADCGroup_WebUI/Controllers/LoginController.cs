using ADCGroup_WebUI.Models.LoginModels;
using System.Web.Mvc;

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

        [HttpPost]
        public ActionResult Home(Accounts account)
        {
            if (account.Username == null)
            {
                ModelState.AddModelError("Notification", "Bạn chưa nhập tài khoản");
            }
            else if (account.Password == null)
            {
                ModelState.AddModelError("Notification", "Bạn chưa nhập mật khẩu");
            }
            else if (account.Username == "admin" && account.Password == "admin")
            {
                ModelState.AddModelError("Notification", "Đăng nhập thành công");
            }
            else
            {
                ModelState.AddModelError("Notification", "Sai tài khoản hoặc mật khẩu");
            }
            return View();
        }

        public void TestLogin()
        {

        }
    }
}