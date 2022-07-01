
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tsogosun.com.MSProfileAdmin.Model
{

    [Table("lApplication")]
    public class Application
    {
        public Application()
        {
            this.ApplicationSections = new HashSet<ApplicationSection>();
            this.UserPermissions = new HashSet<UserPermission>();
            this.Connections = new HashSet<Connection>();
        }
        [Key]
        public int ApplicationID { get; set; }
        public string ApplicationName { get; set; }
        public bool IsMenuItem { get; set; }
        public string WebsiteRoute { get; set; }
        public bool isActive { get; set; } = true;
        public virtual ICollection<ApplicationSection> ApplicationSections { get; set; }
        public virtual ICollection<UserPermission> UserPermissions { get; set; }
        public virtual ICollection<Connection> Connections { get; set; }
        [NotMapped]
        public string Status
        {
            get
            { return isActive == true ? "Active" : "Not Active"; }
        }
    }
}
