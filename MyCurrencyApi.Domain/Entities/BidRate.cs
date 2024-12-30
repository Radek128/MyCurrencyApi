using MyCurrencyApi.Domain.ValueObjects;

namespace MyCurrencyApi.Domain.Entities
{
    public sealed class BidRate : CurrencyRate
    {
        private BidRate() : base() { }
        public BidRate(RateId id, Money money, DateOnly date) : base(id, money, date)
        {
        }
    }
}
