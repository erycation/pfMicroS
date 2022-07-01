using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tsogosun.com.MSProfileAdmin.Model
{
    [Table("lSite")]
    public class Site
    {
        public Site()
        {
            this.UserPermissions = new HashSet<UserPermission>();
            //this.Users = new HashSet<User>();
        }
        [Key]
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public string SiteFullName { get; set; }
        public bool isActive { get; set; }
        public virtual ICollection<UserPermission> UserPermissions { get; set; }
       // public virtual ICollection<User> Users { get; set; }
        [NotMapped]
        public string Status
        {
            get
            { return isActive == true ? "Active" : "Not Active"; }
        }
    }
}
