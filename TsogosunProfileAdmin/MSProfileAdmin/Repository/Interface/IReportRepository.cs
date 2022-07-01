

using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model.Dtos;
using tsogosun.com.MSProfileAdmin.Model.Request;

namespace tsogosun.com.MSProfileAdmin.Repository.Interface
{
    public interface IReportRepository
    {

        List<PatronFreePlayDto> GetPatronFreePlays(RequestPatronFreePlay requestPatronFreePlay);
        List<PatronVoucherDto> GetPatronVouchers(RequestPatronVoucher requestPatronVoucher);
        List<PatronDrawDto> GetPatronDraws(RequestPatronDraw requestPatronDraw);

    }
}
