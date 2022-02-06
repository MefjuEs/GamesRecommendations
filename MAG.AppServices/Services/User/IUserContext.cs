using MAG.AppCommons;

namespace MAG.AppServices
{
    public interface IUserContext
    {
        long? UserAccountId { get; }
        bool IsAuthenticated { get; }
        bool IsInRole(UserRole role);
    }
}
