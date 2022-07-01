using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Linq;
using tsogosun.com.MSPatronDetails.Model.Dtos;
using tsogosun.com.MSPatronDetails.Repository.Interface;
using tsogosun.com.MSPatronDetails.Shared;
using tsogosun.com.MSPatronDetails.Shared.Utils;
using System;
using System.Collections.Generic;
using tsogosun.com.MSPatronDetails.Model.Request;

namespace tsogosun.com.MSPatronDetails.Repository
{
    public class PatronDetailsRepository : IPatronDetailsRepository
    {

        private readonly PatronDetailsDBContext _dbContext;

        public PatronDetailsRepository(PatronDetailsDBContext context)
        {
            _dbContext = context;
        }

        public List<PatronDetailsDto> GetPatronDetailsBySiteId(int siteId)
        {
            return _dbContext.PatronDetailsDtos.FromSqlRaw("pSel_GetUserDetailsBySiteID @siteId",
                                                                      new SqlParameter("@siteId", siteId)).ToList();
        }

        public ReturnResult UpdatePatronDetailsStatus(RequestUpdatePatronStatus requestUpdatePatronStatus)
        {
            return _dbContext.ReturnResults.FromSqlRaw("pUpd_PlayerDetailsStatus @UserDetailID,@Status,@UserName",
                                                     new SqlParameter("@UserDetailID", requestUpdatePatronStatus.UserDetailID),
                                                     new SqlParameter("@Status", requestUpdatePatronStatus.Status),
                                                     new SqlParameter("@UserName", requestUpdatePatronStatus.UserName)).ToList().FirstOrDefault();
        }

        public PatronsDetailsInfoDto GetPatronDetailByUserId(int userId)
        {
            return null;
            //return _dbContext.PatronsDetailsInfoDtos.FromSqlRaw("pSel_GetPatronDetailsByUserID @UserId",
                                                                    //  new SqlParameter("@UserId", userId)).ToList().FirstOrDefault();
        }
        
        public UnconfirmedGMSPatronDetailsInfoDto GetUnconfirmedGMSPatronDetailsInfoByUserId(int userId)
        {
            return _dbContext.UnconfirmedGMSPatronDetailsInfoDtos.FromSqlRaw("pSel_GetPatronDetailsByUserID @UserId",
                                                                      new SqlParameter("@UserId", userId)).ToList().FirstOrDefault();
        }

        public UnconfirmedIGTPatronDetailsInfoDto GetUnconfirmedIGTPatronDetailsInfoByUserId(int userId)
        {
            return _dbContext.UnconfirmedIGTPatronDetailsInfoDtos.FromSqlRaw("pSel_GetPatronDetailsByUserID @UserId",
                                                                      new SqlParameter("@UserId", userId)).ToList().FirstOrDefault();
        }       

        public ReturnResult UpdateUnconfirmedGMSPatronDetails(UnconfirmedGMSPatronDetailsInfoDto unconfirmedGMSPatronDetailsInfoDto)
        {
            return _dbContext.ReturnResults.FromSqlRaw("pUpd_UnconfirmGamesmartUserDetails  @UserID,@MobileNumber,@EmailAddress,@IDPassNo,@RankID,@Name,@Surname,@BirthDate,@Nationality,@pTitle,@Gender," +
                                                                                  "@Address1, @Address2,@IDPassImage,@IDPassCountry,@Occupation,@PreferredSms,@PreferredEmail," +
                                                                                  "@PreferredPhoneCall,@PreferredPost,@Notes,@SiteID,@PcId,@AdminUserName,@IsOnHold,@DocumentTypeId,@DocumentExpireDate,@Pippep",

                                                           new SqlParameter("@UserID", unconfirmedGMSPatronDetailsInfoDto.UserId),
                                                           new SqlParameter("@MobileNumber", unconfirmedGMSPatronDetailsInfoDto.MobileNumber),
                                                           new SqlParameter("@EmailAddress", unconfirmedGMSPatronDetailsInfoDto.EmailAddress),
                                                           new SqlParameter("@IDPassNo", unconfirmedGMSPatronDetailsInfoDto.IdpassportNO),
                                                           new SqlParameter("@RankID", unconfirmedGMSPatronDetailsInfoDto.Rating),
                                                           new SqlParameter("@pTitle", unconfirmedGMSPatronDetailsInfoDto.Title),
                                                           new SqlParameter("@Gender", unconfirmedGMSPatronDetailsInfoDto.Gender),
                                                           new SqlParameter("@Name", unconfirmedGMSPatronDetailsInfoDto.FirstName),
                                                           new SqlParameter("@Surname", unconfirmedGMSPatronDetailsInfoDto.LastName),
                                                           new SqlParameter("@Nationality", unconfirmedGMSPatronDetailsInfoDto.Nationality),
                                                           new SqlParameter("@Address1", unconfirmedGMSPatronDetailsInfoDto.Address1),
                                                           new SqlParameter("@Address2", unconfirmedGMSPatronDetailsInfoDto.Address2),
                                                           new SqlParameter("@IDPassImage", unconfirmedGMSPatronDetailsInfoDto.IDPassImage),
                                                           new SqlParameter("@IDPassCountry", unconfirmedGMSPatronDetailsInfoDto.IDPassCountry),
                                                           new SqlParameter("@BirthDate", unconfirmedGMSPatronDetailsInfoDto.BirthDate),
                                                           new SqlParameter("@Occupation", unconfirmedGMSPatronDetailsInfoDto.Occupation),
                                                           new SqlParameter("@PreferredSms", unconfirmedGMSPatronDetailsInfoDto.PreferredSms),
                                                           new SqlParameter("@PreferredEmail", unconfirmedGMSPatronDetailsInfoDto.PreferredEmail),
                                                           new SqlParameter("@PreferredPhoneCall", unconfirmedGMSPatronDetailsInfoDto.PreferredPhoneCall),
                                                           new SqlParameter("@PreferredPost", unconfirmedGMSPatronDetailsInfoDto.PreferredPost),
                                                           new SqlParameter("@Notes", unconfirmedGMSPatronDetailsInfoDto.Notes),
                                                           new SqlParameter("@SiteID", unconfirmedGMSPatronDetailsInfoDto.SiteID),
                                                           new SqlParameter("@PcId", unconfirmedGMSPatronDetailsInfoDto.PcId),
                                                           new SqlParameter("@IsOnHold", false),
                                                           new SqlParameter("@AdminUserName", unconfirmedGMSPatronDetailsInfoDto.AdminUserName),
                                                           new SqlParameter("@DocumentTypeId", unconfirmedGMSPatronDetailsInfoDto.DocumentTypeId),
                                                           new SqlParameter("@DocumentExpireDate", string.IsNullOrEmpty(unconfirmedGMSPatronDetailsInfoDto.DocumentExpireDate.ToString()) ? DBNull.Value : unconfirmedGMSPatronDetailsInfoDto.DocumentExpireDate),
                                                           new SqlParameter("@Pippep", unconfirmedGMSPatronDetailsInfoDto.Pippep)).ToList().FirstOrDefault();
        }

        public ReturnResult UpdateUnconfirmedIGTPatronDetails(UnconfirmedIGTPatronDetailsInfoDto unconfirmedIGTPatronDetailsInfoDto)
        {
            return _dbContext.ReturnResults.FromSqlRaw("pUpd_UnconfirmUserDetails  @UserID,@MobileNumber,@EmailAddress,@IDPassNo,@RankID,@Name,@Surname,@BirthDate,@Nationality,@pTitle,@Gender," +
                                                                                  "@Address1, @Address2,@IDPassImage,@IDPassCountry,@Occupation,@PreferredSms,@PreferredEmail," +
                                                                                  "@PreferredPhoneCall,@PreferredPost,@Notes,@SiteID,@PcId,@AdminUserName,@IsOnHold",

                                                           new SqlParameter("@UserID", unconfirmedIGTPatronDetailsInfoDto.UserId),
                                                           new SqlParameter("@MobileNumber", unconfirmedIGTPatronDetailsInfoDto.MobileNumber),
                                                           new SqlParameter("@EmailAddress", unconfirmedIGTPatronDetailsInfoDto.EmailAddress),
                                                           new SqlParameter("@IDPassNo", unconfirmedIGTPatronDetailsInfoDto.IdpassportNO),
                                                           new SqlParameter("@RankID", unconfirmedIGTPatronDetailsInfoDto.Rating),
                                                           new SqlParameter("@pTitle", unconfirmedIGTPatronDetailsInfoDto.Title),
                                                           new SqlParameter("@Gender", unconfirmedIGTPatronDetailsInfoDto.Gender),
                                                           new SqlParameter("@Name", unconfirmedIGTPatronDetailsInfoDto.FirstName),
                                                           new SqlParameter("@Surname", unconfirmedIGTPatronDetailsInfoDto.LastName),
                                                           new SqlParameter("@Nationality", unconfirmedIGTPatronDetailsInfoDto.Nationality),
                                                           new SqlParameter("@Address1", unconfirmedIGTPatronDetailsInfoDto.Address1),
                                                           new SqlParameter("@Address2", unconfirmedIGTPatronDetailsInfoDto.Address2),
                                                           new SqlParameter("@IDPassImage", unconfirmedIGTPatronDetailsInfoDto.IDPassImage),
                                                           new SqlParameter("@IDPassCountry", unconfirmedIGTPatronDetailsInfoDto.IDPassCountry),
                                                           new SqlParameter("@BirthDate", unconfirmedIGTPatronDetailsInfoDto.BirthDate),
                                                           new SqlParameter("@Occupation", unconfirmedIGTPatronDetailsInfoDto.Occupation),
                                                           new SqlParameter("@PreferredSms", unconfirmedIGTPatronDetailsInfoDto.PreferredSms),
                                                           new SqlParameter("@PreferredEmail", unconfirmedIGTPatronDetailsInfoDto.PreferredEmail),
                                                           new SqlParameter("@PreferredPhoneCall", unconfirmedIGTPatronDetailsInfoDto.PreferredPhoneCall),
                                                           new SqlParameter("@PreferredPost", unconfirmedIGTPatronDetailsInfoDto.PreferredPost),
                                                           new SqlParameter("@Notes", unconfirmedIGTPatronDetailsInfoDto.Notes),
                                                           new SqlParameter("@SiteID", unconfirmedIGTPatronDetailsInfoDto.SiteID),
                                                           new SqlParameter("@PcId", unconfirmedIGTPatronDetailsInfoDto.PcId),
                                                           new SqlParameter("@IsOnHold", false),
                                                           new SqlParameter("@AdminUserName", unconfirmedIGTPatronDetailsInfoDto.AdminUserName)).ToList().FirstOrDefault();



        }





        //to be remove
        public ReturnResult UpdatePatronDetails(PatronsDetailsInfoDto patronsDetailsInfoDto)
        {
            return _dbContext.ReturnResults.FromSqlRaw("pUpd_UserDetails  @UserID,@MobileNumber,@EmailAddress,@IDPassNo,@RankID,@Name,@Surname,@BirthDate,@Nationality,@pTitle,@Gender," +
                                                                                  "@Address1, @Address2,@IDPassImage,@IDPassCountry,@Occupation,@PreferredSms,@PreferredEmail," +
                                                                                  "@PreferredPhoneCall,@PreferredPost,@Notes,@SiteID,@PcId,@AdminUserName,@IsOnHold,@DocumentTypeId,@DocumentExpireDate,@Pippep",

                                                           new SqlParameter("@UserID", patronsDetailsInfoDto.UserId),
                                                           new SqlParameter("@MobileNumber", patronsDetailsInfoDto.MobileNumber),
                                                           new SqlParameter("@EmailAddress", patronsDetailsInfoDto.EmailAddress),
                                                           new SqlParameter("@IDPassNo", patronsDetailsInfoDto.IdpassportNO),
                                                           new SqlParameter("@RankID", patronsDetailsInfoDto.Rating),
                                                           new SqlParameter("@pTitle", patronsDetailsInfoDto.Title),
                                                           new SqlParameter("@Gender", patronsDetailsInfoDto.Gender),
                                                           new SqlParameter("@Name", patronsDetailsInfoDto.FirstName),
                                                           new SqlParameter("@Surname", patronsDetailsInfoDto.LastName),
                                                           new SqlParameter("@Nationality", patronsDetailsInfoDto.Nationality),
                                                           new SqlParameter("@Address1", patronsDetailsInfoDto.Address1),
                                                           new SqlParameter("@Address2", patronsDetailsInfoDto.Address2),
                                                           new SqlParameter("@IDPassImage", patronsDetailsInfoDto.IDPassImage),
                                                           new SqlParameter("@IDPassCountry", patronsDetailsInfoDto.IDPassCountry),
                                                           new SqlParameter("@BirthDate", patronsDetailsInfoDto.BirthDate),
                                                           new SqlParameter("@Occupation", patronsDetailsInfoDto.Occupation),
                                                           new SqlParameter("@PreferredSms", patronsDetailsInfoDto.PreferredSms),
                                                           new SqlParameter("@PreferredEmail", patronsDetailsInfoDto.PreferredEmail),
                                                           new SqlParameter("@PreferredPhoneCall", patronsDetailsInfoDto.PreferredPhoneCall),
                                                           new SqlParameter("@PreferredPost", patronsDetailsInfoDto.PreferredPost),
                                                           new SqlParameter("@Notes", patronsDetailsInfoDto.Notes)
                                                           //new SqlParameter("@SiteID", patronsDetailsInfoDto.SiteID),
                                                           //new SqlParameter("@PcId", patronsDetailsInfoDto.PcId),
                                                           //new SqlParameter("@IsOnHold", false),
                                                           //new SqlParameter("@AdminUserName", patronsDetailsInfoDto.AdminUserName),
                                                           //new SqlParameter("@DocumentTypeId", patronsDetailsInfoDto.DocumentTypeId),
                                                           //new SqlParameter("@DocumentExpireDate", string.IsNullOrEmpty(patronsDetailsInfoDto.DocumentExpireDate.ToString()) ? DBNull.Value : patronsDetailsInfoDto.DocumentExpireDate),
                                                           //new SqlParameter("@Pippep", patronsDetailsInfoDto.Pippep)
                                                           
                                                           ).ToList().FirstOrDefault();
        }
        //to be deleted

        public ReturnResult UpdatePatronAddress(PatronsDetailsInfoDto patronsDetailsInfoDto)
        {
            return _dbContext.ReturnResults.FromSqlRaw("pUpd_UserDetailsAddress @UserID,@Address1,@Address2,@Suburb,@City,@Province,@Country,@PostalCode,@AdminUserName",
                                                     new SqlParameter("@UserID", patronsDetailsInfoDto.UserId),
                                                     new SqlParameter("@Address1", string.IsNullOrEmpty(patronsDetailsInfoDto.Address1) ? DBNull.Value : patronsDetailsInfoDto.Address1),
                                                     new SqlParameter("@Address2", string.IsNullOrEmpty(patronsDetailsInfoDto.Address2) ? DBNull.Value : patronsDetailsInfoDto.Address2),
                                                     new SqlParameter("@Suburb", patronsDetailsInfoDto.Suburb),
                                                     new SqlParameter("@City", patronsDetailsInfoDto.City),
                                                     new SqlParameter("@Province", patronsDetailsInfoDto.Province),
                                                     new SqlParameter("@Country", patronsDetailsInfoDto.Country),
                                                     new SqlParameter("@PostalCode", patronsDetailsInfoDto.PostalCode),
                                                     new SqlParameter("@AdminUserName", patronsDetailsInfoDto.AdminUserName)).ToList().FirstOrDefault();
        }

        public IGTConfirmedPatronDetailsDto GetConfirmedPatronDetailFromIGTByUserId(long userId)
        {
            return _dbContext.IGTConfirmedPatronDetailsDtos.FromSqlRaw("pSel_GetConfirmedPatronDetailsIGTByUserId @UserId",
                                                                      new SqlParameter("@UserId", userId)).ToList().FirstOrDefault();
        }

        public GMSConfirmedPatronDetailsDto GetConfirmedPatronDetailFromGamesmartByUserId(long userId)
        {
            return _dbContext.GMSConfirmedPatronDetailsDtos.FromSqlRaw("pSel_GetConfirmedPatronDetailsByUserIdGamesmart @UserId",
                                                                      new SqlParameter("@UserId", userId)).ToList().FirstOrDefault();
        }

        public List<ApprovedUserDetailsDto> GetApprovedUserDetailsBySiteId(int siteId)
        {
            return _dbContext.ApprovedUserDetailsDtos.FromSqlRaw("pSel_GetApprovedUserDetailsBySiteID @SiteID",
                                                                      new SqlParameter("@SiteID", siteId)).ToList();
        }

        public ReturnResult ConfirmPlayerStatusAfterSubmitToGaming(ConfirmPlayerToSubmitGamingDto confirmPlayerToSubmitGamingDto)
        {

            return _dbContext.ReturnResults.FromSqlRaw("pUpd_ApprovedPlayerDetailsStatus  @UserDetailID,@ConfirmedBy",

                                                                   new SqlParameter("@UserDetailID", confirmPlayerToSubmitGamingDto.UserDetailId),
                                                                   new SqlParameter("@ConfirmedBy", confirmPlayerToSubmitGamingDto.ConfirmedBy)).ToList().FirstOrDefault();

        }
    }
}
