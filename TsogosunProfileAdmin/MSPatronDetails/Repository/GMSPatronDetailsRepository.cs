using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Linq;
using tsogosun.com.MSPatronDetails.Model.Dtos;
using tsogosun.com.MSPatronDetails.Repository.Interface;
using tsogosun.com.MSPatronDetails.Shared;
using tsogosun.com.MSPatronDetails.Shared.Utils;
using System;

namespace tsogosun.com.MSPatronDetails.Repository
{
    public class GMSPatronDetailsRepository : IGMSPatronDetailsRepository
    {

        private readonly PatronDetailsDBContext _dbContext;

        public GMSPatronDetailsRepository(PatronDetailsDBContext context)
        {
            _dbContext = context;
        }

        private static byte[] ConvertToBytes(string contents)
        {
            return string.IsNullOrEmpty(contents) ? null : contents.Contains(",") == true ? Convert.FromBase64String(contents.Split(',').Last()) : Convert.FromBase64String(contents);
        }
        public GMSProfileReturnResult AddGMSPatronDetails(GMSPatronDetails gmsPatronDetails)
        {

            return _dbContext.GMSProfileReturnResults.FromSqlRaw("pIns_GMSPatronInfo @IDPassportNumber,@CountryOfIssue,@DocExpiryDate,@Nationality," +
                                                                                    "@FirstName,@LastName, @Birthday,@Gender, @Address1,@Address2,@PCID," +
                                                                                    "@ProvID,@CountryID,@PIPPEP,@DocumentType,@AllowCommConsent, @AllowCommSMS," +
                                                                                    "@AllowCommEmail,@AllowCommPhone, @AllowCommPost,@MobileNo, @LandLineNo,@Email, @Photo",

                                                                   new SqlParameter("@IDPassportNumber", gmsPatronDetails.IDPassportNumber),
                                                                   new SqlParameter("@CountryOfIssue", gmsPatronDetails.CountryOfIssue),
                                                                   new SqlParameter("@DocExpiryDate", string.IsNullOrEmpty(gmsPatronDetails.DocExpiryDate.ToString()) ? DBNull.Value : gmsPatronDetails.DocExpiryDate),
                                                                   new SqlParameter("@Nationality", gmsPatronDetails.Nationality),
                                                                   new SqlParameter("@FirstName", gmsPatronDetails.FirstName),
                                                                   new SqlParameter("@LastName", gmsPatronDetails.LastName),
                                                                   new SqlParameter("@Birthday", gmsPatronDetails.Birthday),
                                                                   new SqlParameter("@Gender", gmsPatronDetails.Gender),
                                                                   new SqlParameter("@Address1", gmsPatronDetails.Address1),
                                                                   new SqlParameter("@Address2", gmsPatronDetails.Address2),
                                                                   new SqlParameter("@PCID", gmsPatronDetails.PCID.ToString()),
                                                                   new SqlParameter("@ProvID", gmsPatronDetails.ProvID),
                                                                   new SqlParameter("@CountryID", gmsPatronDetails.CountryID),
                                                                   new SqlParameter("@PIPPEP", gmsPatronDetails.PIPPEP),
                                                                   new SqlParameter("@DocumentType", gmsPatronDetails.DocumentType),
                                                                   new SqlParameter("@AllowCommConsent", gmsPatronDetails.AllowCommConsent),
                                                                   new SqlParameter("@AllowCommSMS", gmsPatronDetails.AllowCommSMS),
                                                                   new SqlParameter("@AllowCommEmail", gmsPatronDetails.AllowCommEmail),
                                                                   new SqlParameter("@AllowCommPhone", gmsPatronDetails.AllowCommPhone),
                                                                   new SqlParameter("@AllowCommPost", gmsPatronDetails.AllowCommPost),
                                                                   new SqlParameter("@MobileNo", gmsPatronDetails.MobileNo),
                                                                   new SqlParameter("@LandLineNo", gmsPatronDetails.LandLineNo),
                                                                   new SqlParameter("@Email", gmsPatronDetails.Email),
                                                                   new SqlParameter("@Photo", string.IsNullOrEmpty(gmsPatronDetails.Photo) ? DBNull.Value : ConvertToBytes(gmsPatronDetails.Photo))).ToList().FirstOrDefault();

        }
    }
}
