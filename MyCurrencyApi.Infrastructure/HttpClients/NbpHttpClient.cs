using MyCurrencyApi.Application.Abstracts;
using MyCurrencyApi.Application.Models;

namespace MyCurrencyApi.Infrastructure.HttpClients
{
    public class NbpHttpClient : BaseWebClient, INbpClient
    {
        public NbpHttpClient(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<List<CurriencesTableResponse>?> GetAllCurrencyRatesAsync(string date)
        {
            string requestUrl = $"api/exchangerates/tables/c/{date}/?format=json";
            return Get<List<CurriencesTableResponse>?>(requestUrl);
        }
    }
}
  