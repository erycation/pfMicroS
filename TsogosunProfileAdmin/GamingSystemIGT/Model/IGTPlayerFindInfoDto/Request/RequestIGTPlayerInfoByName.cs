
using tsogosun.com.GamingSystemIGT.Shared.Utils;

namespace tsogosun.com.GamingSystemIGT.Model.IGTPlayerFindInfoDto.Request
{
    public class RequestIGTPlayerInfoByName : InterfaceParameter
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
    }
}
