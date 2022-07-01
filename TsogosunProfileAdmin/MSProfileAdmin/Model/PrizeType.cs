using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tsogosun.com.MSProfileAdmin.Model
{

    [Table("PrizeType")]
    public class PrizeType
    {
        [Key]
        public short PrizeTypeID { get; set; }
        public string Description { get; set; }
    }
}
