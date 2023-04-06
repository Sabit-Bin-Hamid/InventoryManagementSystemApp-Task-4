using IMSDomainLayer.Entiry;
using IMSInterfaceLayer.IService;
using Microsoft.AspNetCore.Mvc;

namespace IMSApp.Controllers
{
    public class LoginController : Controller
    {
        
        private readonly ILoginService _login;

        public LoginController(ILoginService login)
        {
            this._login = login;
        }  

        [HttpGet]

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(RegisterUser user)
        {
            RegisterUser checkEmail = _login.CheckIfExist(user.Email);
            if (checkEmail == null) { return View(user); }

            if (checkEmail.Password == user.Password)
            {
                return RedirectToAction("Index", "AppUser");
            }
            TempData["msg"] = "Email or Password miss match ";
            return View(user);
        }
    }
}
