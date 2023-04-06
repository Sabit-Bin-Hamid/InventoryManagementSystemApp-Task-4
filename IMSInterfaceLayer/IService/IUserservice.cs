using IMSDomainLayer.Entiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSInterfaceLayer.IService
{
    public interface IUserservice:IBaseService<AppUser>
    {
        Task<AppUser> CheckIfExist(string Email);
        
    }
}
