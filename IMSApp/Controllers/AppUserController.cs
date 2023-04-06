using IMSDomainLayer.Entiry;
using IMSInterfaceLayer.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;

namespace IMSApp.Controllers
{
    public class AppUserController : Controller
    {
        private readonly IUserservice _user;
        

        public AppUserController(IUserservice user)
        {
            this._user = user;
           
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var user = await _user.GetAll();
                return View(user);
            }catch (Exception ex) { throw ex; }
        }

        [HttpGet]
        public IActionResult Create() 
        {
            
            return View(new AppUser());
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppUser user)
        {
            try
            {
                if(!ModelState.IsValid) { return View(user); }
                AppUser existEmail=await _user.CheckIfExist(user.Email);
                if(existEmail!=null)
                {
                    TempData["msg"]= "User Email is already exist";
                    return View(user);
                }
                await _user.Save(user);
                TempData["msg"] = "Successfully Saved";
                return RedirectToAction("Index");
            }
            catch (Exception ex) { throw ex; } 
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var user =await _user.Get(id);
                return View(user);

            }
            catch (Exception ex) { throw ex; } 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AppUser user)
        {
            try
            {
                if (!ModelState.IsValid) return View(user);
                AppUser existingUser = await _user.Get(user.Id);
                
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Address = user.Address;
                existingUser.Password = existingUser.Password;
                if (user.Password != null)
                {
                    existingUser.Password = user.Password;
                }
                
                existingUser.Phone = user.Phone;
                existingUser.Email = user.Email;
                existingUser.UpdatedDate = DateTime.Now;
                await _user.Update(user);
                TempData["msg"] = "Successfully Updated  ";
                return RedirectToAction("Edit");
            }
            catch (Exception ex) { throw ex; }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await _user.Get(id);
                _user.Remove(user);
                TempData["Message"] = "Successfully Deleted";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
