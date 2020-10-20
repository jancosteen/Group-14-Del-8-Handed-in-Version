using Abp.Authorization;
using MDR_Angular.Authorization.Roles;
using MDR_Angular.Authorization.Users;

namespace MDR_Angular.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
