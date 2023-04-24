using System.ComponentModel.DataAnnotations;

namespace DataStructure
{
    public class LoginInfo
    {
        public int Id { get; set; }
        [Required]
        public string? Username { get; set; }
       // [DataType(DataType.EmailAddress)]
       // public string? Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
