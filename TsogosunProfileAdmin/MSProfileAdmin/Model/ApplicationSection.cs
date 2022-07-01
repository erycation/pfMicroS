
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tsogosun.com.MSProfileAdmin.Model
{

    [Table("lApplicationSection")]
    public class ApplicationSection
    {
        public ApplicationSection()
        {
            this.UserPermissions = new HashSet<UserPermission>();
        }
        [Key]
        public int SectionID { get; set; }
        public int ApplicationID { get; set; }
        public string SectionName { get; set; }
        public string WebsiteSectionRoute { get; set; }
        public bool isMenuItem { get; set; }
        public bool isActive { get; set; }
        public string ReferenceName { get; set; }
        public virtual Application Application { get; set; }
        public virtual ICollection<UserPermission> UserPermissions { get; set; }

        [NotMapped]
        public string Status
        {
            get
            { return isActive == true ? "Active" : "Not Active"; }
        }
    }
}
