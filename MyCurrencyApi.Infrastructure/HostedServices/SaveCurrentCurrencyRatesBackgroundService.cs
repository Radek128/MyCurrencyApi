using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyCurrencyApi.Application.Abstracts;
using MyCurrencyApi.Application.Models;
using MyCurrencyApi.Application.Extensions;

namespace MyCurrencyApi.Infrastructure.HostedServices
{
    public class SaveCurrentCurrencyRatesBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public SaveCurrentCurrencyRatesBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var repository = scope.ServiceProvider.GetRequiredService<ICurrencyRateRepository>();
                        var nbpApiClient = scope.ServiceProvider.GetRequiredService<INbpClient>();

                        var today = DateTime.UtcNow.ToString("yyyy-MM-dd");
                        var existingRates = await repository.CheckIfCurrencyRateExist(DateOnly.Parse(today));

                        if (!existingRates)
                        {
                            List<CurriencesTableResponse>? result = await nbpApiClient.GetAllCurrencyRatesAsync(today);
                            if (result is not null)
                            {
                                await repository.SaveCurriencies(result.First().ToCurrencyRatesList());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching currency rates: {ex.Message}");
                }

                await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
            }
        }
    }
}
