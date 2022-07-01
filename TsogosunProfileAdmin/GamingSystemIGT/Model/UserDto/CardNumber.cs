
namespace tsogosun.com.GamingSystemIGT.Model.UserDto
{
    public class CardNumber
    {
        public string CardID { set; get; }
        public string Status { set; get; }
        public string StatusDescription
        {
            get
            {
                return Status == "A" ? "Active" : "Not Active";
            }
        }
    }
}
