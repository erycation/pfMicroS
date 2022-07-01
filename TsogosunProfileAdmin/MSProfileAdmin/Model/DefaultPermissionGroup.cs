using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tsogosun.com.MSProfileAdmin.Model
{
    [Table("mDefaultPermissionGroups")]
    public class DefaultPermissionGroup
    {
        [Key]
        public int PermissionGroupID { get; set; }
        public string PermissionGroupDesc { get; set; }
        public int SiteID { get; set; }
        public bool? Active { get; set; }
    }
}
