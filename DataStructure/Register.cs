using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Register
    {
        public int Id { get; set; }

        [Required, MaxLength(10)]
        public string UserName { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required, Display(Name = "Confirm Password"), Compare("Password", ErrorMessage = "Password did not match.")]
        public string? Confirmpassword { get; set; }
    }
}
