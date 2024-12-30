using MyCurrencyApi.Application.Models;
using MyCurrencyApi.Domain.Entities;

namespace MyCurrencyApi.Application.Abstracts
{
    public interface ICurrencyRateRepository
    {
        Task SaveCurriencies(List<CurrencyRate> currencyRate);
        Task<CurrencyRatesDto> GetCurrencyRatesAsync(string currencyCode, DateOnly date);
        Task<bool> CheckIfCurrencyRateExist(DateOnly date);
    }
}
