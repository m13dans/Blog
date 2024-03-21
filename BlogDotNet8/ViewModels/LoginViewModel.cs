using System.ComponentModel.DataAnnotations;

namespace BlogDotNet8.ViewModels;

public class LoginViewModel
{
    [Required]
    public string? UserName { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}
