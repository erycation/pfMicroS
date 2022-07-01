

using tsogosun.com.GamingSystemIGT.Service.Interface;
using tsogosun.com.GamingSystemIGT.Shared;

namespace tsogosun.com.GamingSystemIGT.Service
{
    public class PlayerInterestService : IPlayerInterestService
    {

        private IADISoapServiceIGT _aDISoapServiceIGT;

        public PlayerInterestService(IADISoapServiceIGT aDISoapServiceIGT)
        {

            _aDISoapServiceIGT = aDISoapServiceIGT;

        }

    }
}
