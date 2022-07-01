using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tsogosun.com.MSProfileAdmin.Model
{
    [Table("xUserPermission")]
    public class UserPermission
    {
        [Key]
        public int UserPermissionId { get; set; }
        public int UserID { get; set; }
        public int ApplicationID { get; set; }
        public int ApplicationSectionID { get; set; }
        public int SiteID { get; set; }
        public bool isActive { get; set; }
        public DateTime DateInserted { get; set; } = DateTime.Now;
        public virtual Application Application { get; set; }
        public virtual ApplicationSection ApplicationSection { get; set; }
        public virtual Site Site { get; set; }
        public virtual User User { get; set; }
    }
}
