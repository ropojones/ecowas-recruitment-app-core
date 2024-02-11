using Abp.Authorization;
using EcoRecruit.Authorization.Roles;
using EcoRecruit.Authorization.Users;

namespace EcoRecruit.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
