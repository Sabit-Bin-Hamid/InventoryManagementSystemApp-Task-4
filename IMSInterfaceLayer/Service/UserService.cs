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
    public class UserService : BaseService<AppUser>, IUserservice
    {
        private readonly AppDbContext db;

        public UserService(AppDbContext db) : base(db)
        {
            this.db = db;
        }

        public async Task<AppUser> CheckIfExist(string Email)
        {
            var user=await db.AppUsers.FirstOrDefaultAsync(i => i.Email == Email);
            return user;
        }

        
    }
}
