using Microsoft.EntityFrameworkCore;

namespace BackendInfoApp.DB
{
    public class InfoAppDbContext : DbContext
    {
        public InfoAppDbContext(DbContextOptions<InfoAppDbContext> options) : base(options){}

        public DbSet<Entities.Entities.WeatherDataEntity> WeatherData { get; set; }

        protected override void OnModelCreating(ModelBuilder oModelBuilder)
        {
            base.OnModelCreating(oModelBuilder);
            oModelBuilder.Entity<Entities.Entities.WeatherDataEntity>(oEntity =>
            {
                oEntity.HasKey(e => e.nId);
                oEntity.Property(e => e.sCity).IsRequired();
                oEntity.Property(e => e.sCountry).IsRequired();
                oEntity.Property(e => e.dTempC).IsRequired();
                oEntity.Property(e => e.sConditionText).IsRequired();
                oEntity.Property(e => e.dWindKph).IsRequired();
                oEntity.Property(e => e.sWindDir).IsRequired();
                oEntity.Property(e => e.dFeelsLikeC).IsRequired();
                oEntity.Property(e => e.oRecordedAt).IsRequired();
            });
        }
    }
}