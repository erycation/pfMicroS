
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model;

namespace tsogosun.com.MSProfileAdmin.Repository.Interface
{
    public interface IDefaultPermissionGroupRepository
    {
        List<DefaultPermissionGroup> GetDefaultPermissionGroups();
        void AddDefaultPermissionGroup(int userID, int defaultGroupID);
    }
}
