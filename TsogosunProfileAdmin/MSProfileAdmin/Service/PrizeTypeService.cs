

using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model;
using tsogosun.com.MSProfileAdmin.Repository.Interface;
using tsogosun.com.MSProfileAdmin.Service.Interface;

namespace tsogosun.com.MSProfileAdmin.Service
{
    public class PrizeTypeService : IPrizeTypeService
    {

        private readonly IPrizeTypeRepository _prizeTypeRepository;

        public PrizeTypeService(IPrizeTypeRepository prizeTypeRepository)
        {
            _prizeTypeRepository = prizeTypeRepository;
        }

        public List<PrizeType> GetPrizeTypes()
        {
            return _prizeTypeRepository.GetPrizeTypes();
        }
    }
}
