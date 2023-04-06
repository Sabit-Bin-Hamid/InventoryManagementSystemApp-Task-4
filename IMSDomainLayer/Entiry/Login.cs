using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IMSDomainLayer.Entiry
{
    public class Login
    {
        public Login() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }    

    }
}
