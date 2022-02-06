using MAG.AppCommons;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace MAG.Projekt.Attributes
{
    public class MAGAuthorizeAttribute : AuthorizeAttribute
    {
        public MAGAuthorizeAttribute(params UserRole[] roles)
        {
            if (roles.Any())
            {
                var rolesText = string.Join(",", roles.Select(x => x.ToString()));
                this.Roles = rolesText;
            }
        }
    }
}
