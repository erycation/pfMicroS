
using tsogosun.com.GamingSystemIGT.Response;

namespace tsogosun.com.GamingSystemIGT.Model.PlayerProfileDto
{
    public class ResponsePlayerProfile : CRMAcresMessage
    {
        public string PlayerID { set; get; }             
        public PlayerProfileBody PlayerProfileBody { set; get; }
 
   }
}
