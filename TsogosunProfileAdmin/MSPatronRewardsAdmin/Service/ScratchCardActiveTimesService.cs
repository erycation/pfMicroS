using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Model.Request;
using MSPatronRewardsAdmin.Repository.Interface;
using MSPatronRewardsAdmin.Service.Interface;
using MSPatronRewardsAdmin.Shared.Helpers;
using MSPatronRewardsAdmin.Shared.Utils;
using System;
using System.Collections.Generic;

namespace MSPatronRewardsAdmin.Service
{
   
    public class ScratchCardActiveTimesService : IScratchCardActiveTimesService
    {

        private readonly IScratchCardActiveTimesRepository _scratchCardActiveTimesRepository;

        public ScratchCardActiveTimesService(IScratchCardActiveTimesRepository scratchCardActiveTimesRepository)
        {
            _scratchCardActiveTimesRepository = scratchCardActiveTimesRepository;
        }

        public List<ScratchCardActiveTimesDto> GetScratchCardActiveTimesBySiteId(int siteId, Guid scratchCardUID)
        {
            return _scratchCardActiveTimesRepository.GetScratchCardActiveTimesBySiteId(siteId, scratchCardUID);
        }

        public ReturnResult AddScratchCardActiveTimes(RequestAddUpdateScratchCardActiveTime requestAddUpdateScratchCardActiveTime, int siteId)
        {

            var scratchCardActiveTimesDto = requestAddUpdateScratchCardActiveTime.ScratchCardActiveTimesDto;

            var startDateTime = FormatDateTime(scratchCardActiveTimesDto.StartDateTime, requestAddUpdateScratchCardActiveTime.StartTime);
            var endDateTime = FormatDateTime(scratchCardActiveTimesDto.EndDateTime, requestAddUpdateScratchCardActiveTime.EndTime);

            var requestScratchCardActiveTimesDto = new ScratchCardActiveTimesDto
            {
                ScratchCardReleaseID = 0,
                ScratchCardUID = scratchCardActiveTimesDto.ScratchCardUID,
                StartDateTime = startDateTime,
                EndDateTime = endDateTime
            };

            var responseScratchCardActiveTimes = _scratchCardActiveTimesRepository.AddOrUpdateScratchCardActiveTimes(siteId, requestScratchCardActiveTimesDto, 'A');
            if (responseScratchCardActiveTimes.ReturnCode != 0)
                throw new AppException(responseScratchCardActiveTimes.ReturnMessage);
            return responseScratchCardActiveTimes;
        }

        public ReturnResult UpdateScratchCardActiveTimes(RequestAddUpdateScratchCardActiveTime requestAddUpdateScratchCardActiveTime, int siteId)
        {

            var scratchCardActiveTimesDto = requestAddUpdateScratchCardActiveTime.ScratchCardActiveTimesDto;

            var startDateTime = FormatDateTime(scratchCardActiveTimesDto.StartDateTime, requestAddUpdateScratchCardActiveTime.StartTime);
            var endDateTime = FormatDateTime(scratchCardActiveTimesDto.EndDateTime, requestAddUpdateScratchCardActiveTime.EndTime);

            var requestScratchCardActiveTimesDto = new ScratchCardActiveTimesDto
            {
                ScratchCardReleaseID = scratchCardActiveTimesDto.ScratchCardReleaseID,
                ScratchCardUID = scratchCardActiveTimesDto.ScratchCardUID,
                StartDateTime = startDateTime,
                EndDateTime = endDateTime,
                isActive = scratchCardActiveTimesDto.isActive
            };

            var responseScratchCardActiveTimes = _scratchCardActiveTimesRepository.AddOrUpdateScratchCardActiveTimes(siteId, requestScratchCardActiveTimesDto, 'U');
            if (responseScratchCardActiveTimes.ReturnCode != 0)
                throw new AppException(responseScratchCardActiveTimes.ReturnMessage);
            return responseScratchCardActiveTimes;
        }

        #region privatemethods
        private DateTime FormatDateTime(DateTime dateTime, string time)
        {
            TimeSpan timeDay = Convert.ToDateTime(time).TimeOfDay;
            return dateTime.Add(timeDay);
        }
        #endregion
    }
}
