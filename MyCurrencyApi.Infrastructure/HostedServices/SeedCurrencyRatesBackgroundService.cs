using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyCurrencyApi.Application.Abstracts;
using MyCurrencyApi.Application.Extensions;

namespace MyCurrencyApi.Infrastructure.HostedServices
{
    public class SeedCurrencyRatesBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private const int YEAR = 2024;
        private const int MONTH = 12;
        private const int DAY = 20;

        public SeedCurrencyRatesBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var repository = scope.ServiceProvider.GetRequiredService<ICurrencyRateRepository>();
                    var nbpApiClient = scope.ServiceProvider.GetRequiredService<INbpClient>();
                    var dates = new List<string>();
                    for (int day = 1; day <= DAY; day++)
                    {
                        var date = new DateTime(YEAR, MONTH, day);
                        if (date.DayOfWeek is not DayOfWeek.Saturday and not DayOfWeek.Sunday)
                        {
                            dates.Add(date.ToString("yyyy-MM-dd"));
                        }
                    }

                    var tasks = dates.Select(x => nbpApiClient.GetAllCurrencyRatesAsync(x)).ToList();
                    var result = await Task.WhenAll(tasks);
                    if (result is not null)
                    {
                        var rates = result.SelectMany(x => x.First().ToCurrencyRatesList()).ToList();
                        await repository.SaveCurriencies(rates);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching currency rates: {ex.Message}");
            }
            
        }
    }
}
