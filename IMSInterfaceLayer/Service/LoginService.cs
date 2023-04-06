using IMSDomainLayer.Entiry;
using IMSInterfaceLayer.DataContext;
using IMSInterfaceLayer.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSInterfaceLayer.Service
{
    public class LoginService : BaseService<RegisterUser>, ILoginService
    {
        private readonly AppDbContext db;

        public LoginService(AppDbContext db) : base(db)
        {
            this.db = db;
        }

        public RegisterUser CheckIfExist(string Email)
        {
            var user = db.Register.FirstOrDefault(x => x.Email == Email);
            return user;
        }

        
    }
}
