
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using tsogosun.com.MSProfileAdmin.Model;
using tsogosun.com.MSProfileAdmin.Model.Dtos;
using tsogosun.com.MSProfileAdmin.Model.Request;
using tsogosun.com.MSProfileAdmin.Service.Interface;
using tsogosun.com.MSProfileAdmin.Shared.Enum;
using tsogosun.com.MSProfileAdmin.Shared.Utils;

namespace tsogosun.com.MSProfileAdmin.Service
{
    public class ActiveDirectoryAuthService : IActiveDirectoryAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly IAuthManager _authManager;
        private readonly IPrizeTypeService _prizeTypeService;
        private readonly IOptions<DomainConfig> _logging;
        private readonly IConfiguration _configuration;
        public ActiveDirectoryAuthService(IHttpContextAccessor httpContextAccessor,
                                           IUserService userService,
                                           IAuthManager authManager,
                                           IPrizeTypeService prizeTypeService,
                                           IOptions<DomainConfig> logging,
                                           IConfiguration configuration)
        {

            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            _authManager = authManager;
            _prizeTypeService = prizeTypeService;
            _logging = logging;
            _configuration = configuration;

        }

        public AuthToken Login(Credentials credentials)
        {

            var authToken = new AuthToken();
            var applications = new List<ApplicationDto>();

            /**
             * 
             * Commented to ByPass Login
             * 
            
             
            var configuredDomains = _logging.Value.Domains;

            var context = new PrincipalContext(ContextType.Domain, configuredDomains[0], credentials.Username, credentials.Password);

            bool authenticated = context.ValidateCredentials(credentials.Username, credentials.Password);

            if (!authenticated)
                return new AuthToken { Message = "Invalid Credentials." };  
             * */

            var userToken = _userService.GetDetailsByUsername(credentials.Username);

            if (userToken[0].ReturnCode == 0)
            {
                foreach (var token in userToken)
                {
                    if (!applications.Exists(a => a.ApplicationName == token.ApplicationName))
                    {
                        var sectionItems = userToken.Where(a => a.ApplicationName == token.ApplicationName);

                        var sections = new List<SectionDto>();

                        foreach (var section in sectionItems)
                        {
                            if (!sections.Exists(s => s.SectionName == section.SectionName))
                            {

                                var sites = new List<SiteDto>();

                                var siteItem = userToken.Where(a => a.SectionName == section.SectionName);

                                foreach (var site in siteItem)
                                {
                                    sites.Add(new SiteDto { SiteID = site.SiteID, SiteName = site.SiteName, SiteFullName = site.SiteFullName });
                                }

                                sections.Add(new SectionDto { SectionId = section.SectionID, SectionName = section.SectionName, IsSectionMenuItem = section.IsSectionMenuItem, WebsiteSectionRoute = section.WebsiteSectionRoute, SectionIconName = section.SectionIconName, Sites = sites });

                            }
                        }

                        applications.Add(new ApplicationDto { ApplicationId = token.ApplicationID, ApplicationName = token.ApplicationName, IsApplicationMenuItem = token.IsApplicationMenuItem, WebsiteRoute = token.WebsiteRoute, IconName = token.IconName, Sections = sections });
                    }
                }

                authToken.CanViewPersonalDetails = userToken.Where(s => s.ReferenceName.ToLower() == UserRightsSectionEnum.PersonalDetails.ToString().ToLower()).FirstOrDefault() == null ? false : true;
                authToken.CanUpdatePatron = userToken.Where(s => s.ReferenceName.ToLower() == UserRightsSectionEnum.UpdatePatron.ToString().ToLower()).FirstOrDefault() == null ? false : true;
                authToken.CanViewGamingPoints = userToken.Where(s => s.ReferenceName.ToLower() == UserRightsSectionEnum.GamingDetails.ToString().ToLower()).FirstOrDefault() == null ? false : true;
                authToken.CanViewKPI = userToken.Where(s => s.ReferenceName.ToLower() == UserRightsSectionEnum.KPI.ToString().ToLower()).FirstOrDefault() == null ? false : true;
                authToken.CanViewOffers = userToken.Where(s => s.ReferenceName.ToLower() == UserRightsSectionEnum.Offers.ToString().ToLower()).FirstOrDefault() == null ? false : true;
                authToken.CanViewVIP = userToken.Where(s => s.ReferenceName.ToLower() == UserRightsSectionEnum.VIP.ToString().ToLower()).FirstOrDefault() == null ? false : true;
                authToken.CanViewPatronDetailsScratchCard = userToken.Where(s => s.ReferenceName.ToLower() == UserRightsSectionEnum.PatronDetailsScratchCard.ToString().ToLower()).FirstOrDefault() == null ? false : true;                
                authToken.CanViewPatronLeaderBoard = userToken.Where(s => s.ReferenceName.ToLower() == UserRightsSectionEnum.PatronLeaderBoard.ToString().ToLower()).FirstOrDefault() == null ? false : true;
                authToken.CanAddEditLeaderBoard = userToken.Where(s => s.ReferenceName.ToLower() == UserRightsSectionEnum.AddEditLeaderBoard.ToString().ToLower()).FirstOrDefault() == null ? false : true;  
                authToken.CanViewPatronScratchCard = userToken.Where(s => s.ReferenceName.ToLower() == UserRightsSectionEnum.PatronScratchCard.ToString().ToLower()).FirstOrDefault() == null ? false : true;
                authToken.CanViewScratchCardWinners = userToken.Where(s => s.ReferenceName.ToLower() == UserRightsSectionEnum.ScratchCardWinners.ToString().ToLower()).FirstOrDefault() == null ? false : true;
                authToken.CanAddEditScratchCard = userToken.Where(s => s.ReferenceName.ToLower() == UserRightsSectionEnum.AddEditScratchCard.ToString().ToLower()).FirstOrDefault() == null ? false : true;
                authToken.CanViewScratchCardOverview = userToken.Where(s => s.ReferenceName.ToLower() == UserRightsSectionEnum.ScratchCardOverview.ToString().ToLower()).FirstOrDefault() == null ? false : true;
                authToken.CanViewAuditLogs = userToken.Where(s => s.ReferenceName.ToLower() == UserRightsSectionEnum.AuditLogs.ToString().ToLower()).FirstOrDefault() == null ? false : true;

                authToken.Token = _authManager.Authenticate(credentials.Username);
            }

            authToken.Success = userToken[0].ReturnCode == 0 ? true : false;
            authToken.UserId = userToken[0].UserID;
            authToken.UserSessionId = userToken[0].UserSessionID;
            authToken.Username = userToken[0].Username;
            authToken.Applications = applications;
            authToken.StatusItems = GetStatus();
            authToken.NavItems = GetMenuFromApplication(applications);
            authToken.PrizeTypes = _prizeTypeService.GetPrizeTypes();
            authToken.Ranks = GetRanks();
            authToken.PointsTypes = GetPointsTypes();
            authToken.Genders = GetGenders();
            authToken.Message = userToken[0].RetunMessage;

            return authToken;

        }

        private List<NavItem> GetMenuFromApplication(List<ApplicationDto> applicationDtos)
        {

            var navItems = new List<NavItem>();

            if (applicationDtos.IsCollectionValid())
            {

                foreach (var application in applicationDtos)
                {
                    if (application.IsApplicationMenuItem)
                    {
                        navItems.Add(new NavItem { DisplayName = application.ApplicationName, Route = application.WebsiteRoute, Disabled = false, IconName = application.IconName });

                    }
                    else
                    {
                        var sections = new List<NavItem>();

                        if (application.Sections.IsCollectionValid())
                        {
                            foreach (var section in application.Sections)
                            {
                                if(section.IsSectionMenuItem)
                                    sections.Add(new NavItem { DisplayName = section.SectionName, Route = section.WebsiteSectionRoute, Disabled = false, IconName = section.SectionIconName });
                            }
                        }

                        navItems.Add(new NavItem { DisplayName = application.ApplicationName, Route = application.WebsiteRoute, Disabled = false, IconName = application.IconName, Children = sections });
                    }
                }
            }

            return navItems;
        }

        private List<StatusDto> GetStatus()
        {
            var status = new List<StatusDto>();

            status.Add(new StatusDto { StatusId = false, Description = "Not Active" });
            status.Add(new StatusDto { StatusId = true, Description = "Active" });

            return status;
        }

        private List<RankDto> GetRanks()
        {
            var rankDtos = new List<RankDto>();
            var maximumRank = _configuration.GetSection("RankConfig").Get<RankConfig>()?.MaximunRank;

            for (int i = 1; i <= maximumRank; i++)
            {
                rankDtos.Add(new RankDto { RankNumber = i, RankDescription = i.ToString()});
            }

            return rankDtos;
        }

        private List<PointsTypeDto> GetPointsTypes()
        {
            var pointsTypeDtos = new List<PointsTypeDto>();
            var pointsTypeConfiguration = _configuration.GetSection("PointTypeConfig").Get<PointTypeConfig>().Types.ToList();

            foreach (var type in pointsTypeConfiguration)
            {
                pointsTypeDtos.Add(new PointsTypeDto { Type = type });
            }

            return pointsTypeDtos;
        }

        private List<GenderDto> GetGenders()
        {
            var genderConfigDtos = new List<GenderDto>();
            var genderConfiguration = _configuration.GetSection("GenderConfig").Get<GenderConfig>().Genders.ToList();

            foreach (var gender in genderConfiguration)
            {
                genderConfigDtos.Add(new GenderDto { Gender = gender });
            }

            return genderConfigDtos;
        }

    }
}
