using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IMSDomainLayer.Entiry
{
    public class RegisterUser
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(100, ErrorMessage = "First Name must be a maximum length of 100")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(100, ErrorMessage = "Last Name must be a maximum length of 100")]
        public string? LastName { get; set; } = "";

        public string UserName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        //[DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password must be a minimum length of 6 and a maximum length of 20")]
        public string Password { get; set; }



        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

       
    }
}
