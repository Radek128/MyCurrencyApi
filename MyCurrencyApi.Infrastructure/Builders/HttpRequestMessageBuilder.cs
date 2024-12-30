namespace MyCurrencyApi.Infrastructure.Builders
{
    internal class HttpRequestMessageBuilder
    {
       private readonly HttpRequestMessage _message = new();

        public HttpRequestMessage Get(string requestUri) => new HttpRequestMessageBuilder().Get().WithUrl(requestUri).Build();

        private HttpRequestMessageBuilder Get()
        {
            _message.Method = HttpMethod.Get;
            return this;
        }

        private HttpRequestMessageBuilder WithUrl(string requestUri)
        {
            _message.RequestUri = new Uri(requestUri, UriKind.Relative);
            return this;
        }

        private HttpRequestMessage Build() => _message;
    }
}
