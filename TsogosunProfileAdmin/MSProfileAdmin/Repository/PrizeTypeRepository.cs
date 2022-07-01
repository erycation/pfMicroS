
using System.Collections.Generic;
using System.Linq;
using tsogosun.com.MSProfileAdmin.Model;
using tsogosun.com.MSProfileAdmin.Repository.Interface;
using tsogosun.com.MSProfileAdmin.Shared;

namespace tsogosun.com.MSProfileAdmin.Repository
{
    public class PrizeTypeRepository : IPrizeTypeRepository
    {

        private readonly ProfileAdminDBContext _dbContext;

        public PrizeTypeRepository(ProfileAdminDBContext context)
        {
            _dbContext = context;
        }
        public List<PrizeType> GetPrizeTypes()
        {

            return _dbContext.PrizeTypes.ToList();

        }
    }
}
