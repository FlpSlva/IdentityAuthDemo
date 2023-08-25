using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Dtos;

public class UserRegisterDTO
{
    [Required(ErrorMessage = "Field {0} is requerid")]
    [EmailAddress(ErrorMessage = "Field {0} is in an invalid format")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Field {0} is requerid")]
    public string Name { get; set; }
    public Guid Id { get; set; }
}
