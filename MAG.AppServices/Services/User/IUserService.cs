using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MAG.AppServices
{
    public interface IUserService
    {
        Task<string> GetUsername(long id);
        Task<UserDTO> GetUser(long id);
        Task<List<IdentityRole<long>>> GetRoles();
        Task<UsernameRoleDTO> GetUsernameRole(long id);
        Task<UserRoleListWithFiltersDTO> GetUsersWithRoles(UserFiltersDTO userFilters);
        List<UserInSelectDTO> GetUsersToSelect(SelectUserFiltersDTO filters);
        Task<bool> DoesUserExist(long id);
        Task ChangeUserRole(long userId, string role);
        Task<bool> DeleteUser(long id);
    }
}
