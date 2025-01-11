
namespace AppMovilProyecto1.GoogleAuth
{
    public interface IGoogleAuthService
    {
        Task<GoogleUserDTO> AuthenticateAsync();

        Task<GoogleUserDTO> GetCurrentUserAsync();

        Task LogoutAsync();
    }
}
