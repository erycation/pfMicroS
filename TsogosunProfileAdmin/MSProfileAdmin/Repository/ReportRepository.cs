

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using tsogosun.com.MSProfileAdmin.Model.Dtos;
using tsogosun.com.MSProfileAdmin.Model.Request;
using tsogosun.com.MSProfileAdmin.Repository.Interface;
using tsogosun.com.MSProfileAdmin.Shared;

namespace tsogosun.com.MSProfileAdmin.Repository
{
    public class ReportRepository : IReportRepository
    {

        private readonly ProfileAdminDBContext _dbContext;

        public ReportRepository(ProfileAdminDBContext context)
        {
            _dbContext = context;
        }

        public List<PatronFreePlayDto> GetPatronFreePlays(RequestPatronFreePlay requestPatronFreePlay)
        {

            return _dbContext.PatronFreePlayDtos.FromSqlRaw("pRPT_PatronFreePlay @startdate, @enddate, @site , @patron",
                                                                       new SqlParameter("@startdate", requestPatronFreePlay.StartDate),
                                                                       new SqlParameter("@enddate", requestPatronFreePlay.EndDate),
                                                                       new SqlParameter("@site", requestPatronFreePlay.SiteId),
                                                                       new SqlParameter("@patron", requestPatronFreePlay.PatronNo)).ToList();

        }

        public List<PatronVoucherDto> GetPatronVouchers(RequestPatronVoucher requestPatronVoucher)
        {

            return _dbContext.PatronVoucherDtos.FromSqlRaw("pRPT_PatronVouchers @startdate, @enddate, @site , @patron",
                                                                       new SqlParameter("@startdate", requestPatronVoucher.StartDate),
                                                                       new SqlParameter("@enddate", requestPatronVoucher.EndDate),
                                                                       new SqlParameter("@site", requestPatronVoucher.SiteId),
                                                                       new SqlParameter("@patron", requestPatronVoucher.PatronNo)).ToList();

        }

        public List<PatronDrawDto> GetPatronDraws(RequestPatronDraw requestPatronDraw)
        {

            return _dbContext.PatronDrawDtos.FromSqlRaw("pRPT_PatronDraws @startdate, @enddate, @site , @patron",
                                                                       new SqlParameter("@startdate", requestPatronDraw.StartDate),
                                                                       new SqlParameter("@enddate", requestPatronDraw.EndDate),
                                                                       new SqlParameter("@site", requestPatronDraw.SiteId),
                                                                       new SqlParameter("@patron", requestPatronDraw.PatronNo)).ToList();

        }

    }
}
