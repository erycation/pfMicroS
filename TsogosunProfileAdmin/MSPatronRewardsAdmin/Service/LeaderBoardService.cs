

using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Model.Request;
using MSPatronRewardsAdmin.Model.Response;
using MSPatronRewardsAdmin.Repository.Interface;
using MSPatronRewardsAdmin.Service.Interface;
using MSPatronRewardsAdmin.Shared.Helpers;
using MSPatronRewardsAdmin.Shared.Utils;
using System;
using System.Collections.Generic;

namespace MSPatronRewardsAdmin.Service
{
    public class LeaderBoardService : ILeaderBoardService
    {

        private readonly ILeaderBoardRepository _leaderBoardRepository;
        private readonly IMobileSettingService _mobileSettingService;
        private readonly IGamingAreaService _gamingAreaService;
        public LeaderBoardService(ILeaderBoardRepository leaderBoardRepository,
                                  IMobileSettingService mobileSettingService,
                                  IGamingAreaService gamingAreaService)
        {

            _leaderBoardRepository = leaderBoardRepository;
            _mobileSettingService = mobileSettingService;
            _gamingAreaService = gamingAreaService;

        }

        public InsertPromotionResponse AddLeaderBoard(RequestAddUpdateLeaderBoard requestAddUpdateLeaderBoard)
        {

            var leaderBoardPromotionDto = requestAddUpdateLeaderBoard.LeaderBoardPromotionDto;

            var startDateTime = FormatDateTime(leaderBoardPromotionDto.StartDate, requestAddUpdateLeaderBoard.StartTime);
            var endDateTime = FormatDateTime(leaderBoardPromotionDto.EndDate, requestAddUpdateLeaderBoard.EndTime);

            var requestLeaderboard = new LeaderBoardPromotionDto
            {
                PromotionUID = Guid.NewGuid(),
                PromotionName = leaderBoardPromotionDto.PromotionName,
                PromotionType = leaderBoardPromotionDto.PromotionType,
                StartDate = startDateTime,
                EndDate = endDateTime,
                StartRank = leaderBoardPromotionDto.StartRank,
                EndRank = leaderBoardPromotionDto.EndRank,
                MinPoints = leaderBoardPromotionDto.MinPoints,
                MaxPoints = leaderBoardPromotionDto.MaxPoints,
                NoPatrons = leaderBoardPromotionDto.NoPatrons,
                DisplayOnMobile = leaderBoardPromotionDto.DisplayOnMobile,
                SiteId = leaderBoardPromotionDto.SiteId
            };

            var responseLeaderboard = _leaderBoardRepository.AddLeaderBoardPromotion(requestLeaderboard);
            if(responseLeaderboard.ReturnCode == 1)
                throw new AppException(responseLeaderboard.ReturnMessage);

            //Arreas if site is not Head office
            if (leaderBoardPromotionDto.SiteId > 0)
            {
                if (leaderBoardPromotionDto.GamingAreaDtos.IsCollectionValid())
                {
                    foreach (var area in leaderBoardPromotionDto.GamingAreaDtos)
                    {
                        var responseGamingAreas = _gamingAreaService.AddAreasForPromo(leaderBoardPromotionDto.SiteId, responseLeaderboard.PromotionID, area.Location);
                        if (responseGamingAreas.ReturnCode == 1)
                            throw new AppException($"Partially Created, {responseGamingAreas.ReturnMessage}");
                       
                    }
                }
            }

            if (leaderBoardPromotionDto.DisplayOnMobile)
            {
                var requestMobile = new MobileSettingDto
                {
                    PromotionID = responseLeaderboard.PromotionID,
                    MainImage = leaderBoardPromotionDto.MobileSettingDto.MainImage,
                    MainHeading = leaderBoardPromotionDto.MobileSettingDto.MainHeading
                };

                var responseMobile = _mobileSettingService.AddOrUpdateMobileSettings(leaderBoardPromotionDto.SiteId, requestMobile);
                if (responseMobile.ReturnCode == 1)
                    throw new AppException($"Partially Created Mobile, {responseMobile.ReturnMessage}");
            }

            return responseLeaderboard;
        }

        public ReturnResult UpdateLeaderBoard(RequestAddUpdateLeaderBoard requestAddUpdateLeaderBoard)
        {

            var leaderBoardPromotion = requestAddUpdateLeaderBoard.LeaderBoardPromotionDto;

            var startDateTime = FormatDateTime(leaderBoardPromotion.StartDate, requestAddUpdateLeaderBoard.StartTime);
            var endDateTime = FormatDateTime(leaderBoardPromotion.EndDate, requestAddUpdateLeaderBoard.EndTime);

            var requestUpdateLeaderboard = new LeaderBoardPromotionDto
            {
                PromotionID = leaderBoardPromotion.PromotionID,
                PromotionUID = leaderBoardPromotion.PromotionUID,
                PromotionName = leaderBoardPromotion.PromotionName,
                PromotionType = leaderBoardPromotion.PromotionType,
                StartDate = startDateTime,
                EndDate = endDateTime,
                StartRank = leaderBoardPromotion.StartRank,
                EndRank = leaderBoardPromotion.EndRank,
                MinPoints = leaderBoardPromotion.MinPoints,
                MaxPoints = leaderBoardPromotion.MaxPoints,
                NoPatrons = leaderBoardPromotion.NoPatrons,
                DisplayOnMobile = leaderBoardPromotion.DisplayOnMobile,
                SiteId = leaderBoardPromotion.SiteId
            };

            var responseUpdateLeaderboard = _leaderBoardRepository.UpdateLeaderBoardPromotion(requestUpdateLeaderboard);
            if (responseUpdateLeaderboard.ReturnCode == 1)
                throw new AppException(responseUpdateLeaderboard.ReturnMessage);

            //Arreas if site is not Head office
            if (leaderBoardPromotion.SiteId > 0)
            {

                var unlinkArraesResponse = _gamingAreaService.UnlinkAreasForPromo(leaderBoardPromotion.SiteId, leaderBoardPromotion.PromotionID);
                if (unlinkArraesResponse.ReturnCode == 1)
                    throw new AppException($"Partially Update, Unlink Areas {unlinkArraesResponse.ReturnMessage}");

                if (leaderBoardPromotion.GamingAreaDtos.IsCollectionValid())
                {
                    foreach (var area in leaderBoardPromotion.GamingAreaDtos)
                    {
                        var responseGamingAreas = _gamingAreaService.AddAreasForPromo(leaderBoardPromotion.SiteId, leaderBoardPromotion.PromotionID, area.Location);
                        if (responseGamingAreas.ReturnCode == 1)
                            throw new AppException($"New Gaming Areas, {responseGamingAreas.ReturnMessage}");

                    }
                }
            }

            if (leaderBoardPromotion.DisplayOnMobile)
            {
                var requestMobile = new MobileSettingDto
                {
                    PromotionID = leaderBoardPromotion.PromotionID,
                    MainImage = leaderBoardPromotion.MobileSettingDto.MainImage,
                    MainHeading = leaderBoardPromotion.MobileSettingDto.MainHeading
                };

                var responseMobile = _mobileSettingService.AddOrUpdateMobileSettings(leaderBoardPromotion.SiteId, requestMobile);
                if (responseMobile.ReturnCode == 1)
                    throw new AppException($"Partially Created Mobile, {responseMobile.ReturnMessage}");
            }

            return responseUpdateLeaderboard;
        }

        public List<LeaderBoardPromotionDto> GetLeaderBoardPromotionsBySiteId(int siteId, RequestLeaderBoard requestLeaderBoard)
        {
            requestLeaderBoard.StartDate  = DateUtil.StartOfDay(requestLeaderBoard.StartDate);
            requestLeaderBoard.EndDate = DateUtil.EndOfDay(requestLeaderBoard.EndDate);
            return _leaderBoardRepository.GetLeaderBoardPromotionsBySiteId(siteId, requestLeaderBoard);

        }

        public LeaderBoardPromotionDto GetLeaderBoardByPromotionId(int siteId, int promotionId)
        {
            var leaderBoardPromotionDto = new LeaderBoardPromotionDto();
            var leaderBoardGamingArreas = new List<GamingAreaDto>();

            leaderBoardPromotionDto = _leaderBoardRepository.GetLeaderBoardByPromotionId(siteId, promotionId);
            
            if (siteId > 0)
            {
                var promotionGamingArreas = _gamingAreaService.GetGamingAreaByPromotionId(siteId, promotionId);

                if (promotionGamingArreas.IsCollectionValid())
                {
                    foreach (var area in promotionGamingArreas)
                    {
                        leaderBoardGamingArreas.Add(new GamingAreaDto { Location = area.Location });
                    }
                }

                leaderBoardPromotionDto.GamingAreaDtos = promotionGamingArreas;
            }
            if (leaderBoardPromotionDto.DisplayOnMobile)
            {
                var mobileSettings = _mobileSettingService.GetMobileSettingDtoByPromotionId(siteId, promotionId);
                
                if(mobileSettings != null)
                {
                    leaderBoardPromotionDto.MobileSettingDto = mobileSettings;
                }

            }

            return leaderBoardPromotionDto;
        }

        public List<LeaderBoardPatronDto> GetLeaderBoardByPatronNumber(int siteId, long patronNo)
        {
            return _leaderBoardRepository.GetLeaderBoardByPatronNumber(siteId, patronNo);
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
