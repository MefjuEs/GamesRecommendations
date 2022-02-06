using System.Collections.Generic;

namespace MAG.AppServices
{
    public class UserRoleListWithFiltersDTO : BaseReturnedListWithFilters
    {
        public List<UserInListDTO> RoleList { get; set; }
    }
}
