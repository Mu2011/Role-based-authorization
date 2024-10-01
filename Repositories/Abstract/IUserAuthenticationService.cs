using Mu_Dot8Identity.Models.DTO;

namespace Mu_Dot8Identity.Repositories.Abstract;

public interface IUserAuthenticationService
{
  Task<Status> LoginAsync(LoginModel model);
  Task<Status> RegistrationAsync(RegistrationModel model);
  Task LogOutAsync();
}