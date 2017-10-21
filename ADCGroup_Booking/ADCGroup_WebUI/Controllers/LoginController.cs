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
                ModelState.AddModelError("Notification", "Bạn chưa nhập Username");
            }
            else if (account.Password == null)
            {
                ModelState.AddModelError("Notification", "Bạn chưa nhập Password");
            }
            else
            {
                ModelState.AddModelError("Notification", "Đăng nhập thành công");
            }
            return View();
        }

    }
}