using IMSDomainLayer.Entiry;
using IMSInterfaceLayer.IService;
using Microsoft.AspNetCore.Mvc;

namespace IMSApp.Controllers.User
{
    public class RegisterController : Controller
    {
        private readonly IRegisterService user;

        public RegisterController(IRegisterService user)
        {
            this.user = user;
        }
        public IActionResult RegisterIndex()
        {
            return View(new RegisterUser());
        }

        [HttpPost]
        public IActionResult RegisterIndex(RegisterUser model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            RegisterUser existEmail = user.CheckIfExist(model.Email);
            if (existEmail != null)
            {
                TempData["msg"] = "User Email is already exist";
                return View(model);
               
            }
            var result = user.Add(model);
            if (result)
            {
                TempData["msg"] = "User Registerd Done";
                return RedirectToAction("RegisterIndex");
            }
            TempData["msg"] = "Server Side Problem";
            return View(model);
        }
    }
}
