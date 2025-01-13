
using MyCurrencyApi.Domain.Entities;

namespace MyCurrencyApi.Application.Models
{
    public record CurrencyRatesDto
    {
        public required string CurrencyCode { get; init; }
        public required DateOnly Date { get; init; }      
        public RateDto? AskRate { get; init; }     
        public RateDto? BidRate { get; init; }   

        public static CurrencyRatesDto GetCurrencyRatesDto(List<CurrencyRate> currencyRates, string code, DateOnly date)
        {
            var askRate = currencyRates.OfType<AskRate>().SingleOrDefault();
            var bidRate = currencyRates.OfType<BidRate>().SingleOrDefault();

            return new CurrencyRatesDto
            {
                CurrencyCode = code,
                Date = date,
                AskRate = askRate is not null? new RateDto
                {
                    Amount = askRate.Money.Amount,
                    CurrencyName = askRate.Money.Currency.Name
                } : null,
                BidRate = bidRate is not null ? new RateDto
                {
                    Amount = bidRate.Money.Amount,
                    CurrencyName = bidRate.Money.Currency.Name
                } : null,
            };
        }
    }
    public record RateDto
    {
        public required decimal Amount { get; set; } 
        public required string CurrencyName { get; set; } 
    }
}
