using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Mu_Dot8Identity.Models.Domain;
using Mu_Dot8Identity.Models.DTO;
using Mu_Dot8Identity.Repositories.Abstract;

namespace Mu_Dot8Identity.Repositories.Implementation;

public class UserAuthenticationService(
  SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) : IUserAuthenticationService
{
  private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
  private readonly UserManager<ApplicationUser> _userManager = userManager;
  private readonly RoleManager<IdentityRole> _roleManager = roleManager;

  public async Task<Status> LoginAsync(LoginModel model)
  {
    var status = new Status();

    // TODO: Implement login logic
    // Check if user exists
    // If not, return appropriate status code and message
    // If user exists, check if password is correct
    // If not, return appropriate status code and message
    // If password is correct, return appropriate status code and message

    var user = await _userManager.FindByNameAsync(model.UserName);
    if (user is null)
    {
      status.StatusCode = 0;
      status.Message = "Invalid username";
      return status;
    }

    if (!await _userManager.CheckPasswordAsync(user, model.Password))
    {
      status.StatusCode = 0;
      status.Message = "Invalid password";
      return status;
    }

    var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, true);
    if (result.Succeeded)
    {
      var roles = await _userManager.GetRolesAsync(user);
      var authClaims = new List<Claim>
      {
        new(ClaimTypes.Name, user.Name)
      };

      foreach (var role in roles)
        authClaims.Add(new Claim(ClaimTypes.Role, role));

      status.StatusCode = 1;
      status.Message = "Login successful";
      return status;
    }
    else if (result.IsLockedOut)
    {
      status.StatusCode = 0;
      status.Message = "User is locked out";
      return status;
    }
    else
    {
      status.StatusCode = 0;
      status.Message = "Error on login in";
      return status;
    }
  }

  public async Task LogOutAsync() => await _signInManager.SignOutAsync();

  public async Task<Status> RegistrationAsync(RegistrationModel model)
  {
    var status = new Status();

    // TODO: Implement registration logic
    // Check if user already exists
    // If not, create user and assign role
    // If role does not exist, create role and assign user
    // Return appropriate status code and message
    var userExists = await _userManager.FindByNameAsync(model.UserName);
    if (userExists is not null)
    {
      status.StatusCode = 0;
      status.Message = "User already exists";
      return status;
    }

    var user = new ApplicationUser
    {
      SecurityStamp = Guid.NewGuid().ToString(),
      Name = model.Name,
      Email = model.Email,
      UserName = model.UserName,
      EmailConfirmed = true
    };
    var result = await _userManager.CreateAsync(user, model.Password);
    if (!result.Succeeded)
    {
      status.StatusCode = 0;
      status.Message = "User creation failed";
      return status;
    }

    // role Management
    if (!await _roleManager.RoleExistsAsync(model.Role))
      await _roleManager.CreateAsync(new IdentityRole(model.Role));

    if (await _roleManager.RoleExistsAsync(model.Role))
      await _userManager.AddToRoleAsync(user, model.Role);

    status.StatusCode = 1;
    status.Message = "User created successfully";
    return status;
  }
}