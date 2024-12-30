using Microsoft.EntityFrameworkCore;
using MyCurrencyApi.Domain.Entities;

namespace MyCurrencyApi.Infrastructure.DAL
{
    public class CurrencyRateDbContext : DbContext
    {
        public DbSet<CurrencyRate> CurrencyRates { get; set; }

        public CurrencyRateDbContext(DbContextOptions<CurrencyRateDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyRate>(builder =>
            {
                builder.HasKey(cr => cr.Id);
                builder.Property(x => x.Id)
                    .HasConversion(x => x.Value, x => new(x));
                builder.Property(cr => cr.Date).IsRequired();
                builder.OwnsOne(cr => cr.Money, money =>
                {
                    money.Property(m => m.Amount).HasColumnName("Amount").IsRequired();
                    money.OwnsOne(m => m.Currency, currency =>
                    {
                        currency.Property(c => c.Code).HasColumnName("CurrencyCode").IsRequired();
                        currency.Property(c => c.Name).HasColumnName("CurrencyName").IsRequired();
                    });
                });
                builder.HasDiscriminator<string>("Discriminator")
                    .HasValue<AskRate>(nameof(AskRate))
                    .HasValue<BidRate>(nameof(BidRate));
            });
        }
    }
}