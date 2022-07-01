

using tsogosun.com.GamingSystemIGT.Shared.Utils;

namespace tsogosun.com.GamingSystemIGT.Model.IGTCountryInfoDto.Request
{
    public class RequestIGTCountryInfo : InterfaceParameter
    {
        public string ConditionClause { set; get; }
        public string ConditionValue { set; get; }

    }
}
