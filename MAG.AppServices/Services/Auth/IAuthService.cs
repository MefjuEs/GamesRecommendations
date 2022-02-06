using System.Threading.Tasks;

namespace MAG.AppServices
{
    public interface IAuthService
    {
        Task<RegisterResultDTO> Register(RegisterDTO registerDTO);
        Task<LogInResultDTO> LogIn(LogInDTO loginDTO);
        Task LogOut();
    }
}
