
using MyCurrencyApi.Domain.Entities;

namespace MyCurrencyApi.Application.Models
{
    public record CurrencyRatesDto
    {
        public required string CurrencyCode { get; init; }
        public required DateOnly Date { get; init; }      
        public required RateDto AskRate { get; init; }     
        public required RateDto BidRate { get; init; }   

        public static CurrencyRatesDto GetCurrencyRatesDto(List<CurrencyRate> currencyRates, string code, DateOnly date)
        {
            var askRate = currencyRates.OfType<AskRate>().Single();
            var bidRate = currencyRates.OfType<BidRate>().Single();

            return new CurrencyRatesDto
            {
                CurrencyCode = code,
                Date = date,
                AskRate = new RateDto
                {
                    Amount = askRate.Money.Amount,
                    CurrencyName = askRate.Money.Currency.Name
                },
                BidRate = new RateDto
                {
                    Amount = bidRate.Money.Amount,
                    CurrencyName = bidRate.Money.Currency.Name
                }
            };
        }
    }
    public record RateDto
    {
        public required decimal Amount { get; set; } 
        public required string CurrencyName { get; set; } 
    }
}
