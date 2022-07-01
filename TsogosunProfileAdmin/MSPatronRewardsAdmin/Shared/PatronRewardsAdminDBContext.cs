using Microsoft.EntityFrameworkCore;
using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Model.Response;
using MSPatronRewardsAdmin.Shared.Utils;

namespace MSPatronRewardsAdmin.Shared
{
    public class PatronRewardsAdminDBContext : DbContext
    {
        public PatronRewardsAdminDBContext(DbContextOptions<PatronRewardsAdminDBContext> options) : base(options)
        {
            //optionsBuilder.ConfigureWarnings(warnings => warnings.Throw(CoreEventId.IncludeIgnoredWarning));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ScratchCardDto>().HasNoKey();
            modelBuilder.Entity<PatronScratchCardDto>().HasNoKey();
            modelBuilder.Entity<ScratchCardOverViewDto>().HasNoKey();
            modelBuilder.Entity<ScratchCardMessageDto>().HasNoKey();
            modelBuilder.Entity<ScratchCardPrizeDto>().HasNoKey();
            modelBuilder.Entity<ScratchCardWinnersDto>().HasNoKey();
            modelBuilder.Entity<ScratchCardActiveTimesDto>().HasNoKey();
            modelBuilder.Entity<ScratchCardHeaderDto>().HasNoKey();            
            modelBuilder.Entity<LeaderBoardPromotionDto>().HasNoKey();
            modelBuilder.Entity<GamingAreaDto>().HasNoKey();
            modelBuilder.Entity<MobileSettingDto>().HasNoKey();
            modelBuilder.Entity<LeaderBoardPatronDto>().HasNoKey();
            modelBuilder.Entity<CommunicationPreferenceDto>().HasNoKey();
            modelBuilder.Entity<PrizeTypeDto>().HasNoKey();            
            modelBuilder.Entity<InsertPromotionResponse>().HasNoKey();            
            modelBuilder.Entity<ReturnResult>().HasNoKey(); 

        }

        public DbSet<ScratchCardDto> ScratchCardDtos { get; set; }
        public DbSet<PatronScratchCardDto> PatronScratchCardDtos { get; set; }
        public DbSet<ScratchCardOverViewDto> ScratchCardOverViewDtos { get; set; }
        public DbSet<ScratchCardMessageDto> ScratchCardMessageDtos { get; set; }
        public DbSet<ScratchCardPrizeDto> ScratchCardPrizeDtos { get; set; }
        public DbSet<ScratchCardWinnersDto> ScratchCardWinnersDtos { get; set; }
        public DbSet<ScratchCardActiveTimesDto> ScratchCardActiveTimesDtos { get; set; }
        public DbSet<ScratchCardHeaderDto> ScratchCardHeaderDtos { get; set; }        
        public DbSet<LeaderBoardPromotionDto> LeaderBoardPromotionDtos { get; set; }
        public DbSet<GamingAreaDto> GamingAreaDtos { get; set; }
        public DbSet<MobileSettingDto> MobileSettingDtos { get; set; }
        public DbSet<LeaderBoardPatronDto> LeaderBoardPatronDtos { get; set; }
        public DbSet<CommunicationPreferenceDto> CommunicationPreferenceDtos { get; set; }
        public DbSet<PrizeTypeDto> PrizeTypeDtos { get; set; }        
        public DbSet<InsertPromotionResponse> InsertPromotionResponses { get; set; }
        public DbSet<ReturnResult> ReturnResults { get; set; }
        
    }
}
