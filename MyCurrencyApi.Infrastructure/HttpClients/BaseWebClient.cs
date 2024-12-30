using MyCurrencyApi.Infrastructure.Builders;
using System.Text.Json;

namespace MyCurrencyApi.Infrastructure.HttpClients
{
    public abstract class BaseWebClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        protected BaseWebClient(HttpClient httpClient) 
        {
            _httpClient = httpClient;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
        }

        public async Task<TResponse?> Get<TResponse>(string requestUrl)
        {
            var request = new HttpRequestMessageBuilder().Get(requestUrl);
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseModel = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(responseModel, _jsonSerializerOptions);
        }
    }
}
