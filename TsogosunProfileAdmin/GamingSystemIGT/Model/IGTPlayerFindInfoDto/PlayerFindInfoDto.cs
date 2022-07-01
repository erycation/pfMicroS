
using tsogosun.com.GamingSystemIGT.Model.UserDto;

namespace tsogosun.com.GamingSystemIGT.Model.IGTPlayerFindInfoDto
{
    public class PlayerFindInfoDto : Name
    {
        public string PlayerID { set; get; }
        public string Ranking { set; get; }
        public string SSN { set; get; }
        public string DateOfBirth { set; get; }
        public string CreditAccount { set; get; }

    }
}
