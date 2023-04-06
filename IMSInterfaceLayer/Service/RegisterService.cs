using IMSDomainLayer.Entiry;
using IMSInterfaceLayer.DataContext;
using IMSInterfaceLayer.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSInterfaceLayer.Service
{
    public class RegisterService : IRegisterService
    {
        private readonly AppDbContext _db;

        public RegisterService(AppDbContext db)
        {
            this._db = db;
        }
        public bool Add(RegisterUser model)
        {
            try
            {
                _db.Register.Add(model);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public RegisterUser CheckIfExist(string Email)
        {
           var user= _db.Register.FirstOrDefault(x => x.Email == Email);
            return user;
        }

        public RegisterUser FindBy(int id)
        {
            return _db.Register.Find(id);
        }

       
    }
}
