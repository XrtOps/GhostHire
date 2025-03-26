using System.ComponentModel.DataAnnotations;

namespace GhostHire.Models
{
    public class Authentication
    {
        [Key]
        public int AuthenticationID { get; set; }
        [Required(ErrorMessage = "Username is Required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Must match with the password")]
        public string PasswordConfirmation { get; set; }
    }
}
