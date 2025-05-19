using System.ComponentModel.DataAnnotations;

namespace Missing_Middle_Student.Model
{
    public class LoginModel
    {

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@tut4life\.ac\.za$", ErrorMessage = "Email must end with @tut4life.ac.za.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; }
    }
}
