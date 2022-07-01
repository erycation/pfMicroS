using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using tsogosun.com.MSProfileAdmin.Model.Dtos.PatronDetails;
using tsogosun.com.MSProfileAdmin.Repository.Interface;
using tsogosun.com.MSProfileAdmin.Shared;
using tsogosun.com.MSProfileAdmin.Shared.Utils;
using tsogosun.com.MSProfileAdmin.Model.Request;
using System;

namespace tsogosun.com.MSProfileAdmin.Repository
{
    public class PatronDetailsRepository : IPatronDetailsRepository
    {

        private readonly ProfileAdminDBContext _dbContext;

        public PatronDetailsRepository(ProfileAdminDBContext context)
        {
            _dbContext = context;
        }

        public List<PatronDetailsDto> GetPatronDetailsBySiteId(int siteId)
        {
            return _dbContext.PatronDetailsDtos.FromSqlRaw("pPDETAILS_getPatronDetailsBySiteId @siteId",
                                                                      new SqlParameter("@siteId", siteId)).ToList();
        }

        public ReturnResult UpdatePatronDetailsStatus(RequestUpdatePatronStatus requestUpdatePatronStatus)
        {
            return _dbContext.ReturnResults.FromSqlRaw("pPDETAILS_updPlayerDetailsStatus @UserDetailID,@Status,@UserName",
                                                     new SqlParameter("@UserDetailID", requestUpdatePatronStatus.UserDetailID),
                                                     new SqlParameter("@Status", requestUpdatePatronStatus.Status),
                                                     new SqlParameter("@UserName", requestUpdatePatronStatus.UserName)).ToList().FirstOrDefault();
        }           

        public PatronsDetailsInfoDto GetPatronDetailByUserId(int userId)
        {
            return _dbContext.PatronsDetailsInfoDtos.FromSqlRaw("pPDETAILS_getPatronDetailsByUserId @UserId",
                                                                      new SqlParameter("@UserId", userId)).ToList().FirstOrDefault();
        }

        public ReturnResult UpdatePatronDetails(PatronsDetailsInfoDto patronsDetailsInfoDto)
        {
           return _dbContext.ReturnResults.FromSqlRaw("pPDETAILS_UpdPatronDetails  @UserID,@MobileNumber,@EmailAddress,@IDPassNo,@RankID,@Name,@Surname,@BirthDate,@Nationality,@pTitle,@Gender,@IDPassImage,@IDPassCountry,@Occupation,@PreferredSms,@PreferredEmail," +
                                                                                 "@PreferredPhoneCall,@PreferredPost,@Notes,@SiteID,@PcId,@AdminUserName,@IsOnHold, @DocumentTypeId",

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
                                                          new SqlParameter("@IDPassImage", patronsDetailsInfoDto.IDPassImage),
                                                          new SqlParameter("@IDPassCountry", patronsDetailsInfoDto.IDPassCountry),
                                                          new SqlParameter("@BirthDate", patronsDetailsInfoDto.BirthDate),
                                                          new SqlParameter("@Occupation", patronsDetailsInfoDto.Occupation),
                                                          new SqlParameter("@PreferredSms", patronsDetailsInfoDto.PreferredSms),
                                                          new SqlParameter("@PreferredEmail", patronsDetailsInfoDto.PreferredEmail),
                                                          new SqlParameter("@PreferredPhoneCall", patronsDetailsInfoDto.PreferredPhoneCall),
                                                          new SqlParameter("@PreferredPost", patronsDetailsInfoDto.PreferredPost),
                                                          new SqlParameter("@Notes", patronsDetailsInfoDto.Notes),
                                                          new SqlParameter("@SiteID", patronsDetailsInfoDto.SiteID),
                                                          new SqlParameter("@PcId", patronsDetailsInfoDto.PcId),                                                          
                                                          new SqlParameter("@IsOnHold", false),
                                                          new SqlParameter("@AdminUserName", patronsDetailsInfoDto.AdminUserName),
                                                          new SqlParameter("@DocumentTypeId", patronsDetailsInfoDto.DocumentTypeId)
                                                          ).ToList().FirstOrDefault();
        }
        //to be deleted

        public ReturnResult UpdatePatronAddress(PatronsDetailsInfoDto patronsDetailsInfoDto)
        {
            return _dbContext.ReturnResults.FromSqlRaw("pPDETAILS_updPlayerAddress @UserID,@Address1,@Address2,@Suburb,@City,@Province,@Country,@PostalCode,@AdminUserName",
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

        public ConfirmedPatronDetailsDto GetConfirmedPatronDetailByUserId(long userId)
        {
            return _dbContext.ConfirmedPatronDetailsDtos.FromSqlRaw("pPDETAILS_getConfirmedPatronDetailsByUserId @UserId",
                                                                      new SqlParameter("@UserId", userId)).ToList().FirstOrDefault();
        }
    }
}