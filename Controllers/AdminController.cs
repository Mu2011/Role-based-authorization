using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mu_Dot8Identity.Controllers;

[Authorize(Roles = "Admin")]
// [Route("Admin")]
public class AdminController : Controller
{
  public IActionResult Display() => View();

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error() => View("Error!");
}