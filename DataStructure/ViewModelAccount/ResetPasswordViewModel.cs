using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [DisplayName("Confirm password")]
        [Compare("Password",ErrorMessage ="Password and Confirm Password must match")]
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }

    }
}
