using MyCurrencyApi.Domain.ValueObjects;

namespace MyCurrencyApi.Domain.Entities
{
    public sealed class AskRate : CurrencyRate
    {
        private AskRate() : base() { }
        public AskRate(RateId id, Money money, DateOnly date) : base(id, money, date)
        {
        }
    }
}
