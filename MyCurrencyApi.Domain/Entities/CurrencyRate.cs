using MyCurrencyApi.Domain.ValueObjects;

namespace MyCurrencyApi.Domain.Entities
{
    public abstract class CurrencyRate
    {
        public RateId Id { get; private set; }
        public Money Money { get; private set; } 
        public DateOnly Date { get; private set; }

        protected CurrencyRate() { }
        protected CurrencyRate(RateId id, Money currency, DateOnly date)
        {
            Id = id;
            Money = currency;
            Date = date;
        }
    }
}
