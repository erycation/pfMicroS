
using tsogosun.com.MSProfileAdmin.Model;
using tsogosun.com.MSProfileAdmin.Shared.Utils;

namespace tsogosun.com.MSProfileAdmin.Service.Interface
{
    public interface IUserPermissionService
    {
        OutputResults AddUserPermission(UserPermission userPermission);
        OutputResults DeactivateUserPermission(UserPermission userPermission);

    }
}
