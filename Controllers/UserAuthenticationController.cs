using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mu_Dot8Identity.Models.DTO;
using Mu_Dot8Identity.Repositories.Abstract;

namespace Mu_Dot8Identity.Controllers;

// [Route("UserAuthentication")]
public class UserAuthenticationController(IUserAuthenticationService service) : Controller
{
  private readonly IUserAuthenticationService _service = service;

  public IActionResult Registration() => View();
  [HttpPost]
  public async Task<IActionResult> Registration(RegistrationModel model)
  {
    if (!ModelState.IsValid)
      return View(model);

    model.Role = "User";
    var result = await _service.RegistrationAsync(model);
    if (result.StatusCode == 1)
      return RedirectToAction("Login", "UserAuthentication");
    else
    {
      TempData["msg"] = result.Message;
      return RedirectToAction(nameof(Registration));
    }
  }
  public IActionResult Login() => View();
  [HttpPost]
  public async Task<IActionResult> Login(LoginModel model)
  {
    if (!ModelState.IsValid)
      return View(model);

    var result = await _service.LoginAsync(model);
    if (result.StatusCode == 1)
      return RedirectToAction("Display", "Dashboard");
    else
    {
      TempData["msg"] = result.Message;
      return RedirectToAction(nameof(Login));
    }
  }

  [Authorize]
  public async Task<IActionResult> LogOut()
  {
    await _service.LogOutAsync();
    return RedirectToAction(nameof(Login));
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error() => View("Error!");


  // [HttpGet]
  // public async Task<IActionResult> Reg()
  // {
  //   // Create a new registration model
  //   var model = new RegistrationModel
  //   {
  //     UserName = "Admin",
  //     Name = "Mahmoud",
  //     Email = "Mahmoud@gmail.com",
  //     Password = "M424036m@"
  //   };

  //   // Register the user
  //   model.Role = "Admin";

  //   // Call the registration service to register the user
  //   var result = await _service.RegistrationAsync(model);

  //   // Return the result as JSON
  //   return Ok(result);
  // }
}