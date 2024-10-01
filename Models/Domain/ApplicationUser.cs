using Microsoft.AspNetCore.Identity;

namespace Mu_Dot8Identity.Models.Domain;

public class ApplicationUser : IdentityUser
{
  public string Name { get; set; }
  public string? ProfilePicture { get; set; }
}