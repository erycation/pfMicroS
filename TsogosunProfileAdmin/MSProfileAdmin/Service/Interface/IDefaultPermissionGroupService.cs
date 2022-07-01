
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model;
using tsogosun.com.MSProfileAdmin.Model.Dtos;

namespace tsogosun.com.MSProfileAdmin.Service.Interface
{
    public interface IDefaultPermissionGroupService
    {

        List<DefaultPermissionGroup> GetAllDefaultPermissionGroups();
        List<DefaultPermissionGroup> GetActiveDefaultPermissionGroups(int siteId);
        void AddDefaultPermissionGroup(int userID, int defaultGroupID);

    }
}
