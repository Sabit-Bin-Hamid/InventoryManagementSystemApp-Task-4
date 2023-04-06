using IMSDomainLayer.Entiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSInterfaceLayer.IService
{
    public interface IRegisterService
    {
        bool Add(RegisterUser model);
        RegisterUser CheckIfExist(string Email);
        RegisterUser FindBy(int id);
    }
}
