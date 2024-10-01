using System.ComponentModel.DataAnnotations;

namespace Mu_Dot8Identity.Models.DTO;

public class RegistrationModel
{
  [Required]
  public string Name { get; set; } = null!;
  [Required]
  [EmailAddress]
  public string Email { get; set; } = null!;
  [Required]
  public string UserName { get; set; } = null!;
  [Required]
  [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#$^+=!*()@%&]).{6,}$", ErrorMessage = "Minimum length 6 characters, at least one uppercase letter, one lowercase letter, one number and one special character")]
  public string Password { get; set; } = null!;
  [Required]
  [Compare("Password")]
  public string ConfirmPassword { get; set; } = null!;
  public string? Role { get; set; }
}