using Oasis_task.Model;

namespace Oasis_task.Services
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> LoginAsync(LoginModel model);
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);
        //Task<string> AddRoleAsync(AddRoleModel model);
    }
}
