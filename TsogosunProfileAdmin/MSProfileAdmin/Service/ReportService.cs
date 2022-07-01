

using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model.Dtos;
using tsogosun.com.MSProfileAdmin.Model.Request;
using tsogosun.com.MSProfileAdmin.Repository.Interface;
using tsogosun.com.MSProfileAdmin.Service.Interface;
using tsogosun.com.MSProfileAdmin.Shared.Utils;

namespace tsogosun.com.MSProfileAdmin.Service
{
    public class ReportService : IReportService
    {

        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public List<PatronFreePlayDto> GetPatronFreePlays(RequestPatronFreePlay requestPatronFreePlay)
        {
            requestPatronFreePlay.StartDate = DateUtil.StartOfDay(requestPatronFreePlay.StartDate);
            requestPatronFreePlay.EndDate = DateUtil.EndOfDay(requestPatronFreePlay.EndDate);
            return _reportRepository.GetPatronFreePlays(requestPatronFreePlay);
        }

        public List<PatronVoucherDto> GetPatronVouchers(RequestPatronVoucher requestPatronVoucher)
        {
            requestPatronVoucher.StartDate = DateUtil.StartOfDay(requestPatronVoucher.StartDate);
            requestPatronVoucher.EndDate = DateUtil.EndOfDay(requestPatronVoucher.EndDate);
            return _reportRepository.GetPatronVouchers(requestPatronVoucher);
        }

        public List<PatronDrawDto> GetPatronDraws(RequestPatronDraw requestPatronDraw)
        {
            requestPatronDraw.StartDate = DateUtil.StartOfDay(requestPatronDraw.StartDate);
            requestPatronDraw.EndDate = DateUtil.EndOfDay(requestPatronDraw.EndDate);
            return _reportRepository.GetPatronDraws(requestPatronDraw);
        }
    }
}
