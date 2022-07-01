using Microsoft.EntityFrameworkCore;
using tsogosun.com.MSProfileAdmin.Model;
//using System.Data.Entity.Infrastructure;
using tsogosun.com.MSProfileAdmin.Model.Dtos;
using tsogosun.com.MSProfileAdmin.Model.Dtos.Gamesmart;
using tsogosun.com.MSProfileAdmin.Model.Dtos.IGTConfig;
using tsogosun.com.MSProfileAdmin.Model.Dtos.IGTPatronDetails;
using tsogosun.com.MSProfileAdmin.Model.Dtos.PatronDetails;
using tsogosun.com.MSProfileAdmin.Shared.Utils;

namespace tsogosun.com.MSProfileAdmin.Shared
{
    public class ProfileAdminDBContext : DbContext
    {

        public ProfileAdminDBContext(DbContextOptions<ProfileAdminDBContext> options) : base(options)
        {
            //optionsBuilder.ConfigureWarnings(warnings => warnings.Throw(CoreEventId.IncludeIgnoredWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserDetailsDto>().HasNoKey();
            modelBuilder.Entity<TitleDto>().HasNoKey();
            modelBuilder.Entity<PatronFreePlayDto>().HasNoKey();
            modelBuilder.Entity<PatronVoucherDto>().HasNoKey();
            modelBuilder.Entity<PatronDrawDto>().HasNoKey();
            modelBuilder.Entity<PatronScratchCardDto>().HasNoKey();           
            modelBuilder.Entity<CountryDto>().HasNoKey();
            modelBuilder.Entity<ProvinceDto>().HasNoKey();
            modelBuilder.Entity<PostalCodeDto>().HasNoKey();
            modelBuilder.Entity<CityDto>().HasNoKey();
            modelBuilder.Entity<SuburbDto>().HasNoKey();
            modelBuilder.Entity<PatronDetailsDto>().HasNoKey();
            modelBuilder.Entity<PatronsDetailsInfoDto>().HasNoKey();
            modelBuilder.Entity<PatronAddressSearchDto>().HasNoKey();
            modelBuilder.Entity<ConfirmedPatronDetailsDto>().HasNoKey();
            modelBuilder.Entity<IGTEnrolmentConfigDto>().HasNoKey();
            modelBuilder.Entity<IGTCountryDto>().HasNoKey();            
            modelBuilder.Entity<GMAddressDto>().HasNoKey();
            modelBuilder.Entity<GMProvinceDto>().HasNoKey();
            modelBuilder.Entity<GMCountryDto>().HasNoKey();
            modelBuilder.Entity<GMDocumentTypeDto>().HasNoKey();            
            modelBuilder.Entity<ReturnResult>().HasNoKey();

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<ApplicationSection> ApplicationSections { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<DefaultPermissionGroup> DefaultPermissionGroups { get; set; }
        public DbSet<PrizeType> PrizeTypes { get; set; }
        public DbSet<UserDetailsDto> UserDetailsDtos { get; set; }
        public DbSet<TitleDto> TitleDtos { get; set; }
        public DbSet<PatronFreePlayDto> PatronFreePlayDtos { get; set; }
        public DbSet<PatronVoucherDto> PatronVoucherDtos { get; set; }
        public DbSet<PatronDrawDto> PatronDrawDtos { get; set; }
        public DbSet<PatronScratchCardDto> PatronScratchCardDtos { get; set; }        
        public DbSet<CountryDto> CountryDtos { get; set; }
        public DbSet<ProvinceDto> ProvinceDtos { get; set; }
        public DbSet<PostalCodeDto> PostalCodeDtos { get; set; }
        public DbSet<CityDto> CityDtos { get; set; }
        public DbSet<SuburbDto> SuburbDtos { get; set; }
        public DbSet<PatronDetailsDto> PatronDetailsDtos { get; set; }
        public DbSet<PatronsDetailsInfoDto> PatronsDetailsInfoDtos { get; set; }
        public DbSet<PatronAddressSearchDto> PatronAddressSearchDtos { get; set; }
        public DbSet<ConfirmedPatronDetailsDto> ConfirmedPatronDetailsDtos { get; set; }
        public DbSet<IGTEnrolmentConfigDto> IGTEnrolmentConfigDtos { get; set; }
        public DbSet<IGTCountryDto> IGTCountryDtos { get; set; }        
        public DbSet<GMAddressDto> GMAddressDtos { get; set; }
        public DbSet<GMProvinceDto> GMProvinceDtos { get; set; }
        public DbSet<GMCountryDto> GMCountryDtos { get; set; }
        public DbSet<GMDocumentTypeDto> GMDocumentTypeDtos { get; set; }        
        public DbSet<ReturnResult> ReturnResults { get; set; }
        
    }
}
