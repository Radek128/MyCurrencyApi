using Microsoft.EntityFrameworkCore;
using MyCurrencyApi.Application.Abstracts;
using MyCurrencyApi.Application.Models;
using MyCurrencyApi.Domain.Entities;
using MyCurrencyApi.Domain.Exceptions;

namespace MyCurrencyApi.Infrastructure.DAL.Repositories
{
    public class CurrencyRateRepository : ICurrencyRateRepository
    {
        private readonly CurrencyRateDbContext _dbContext;

        public CurrencyRateRepository(CurrencyRateDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> CheckIfCurrencyRateExist(DateOnly date)
        {
            return _dbContext.CurrencyRates.AnyAsync(c => c.Date == date);
        }

        public async Task<CurrencyRatesDto> GetCurrencyRatesAsync(string currencyCode, DateOnly date)
        {
            List<CurrencyRate>? result = await _dbContext.CurrencyRates
            .Where(r => r.Money.Currency.Code == currencyCode && r.Date == date)
            .ToListAsync();

            if (result is null)
                throw new EntityNotFoundException($"CurrencyCode for {currencyCode} and date: {date} not exist");

            return CurrencyRatesDto.GetCurrencyRatesDto(result, currencyCode, date);
        }

        public async Task SaveCurriencies(List<CurrencyRate> currencyRate)
        {
            _dbContext.AddRange(currencyRate);
            await _dbContext.SaveChangesAsync();
        }
    }
}
