using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tsogosun.com.MSProfileAdmin.Model
{

    [Table("lConnection")]
    public class Connection
    {
        public Connection()
        {
            this.Applications = new HashSet<Application>();
        }
        [Key]
        public int ConnectionID { get; set; }
        public string ConnectionName { get; set; }
        public string DataSource { get; set; }
        public string InitialCatalog { get; set; }
        public string DBUserID { get; set; }
        public string Password { get; set; }
        public bool isActive { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
        [NotMapped]
        public string Status
        {
            get
            { return isActive == true ? "Active" : "Not Active"; }
        }
    }
}
