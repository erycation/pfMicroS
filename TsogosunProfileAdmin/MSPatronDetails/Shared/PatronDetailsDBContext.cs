using Microsoft.EntityFrameworkCore;
using tsogosun.com.MSPatronDetails.Model.Dtos;
using tsogosun.com.MSPatronDetails.Model.Dtos.IGTConfig;
using tsogosun.com.MSPatronDetails.Model.Dtos.IGTPatronDetails;
using tsogosun.com.MSPatronDetails.Shared.Utils;

namespace tsogosun.com.MSPatronDetails.Shared
{
    public class PatronDetailsDBContext : DbContext
    {

        public PatronDetailsDBContext(DbContextOptions<PatronDetailsDBContext> options) : base(options)
        {
            //optionsBuilder.ConfigureWarnings(warnings => warnings.Throw(CoreEventId.IncludeIgnoredWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PatronDetailsDto>().HasNoKey();
            //modelBuilder.Entity<PatronsDetailsInfoDto>().HasNoKey();
            modelBuilder.Entity<UnconfirmedGMSPatronDetailsInfoDto>().HasNoKey();
            modelBuilder.Entity<UnconfirmedIGTPatronDetailsInfoDto>().HasNoKey();
            modelBuilder.Entity<PatronAddressSearchDto>().HasNoKey();
            modelBuilder.Entity<IGTConfirmedPatronDetailsDto>().HasNoKey();
            modelBuilder.Entity<GMSConfirmedPatronDetailsDto>().HasNoKey();            
            modelBuilder.Entity<IGTEnrolmentConfigDto>().HasNoKey();
            modelBuilder.Entity<ApprovedUserDetailsDto>().HasNoKey();
            modelBuilder.Entity<IGTCountryDto>().HasNoKey();
            modelBuilder.Entity<ReturnResult>().HasNoKey();
            modelBuilder.Entity<GMSProfileReturnResult>().HasNoKey();
            
        }

        public DbSet<PatronDetailsDto> PatronDetailsDtos { get; set; }
        //public DbSet<PatronsDetailsInfoDto> PatronsDetailsInfoDtos { get; set; }
        //UnconfirmedGMSPatronDetailsInfoDto UnconfirmedIGTPatronDetailsInfoDto
        public DbSet<UnconfirmedGMSPatronDetailsInfoDto> UnconfirmedGMSPatronDetailsInfoDtos { get; set; }
        public DbSet<UnconfirmedIGTPatronDetailsInfoDto> UnconfirmedIGTPatronDetailsInfoDtos { get; set; }
        public DbSet<PatronAddressSearchDto> PatronAddressSearchDtos { get; set; }
        public DbSet<IGTConfirmedPatronDetailsDto> IGTConfirmedPatronDetailsDtos { get; set; }
        public DbSet<GMSConfirmedPatronDetailsDto> GMSConfirmedPatronDetailsDtos { get; set; }        
        public DbSet<IGTEnrolmentConfigDto> IGTEnrolmentConfigDtos { get; set; }
        public DbSet<ApprovedUserDetailsDto> ApprovedUserDetailsDtos { get; set; }
        public DbSet<IGTCountryDto> IGTCountryDtos { get; set; }
        public DbSet<ReturnResult> ReturnResults { get; set; }
        public DbSet<GMSProfileReturnResult> GMSProfileReturnResults { get; set; }
        

    }
}

