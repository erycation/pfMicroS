
using System.Collections.Generic;

namespace tsogosun.com.MSProfileAdmin.Model.Dtos
{
    public class NavItem
    {
        public string DisplayName { get; set; }
        public bool? Disabled { get; set; }
        public string IconName { get; set; }
        public string Route { get; set; }
        public List<NavItem> Children { get; set; }

    }
}
