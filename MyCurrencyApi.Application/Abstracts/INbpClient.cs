using MyCurrencyApi.Application.Models;

namespace MyCurrencyApi.Application.Abstracts
{
    public interface INbpClient
    {
        Task<List<CurriencesTableResponse>?> GetAllCurrencyRatesAsync(string date);
    }
}
