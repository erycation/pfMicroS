

using Microsoft.EntityFrameworkCore;
using tsogosun.com.MSMDMPatron.Model.Dtos;

namespace tsogosun.com.MSMDMPatron.Shared
{
    public class MDMPatronDBContext : DbContext
    {

        public MDMPatronDBContext(DbContextOptions<MDMPatronDBContext> options) : base(options)
        {
            //optionsBuilder.ConfigureWarnings(warnings => warnings.Throw(CoreEventId.IncludeIgnoredWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PatronStatusSummaryDetailsDto>().HasNoKey();
            modelBuilder.Entity<PatronSearchDto>().HasNoKey();
            modelBuilder.Entity<PatronDetailsDto>().HasNoKey();
            modelBuilder.Entity<PatronSitesDto>().HasNoKey();
            modelBuilder.Entity<PatronDetailsSiteDto>().HasNoKey();
            modelBuilder.Entity<GamingPointsTSGDto>().HasNoKey();
            modelBuilder.Entity<GamingPointsUnitDto>().HasNoKey();
            modelBuilder.Entity<GamingKPISDeffinitionDto>().HasNoKey();
            modelBuilder.Entity<GamingKPISUnitDto>().HasNoKey();
            modelBuilder.Entity<GamingKPISTSGDto>().HasNoKey();
            modelBuilder.Entity<PatronRegisterdSitesDto>().HasNoKey();            
        }
        
        public DbSet<PatronStatusSummaryDetailsDto> PatronStatusSummaryDetailsDtos { get; set; }
        public DbSet<PatronSearchDto> PatronSearchDtos { get; set; }
        public DbSet<PatronDetailsDto> PatronDetailsDtos { get; set; }
        public DbSet<PatronSitesDto> PatronSitesDtos { get; set; }
        public DbSet<PatronDetailsSiteDto> PatronDetailsSiteDtos { get; set; }
        public DbSet<GamingPointsTSGDto> GamingPointsTSGDtos { get; set; }
        public DbSet<GamingPointsUnitDto> GamingPointsUnitDtos { get; set; }
        public DbSet<GamingKPISDeffinitionDto> GamingKPISDeffinitionDtos { get; set; }
        public DbSet<GamingKPISUnitDto> GamingKPISUnitDtos { get; set; }
        public DbSet<GamingKPISTSGDto> GamingKPISTSGDtos { get; set; }
        public DbSet<PatronRegisterdSitesDto> PatronRegisterdSitesDtos { get; set; }
        
    }
}

