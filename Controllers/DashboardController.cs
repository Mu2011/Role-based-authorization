using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mu_Dot8Identity.Controllers;

[Route("Dashboard")]
[Authorize]
public class DashboardController : Controller
{
  [HttpGet("Display")]
  public IActionResult Display() => View();

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error() => View("Error!");
}