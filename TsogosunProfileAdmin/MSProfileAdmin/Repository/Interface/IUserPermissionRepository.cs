

using tsogosun.com.MSProfileAdmin.Model;

namespace tsogosun.com.MSProfileAdmin.Repository.Interface
{
    public interface IUserPermissionRepository
    {
        UserPermission GetUserPermissionByUserApplicationSectionId(int userId, int siteId, int applicationId, int sectionId);
        void AddUserPermission(UserPermission userPermission);
        void UpdateUserPermission(UserPermission userPermission);
        void Save();

    }
}
