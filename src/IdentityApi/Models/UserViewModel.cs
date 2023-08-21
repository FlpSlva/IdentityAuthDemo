using System.ComponentModel.DataAnnotations;

namespace IdentityApi.Models;

public class UserRegister
{
    [Required(ErrorMessage = "Field {0} is requerid")]
    [EmailAddress(ErrorMessage = "Field {0} is in an invalid format")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Field {0} is requerid")]
    [StringLength(100, ErrorMessage = "Field {0} must be between {2} and {1} characters", MinimumLength = 6)]
    public string Password { get; set; }

    [Compare("Password", ErrorMessage = "Passwords don't match.")]
    public string ConfirmPassword { get; set; }
}

public class UserLogin
{
    [Required(ErrorMessage = "Field {0} is requerid")]
    [EmailAddress(ErrorMessage = "Field {0} is in invalid format")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Field {0} is requerid")]
    [StringLength(100, ErrorMessage = "Field {0} must be between {2} and {1} characters", MinimumLength = 6)]
    public string Password { get; set; }
}
